import { Component, inject } from '@angular/core';
import { MatButtonToggleChange, MatButtonToggleModule } from '@angular/material/button-toggle';
import { globalData } from '../../services/globalData';
import { NgFor } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

import CourseResponseDTO from '../models/CourseResponseDTO';
import CourseDTO from '../models/CourseDTO';
import ScheduleRequestDTO from '../models/ScheduleRequestDTO';
import ClassInsertDTO from '../models/ClassInsertDTO';
import MajorResponseDTO from '../models/MajorResponseDTO';
import SectionResponseDTO from '../models/SectionResponseDTO';
import { SectionCoursesComponent } from './section-courses/section-courses.component';
import { FilterCoursesComponent } from '../filter-courses/filter-courses.component';
import { Get, Patch, Post } from '../../services/api';
import ScheduleResponseDTO from '../models/ScheduleResponseDTO';
import AccountReturnDTO from '../models/AccountReturnDTO';

@Component({
  selector: 'app-schedule-create-edit',
  imports: [MatButtonToggleModule, NgFor, NavbarComponent, MatProgressBarModule, MatSelectModule, MatDialogModule],
  templateUrl: './schedule-create-edit.component.html',
  styleUrl: './schedule-create-edit.component.css'
})

export class ScheduleCreateEditComponent {

  private readonly dialog = inject(MatDialog);

  year: number = 1;
  semester: string = "Fall";
  schedule: ScheduleRequestDTO | undefined = undefined; //Where the actual classes are stored
  classes: Array<ClassInsertDTO> = []; //What is selected by the user to take
  courses: Array<CourseResponseDTO> = []; //What is selected in classes
  displayedCourses: Array<CourseResponseDTO> = []; //What is displayed from the selected
  globalCourses: Array<CourseResponseDTO> = []; //Acutal Courses that are stored
  majors: Array<MajorResponseDTO> = [];
  displayedSections: Array<SectionResponseDTO> = [];
  scheduleId: number = 0;

  constructor(private globalData: globalData) {}

  ngOnInit() {
    this.load();
  }

  async load() {
    //Check observables, then localstorage, then call api
    this.globalData.getSchedule().subscribe((value) => (this.schedule = value));
    if(this.schedule === undefined) {
      var tmp = localStorage.getItem('Schedule');
      if(tmp !== null) {
        this.schedule = JSON.parse(tmp);
      } else {
        //This should never happen, means previous page either didn't get a schedule or 
      }
    }

    this.globalData.getCourses().subscribe((value) => (this.globalCourses = value));
    if(this.globalCourses.length === 0) {
      var tmp = localStorage.getItem('Courses');
      if(tmp !== null) {
        this.globalCourses = JSON.parse(tmp);
        this.globalData.updateCourseStatus(this.globalCourses);
      } else {
        //API call
        try {
          let response = await Get('Courses', []);
            let coursesResponse: Array<CourseResponseDTO> = response;
            if(coursesResponse !== undefined) {
              this.globalData.updateCourseStatus(coursesResponse);
              this.globalCourses = coursesResponse;
            } else {
              console.log(coursesResponse); //Bad request or response
            }
        } catch(error) {

        }
          
      }
    }

    this.globalData.getMajors().subscribe((value) => (this.majors = value));
    if(this.majors.length === 0) {
      let tmp = localStorage.getItem('Majors');
      if(tmp !== null) {
        this.majors = JSON.parse(tmp);
        this.globalData.updateMajorStatus(this.majors);
      } else {
        //API call
        try {
          let response = await Get('Major', []);
            let majorResponse: Array<MajorResponseDTO> = response;
            if(majorResponse !== undefined) {
              this.majors = majorResponse;
              this.globalData.updateMajorStatus(this.majors);
            } else {
              console.log(majorResponse); //Bad request or response
            }
        } catch (error) {

        }
      }
    }
    this.globalData.getScheduleId().subscribe((value) => this.scheduleId = value)
    if(this.scheduleId === 0) {
      let tmp = localStorage.getItem('ScheduleId');
      if(tmp !== null) {
        this.scheduleId = Number(tmp);
      }
    }
    this.updateCourses();
  }
  

  // Runs on Init to update courses on courseId from schedule.classes.courseId
  updateCourses() {
    this.schedule?.Classes.forEach(c => {
      let tmp = this.globalCourses.find((value) => (value.id === c.courseId));
      if(tmp !== undefined) {
        this.courses.push(tmp); // Add to courses to be displayed
        this.globalCourses = this.globalCourses.filter((value) => (value.id !== tmp.id)); // Remove from globalCourses
      }
    });
  }

