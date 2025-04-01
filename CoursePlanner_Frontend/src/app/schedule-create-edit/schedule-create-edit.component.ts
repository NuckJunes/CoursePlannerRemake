import { Component } from '@angular/core';
import { MatButtonToggleChange, MatButtonToggleModule } from '@angular/material/button-toggle';
import CourseResponseDTO from '../models/CourseResponseDTO';
import { globalData } from '../../services/globalData';
import { NgFor } from '@angular/common';
import ScheduleRequestDTO from '../models/ScheduleRequestDTO';
import ClassInsertDTO from '../models/ClassInsertDTO';
import { NavbarComponent } from '../navbar/navbar.component';
import MajorResponseDTO from '../models/MajorResponseDTO';
import SectionResponseDTO from '../models/SectionResponseDTO';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-schedule-create-edit',
  imports: [MatButtonToggleModule, NgFor, NavbarComponent, MatProgressBarModule, MatSelectModule],
  templateUrl: './schedule-create-edit.component.html',
  styleUrl: './schedule-create-edit.component.css'
})

export class ScheduleCreateEditComponent {

  year: number = 1;
  semester: string = "Fall";
  schedule: ScheduleRequestDTO | undefined = undefined; //Where the actual classes are stored
  classes: Array<ClassInsertDTO> = []; //What is selected by the user to take
  courses: Array<CourseResponseDTO> = []; //What is selected in classes
  displayedCourses: Array<CourseResponseDTO> = []; //What is displayed from the selected
  globalCourses: Array<CourseResponseDTO> = [ //Acutal Courses that are stored
    { //Fake data that will be replaced with real data after API works
      Id: 1,
      Name: "Computer Science Intro",
      Description: "A intro to Computer Science",
      Credit_hours: 1.0,
      Subject: "CEC",
      Course_Number: 101,
      FeatureDTOs: [],
      CampusDTOs: [],
      SectionIds: [1],
      PreRequisites: ""
    },
    {
      Id: 2,
      Name: "Computer Science Intro 2",
      Description: "A intro to Computer Science again",
      Credit_hours: 1.0,
      Subject: "CEC",
      Course_Number: 102,
      FeatureDTOs: [],
      CampusDTOs: [],
      SectionIds: [1],
      PreRequisites: "(pc.find(i => i.courseId === 1))"
    }
  ];
  majors: Array<MajorResponseDTO> = [
    {
      Id: 1,
      Name: "Software Engineering",
      College: "College of Computer Engineering",
      Graduate: false,
      Credit_Min: 92.0,
      Credit_Max: 98.0,
      Sections: [
        {
          Id: 1,
          Name: "Core",
          Credit_Min: 2.0,
          Credit_Max: 2.0,
          Credit_Current: 0.0,
          Courses: []
        }
      ]
  }];
  displayedSections: Array<SectionResponseDTO> = [];

  constructor(private globalData: globalData) {}

  ngOnInit() {
    // Check globalData and Localstorage for courses 
    // If they are empty, call API and update both
    this.globalData.updateCourseStatus(this.globalCourses);
    this.globalData.updateMajorStatus(this.majors);
    this.globalData.getSchedule().subscribe((value) => (this.schedule = value));
    this.globalData.getCourses().subscribe((value) => (this.globalCourses = value));
    this.globalData.getMajors().subscribe((value) => (this.majors = value));
  }

  // Runs on Init to update courses on courseId from schedule.classes.courseId
  updateCourses() {
    this.schedule?.Classes.forEach(c => {
      let tmp = this.globalCourses.find((value) => (value.Id === c.courseId));
      if(tmp !== undefined) {
        this.courses.push(tmp); // Add to courses to be displayed
        this.globalCourses = this.globalCourses.filter((value) => (value.Id !== tmp.Id)); // Remove from globalCourses
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
      if(c.Id === id) {
        this.courses.push(c);
        newClass.courseId = c.Id;
        this.updateSections(c, false);
        break;
      }
    }

    // Remove the course from global to prevent duplicates
    this.globalCourses = this.globalCourses.filter((value) => (value.Id !== id));

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
        course = this.courses.find((value) => (value.Id === c.courseId));
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
    this.courses = this.courses.filter((value) => (value.Id !== id));

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
      if(remove && course.SectionIds.find(i => i === s.Id)) {
        s.Credit_Current = s.Credit_Current - course.Credit_hours;
        s.Courses.filter(i => (i.Id !== course.Id));
      } else if(!remove) {
        s.Courses.push({Id : course.Id, Name : course.Name, Description : course.Description});
        s.Credit_Current = s.Credit_Current + course.Credit_hours;
      }
    });
  }

  yearChange(event: MatButtonToggleChange) {
    this.year = Number(event.value);
    this.classesChange();
  }

  semesterChange(event: MatButtonToggleChange) {
    this.semester = event.value;
    this.classesChange();
  }

  //Filter through global for the course, remove it, add it to courses and add a new class to classes
  classesChange() {
    //First get all classes associated with Year/Semester
    this.displayedCourses = [];
    if(this.schedule !== undefined) {
      this.classes = this.schedule?.Classes.filter((value) => (value.semester === this.semester && value.year === this.year));
    }
    //Then get all courses that are associated with those classes to display subject/number to user
    this.classes.forEach(c => {
      var course = this.courses.find(i => i.Id === c.courseId);
      if(course !== undefined) {
        this.displayedCourses.push(course);
      }
    });
  }

  // Here we save the schedule by sending a PATCH with the scheduleId and schedule
  save() {

  }

  // Here we create a new schedule by sending a POST with the schedule
  create() {

  }

  // Change displayed courses based on which major is selected
  selectMajor(major: MajorResponseDTO) {
    this.displayedSections = major.Sections;
  }
  
}
