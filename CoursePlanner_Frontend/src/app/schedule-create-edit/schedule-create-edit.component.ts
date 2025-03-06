import { Component } from '@angular/core';
import { MatButtonToggleChange, MatButtonToggleModule } from '@angular/material/button-toggle';
import CourseResponseDTO from '../models/CourseResponseDTO';
import { globalData } from '../../services/globalData';
import { NgFor } from '@angular/common';
import ScheduleRequestDTO from '../models/ScheduleRequestDTO';
import ClassInsertDTO from '../models/ClassInsertDTO';

@Component({
  selector: 'app-schedule-create-edit',
  imports: [MatButtonToggleModule, NgFor],
  templateUrl: './schedule-create-edit.component.html',
  styleUrl: './schedule-create-edit.component.css'
})

export class ScheduleCreateEditComponent {

  year: number = 1;
  semester: string = "Fall";
  schedule: ScheduleRequestDTO | undefined = undefined;
  classes: Array<ClassInsertDTO> = [];
  courses: Array<CourseResponseDTO> = [];
  globalCourses: Array<CourseResponseDTO> = [];

  constructor(private globalData: globalData) {}

  ngOnInit() {
    // Call API for courses and update the observable and localstorage
    this.globalData.getSchedule().subscribe((value) => (this.schedule = value));
    this.globalData.getCourses().subscribe((value) => (this.globalCourses = value));
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
    this.courses = [];
    if(this.schedule !== undefined) {
      this.classes = this.schedule?.Classes.filter((value) => (value.semester === this.semester && value.year === this.year));
    }
    this.classes.forEach(c => {
      var course = this.globalCourses.find(i => i.Id === c.courseId);
      if(course !== undefined) {
        this.courses.push(course);
      }
    });
  }

  
}