  // Moves the course from global to current to prevent duplicates and adds to class for eventual api usage
  addClass(id: number) {
    this.classes.forEach(c => {
      if(c.courseId === id) {
        return;
      }
    });

    let newClass = {
      id: -1,
      semester: this.semester,
      year: this.year,
      courseId: id
    };

    //Find course in global, move to courses
    for(var c of this.globalCourses) {
      if(c.id === id) {
        this.courses.push(c);
        newClass.courseId = c.id;
        this.updateSections(c, false);
        break;
      }
    }

    // Remove the course from global to prevent duplicates
    this.globalCourses = this.globalCourses.filter((value) => (value.id !== id));

    // Add new class to our classes section
    this.schedule?.Classes.push(newClass);
    this.classesChange();
  }

  // requirementsCheck(preReq: string, id: number): boolean {
  //   // Check requirements using eval()
  //   // If false, give element a !
  //   let c = this.classes.find(i => i.courseId === id);

  //   if(c !== undefined)
  //     var yearSemester = this.evalYearSeason(c);

  //   let pc = this.classes.filter((value) => (this.evalYearSeason(value) < yearSemester))
  //   let good = eval(preReq);
  //   return good;
  // }

  // evalYearSeason(c: ClassInsertDTO): number {
  //   let value = 0;
  //   switch(c.semester) {
  //     case "Fall":
  //       value = value + 1;
  //       break;
  //     case "Winter":
  //       value = value + 2;
  //       break;
  //     case "Spring":
  //       value = value + 3;
  //       break;
  //     case "Summer":
  //       value = value + 4;
  //       break;
  //   }

  //   switch(c.year) {
  //     case 1:
  //       value = value + 10;
  //       break;
  //     case 2:
  //       value = value + 20;
  //       break;
  //     case 3:
  //       value = value + 30;
  //       break;
  //     case 4:
  //       value = value + 40;
  //       break;
  //     case 5:
  //       value = value + 50;
  //       break;
  //   }
  //   return value;
  // }

  delete(id: number) {
    //Remove the class
    let removed;
    let course;
    this.schedule?.Classes.forEach(c => {
      if(c.courseId === id) {
        removed = c;
        course = this.courses.find((value) => (value.id === c.courseId));
      }
    });

    //finds the class in schedule classes, gets its index and removes it by splice
    let found = this.schedule?.Classes.find((value) => (value.courseId === id));
    if(found) {
      const index = this.schedule?.Classes.indexOf(found, 0);
      if(index !== undefined && index > -1) {
        this.schedule?.Classes.splice(index, 1);
      }
    }

    //Remove the course associated with the class
    this.courses = this.courses.filter((value) => (value.id !== id));

    //Add that course to the global courses 
    if(course) {
      this.globalCourses.push(course);
      this.updateSections(course, true);
    }
    this.classesChange();
  }

  // Adds/Removes courses to be shown to users for a section, also changes its credit hours
  updateSections(course: CourseResponseDTO, remove: boolean) {
    this.displayedSections.forEach(s => {
      if(remove && course.sectionIds.find(i => i === s.id)) {
        s.credit_Current = s.credit_Current - course.credit_hours;
        s.courses = s.courses.filter(i => (i.Id !== course.id));
      } else if(!remove) {
        s.courses.push({Id : course.id, Name : course.name, Description : course.description});
        s.credit_Current = s.credit_Current + course.credit_hours;
      }
    });
  }

  yearChange(event: MatButtonToggleChange) {
    if(event.value === "All") {
      this.year = 100;
    }
    else {
      this.year = Number(event.value);
    }
    this.classesChange();
  }

  semesterChange(event: MatButtonToggleChange) {
    if(event.value === "All") {
      this.semester = "All";
    }
    else {
      this.semester = event.value;
    }
    this.classesChange();
  }

