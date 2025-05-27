import { Component, inject } from '@angular/core';
import { MainScheduleComponent } from '../main-schedule.component';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { globalData } from '../../../services/globalData';
import ClassInsertDTO from '../../models/ClassInsertDTO';
import { FormsModule } from '@angular/forms';
import ClassDTO from '../../models/ClassDTO';

@Component({
  selector: 'app-create-schedule',
  imports: [FormsModule],
  templateUrl: './create-schedule.component.html',
  styleUrl: './create-schedule.component.css'
})
export class CreateScheduleComponent {

  readonly dialogRef = inject(MatDialogRef<MainScheduleComponent>);
  name: string = "";

  constructor(private router: Router, private globalData: globalData) {}

  createNewSchedule() {
    var newSchedule = {
      Name: this.name,
      Classes: Array<ClassDTO>()
    }
    this.globalData.updateScheduleStatus(newSchedule);
    this.globalData.updateScheduleIdStatus(-1);
    this.router.navigate(['/schedule-create-edit']);
    this.dialogRef.close();
  }

  close() {
    this.dialogRef.close();
  }
}
