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

@Component({
  selector: 'app-schedule-create-edit',
  imports: [MatButtonToggleModule, NgFor, NavbarComponent, MatProgressBarModule],
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
  majors: Array<MajorResponseDTO> = [];
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
    this.globalCourses.forEach(c => {
      if(c.Id === id) {
        this.courses.push(c);
        newClass.courseId = c.Id;
      }
    });

    // Remove the course from global to prevent duplicates
    this.globalCourses = this.globalCourses.filter((value) => (value.Id !== id));

    // Add new class to our classes section
    this.schedule?.Classes.push(newClass);
    this.classesChange();
  }

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
    if(course)
      this.globalCourses.push(course);
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

  
}
