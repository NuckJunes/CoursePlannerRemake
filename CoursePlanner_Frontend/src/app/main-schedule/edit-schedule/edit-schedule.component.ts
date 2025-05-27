import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { globalData } from '../../../services/globalData';
import { MatDialogRef } from '@angular/material/dialog';
import { MainScheduleComponent } from '../main-schedule.component';
import { NgFor } from '@angular/common';
import ScheduleResponseDTO from '../../models/ScheduleResponseDTO';
import ClassInsertDTO from '../../models/ClassInsertDTO';
import ScheduleRequestDTO from '../../models/ScheduleRequestDTO';

@Component({
  selector: 'app-edit-schedule',
  imports: [NgFor],
  templateUrl: './edit-schedule.component.html',
  styleUrl: './edit-schedule.component.css'
})
export class EditScheduleComponent {

    readonly dialogRef = inject(MatDialogRef<MainScheduleComponent>);
    schedules: Array<ScheduleResponseDTO> = [];

    constructor(private router: Router, private globalData: globalData) {}

    ngOnInit() {
      this.globalData.getAccount().subscribe((value) => 
        {
          if(value !== undefined) {
            this.schedules = value.schedules;
          }
        });
    }

    editSchedule(s: ScheduleResponseDTO) {
      // Setting up new schedule to edit
      let newSchedule : ScheduleRequestDTO = { 
        Name: s.name,
        Classes: []
      }

      // Changing ClassDTO to ClassInsertDTO
      s.classes.forEach(element => {
        var newClass = { 
          id: -1,
          semester: element.semester,
          year: element.year,
          courseId: element.courseId
        };
        newSchedule.Classes.push(newClass);
      });

      // Update observables to use this Schedule
      this.globalData.updateScheduleStatus(newSchedule);
      this.globalData.updateScheduleIdStatus(s.id); // Needed for PATCH call
      this.router.navigate(['/schedule-create-edit']);
      this.dialogRef.close();
    }

    close() {
      this.dialogRef.close();
    }

}