  //Filter through global for the course, remove it, add it to courses and add a new class to classes
  classesChange() {
    //First get all classes associated with Year/Semester
    this.displayedCourses = [];
    if(this.schedule !== undefined) {
      if(this.year === 100 && this.semester === "All") {
        //Dont filter anything
        this.classes = this.schedule?.Classes;
      }
      else if(this.year === 100) {
        // Filter for all year but specific semester
        this.classes = this.schedule?.Classes.filter((value) => (value.semester === this.semester));
      } else if (this.semester === "All") {
        // Filter for all semesters but specific year
        this.classes = this.schedule?.Classes.filter((value) => (value.year === this.year));
      } else {
        // Filter normally
        this.classes = this.schedule?.Classes.filter((value) => (value.semester === this.semester && value.year === this.year));
      }
    }
    //Then get all courses that are associated with those classes to display subject/number to user
    this.classes.forEach(c => {
      var course = this.courses.find(i => i.id === c.courseId);
      if(course !== undefined) {
        this.displayedCourses.push(course);
      }
    });
  }

  // Here we save the schedule by sending a PATCH with the scheduleId and schedule
  async save() {
    try {
      const options = {
        Name: this.schedule?.Name,
        Classes: this.classes
      };
      let response = await Patch('Schedule', [this.scheduleId.toString()], options);
        //Convert from ScheduleResponse to ScheduleRequest
        let scheduleResponse: ScheduleResponseDTO = response;
        let scheduleRequest: ScheduleRequestDTO = {
          Name: scheduleResponse.Name,
          Classes: scheduleResponse.Classes
        }
        this.globalData.updateScheduleStatus(scheduleRequest);
        //update user schedules
        this.globalData.getAccount().subscribe((value) => {
          value?.schedules.forEach(s => {
            if(s.Id === scheduleResponse.Id) {
              s = scheduleResponse;
            }
          });
          this.globalData.updateAccountStatus(value);
        });
        // Some alert you its successfull
        console.log("Save Success");
    } catch(error) {

    }
  }

  // Here we create a new schedule by sending a POST with the schedule
  async create() {
    try{
      const options = {
        Name: this.schedule?.Name,
        Classes: this.classes
      };
      let account: AccountReturnDTO = {id: 0,
        username: "",
        password: "",
        email: "",
        schedules: []
      };
      this.globalData.getAccount().subscribe((value) => {
        if(value !== undefined) {
          account = value;
        } else {
          const tmp = localStorage.getItem('Account');
          if(tmp !== null) {
            account = JSON.parse(tmp);
          }
        }
      });
      let response = await Post('Schedule', [account.id.toString()], options);
      if(!response.ok) {
        throw new Error('Response Status: ' + response.status);
      } else {
        let scheduleResponse: ScheduleResponseDTO = JSON.parse(response.json());
        this.globalData.updateScheduleIdStatus(scheduleResponse.Id);
        this.scheduleId = scheduleResponse.Id;
        if(account !== undefined) {
          account.schedules.push();
        }
        this.globalData.updateAccountStatus(account);
        console.log("Created" + response);
        
        //update user schedules
        //Alert user its successfull
      }
    } catch (error) {
      console.log(error);
    }
  }

  // Change displayed courses based on which major is selected
  selectMajor(major: MajorResponseDTO) {
    this.displayedSections = major.sections;
    //Update displayedSection credit hours with existing courses
    this.courses.forEach(c => {
      this.updateSections(c, false);
    });
  }

  displayCourses(courses: Array<CourseDTO>, name: string) {
    const dialogRef = this.dialog.open(SectionCoursesComponent, 
      {data: {courses: courses, name: name}}
    );
  }

  openFilter() {
    const dialogRef = this.dialog.open(FilterCoursesComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      // Filter through subjectSelected, attributeSelected, campusSelected, min, max
      this.displayedCourses.filter((value) => {
        if(value.course_Number < result.min || value.course_Number > result.max) {
          return false; // Course number outside of inputted range
        } else if(result.subjectSelected !== undefined && !result.subjectSelected.contains(value.subject)) {
          return false; // No selected subjects match this courses subject
        }

        // Checks if any attributes match
        let attributes = true;
        for(let i = 0; i<value.featureDTOs.length; i++) {
          if(result.attributeSelected.contains(value.featureDTOs[i])) {
            attributes = false;
            break;
          }
        };
        if(attributes && result.attributeSelected.length !== 0) {
          return false; // User selected attributes, but none match courses attributes
        }

        // Checks if any campuses match
        let campuses = true;
        for(let j = 0; j<value.campusDTOs.length; j++) {
          if(result.campusSelected.contains(value.campusDTOs[j])) {
            campuses = false;
            break;
          }
        }
        if(campuses && result.campusSelected.length !== 0) {
          return false; // User selected campuses, but none match courses campus locations
        }

        return true;
      })
    })
  }
  
}
