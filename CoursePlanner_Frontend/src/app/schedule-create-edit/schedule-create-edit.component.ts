import { Component } from '@angular/core';
import { MatButtonToggleChange, MatButtonToggleModule } from '@angular/material/button-toggle';
import CourseResponseDTO from '../models/CourseResponseDTO';
import { globalData } from '../../services/globalData';
import { NgFor } from '@angular/common';
import ScheduleRequestDTO from '../models/ScheduleRequestDTO';
import ClassInsertDTO from '../models/ClassInsertDTO';
import { NavbarComponent } from '../navbar/navbar.component';

@Component({
  selector: 'app-schedule-create-edit',
  imports: [MatButtonToggleModule, NgFor, NavbarComponent],
  templateUrl: './schedule-create-edit.component.html',
  styleUrl: './schedule-create-edit.component.css'
})

export class ScheduleCreateEditComponent {

  year: number = 1;
  semester: string = "Fall";
  schedule: ScheduleRequestDTO | undefined = undefined; //Where the actual classes are stored
  classes: Array<ClassInsertDTO> = []; //What is filtered for user display
  courses: Array<CourseResponseDTO> = []; //What is filtered for user display
  globalCourses: Array<CourseResponseDTO> = [ //Acutal Courses that are stored
    { 
      Id: 1,
      Name: "Computer Science Intro",
      Description: "A intro to Computer Science",
      Credit_hours: 1.0,
      Subject: "CEC",
      Course_Number: 101,
      FeatureDTOs: [],
      CampusDTOs: [],
      PreReqDtos: []
    }
  ];

  constructor(private globalData: globalData) {}

  ngOnInit() {
    this.globalData.updateCourseStatus(this.globalCourses);
    // Call API for courses and update the observable and localstorage
    this.globalData.getSchedule().subscribe((value) => (this.schedule = value));
    this.globalData.getCourses().subscribe((value) => (this.globalCourses = value));
  }

  addClass(id: number) {
    //Check for dulpicate values in schedule classes, error if there is one
    let newClass = {
      id: -1,
      semester: this.semester,
      year: this.year,
      courseId: id
    };
    this.schedule?.Classes.push(newClass);
    this.classesChange();
  }

  delete(id: number) {
    if(this.schedule !== undefined) {
      this.schedule.Classes = this.schedule?.Classes.filter((value) => (value.courseId !== id));
    }
    this.classesChange();
  }

  yearChange(event: MatButtonToggleChange) {
    this.year = Number(event.value);
    this.classesChange();
  }

  semesterChange(event: MatButtonToggleChange) {
    this.semester = event.value;
    this.classesChange();
  }

  classesChange() {
    //First get all classes associated with Year/Semester
    this.courses = [];
    if(this.schedule !== undefined) {
      this.classes = this.schedule?.Classes.filter((value) => (value.semester === this.semester && value.year === this.year));
    }
    //Then get all courses that are associated with those classes to display subject/number to user
    this.classes.forEach(c => {
      var course = this.globalCourses.find(i => i.Id === c.courseId);
      if(course !== undefined) {
        this.courses.push(course);
      }
    });
  }

  
}
