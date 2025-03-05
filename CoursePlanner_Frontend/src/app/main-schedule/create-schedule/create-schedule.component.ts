import { Component, inject } from '@angular/core';
import { MainScheduleComponent } from '../main-schedule.component';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-schedule',
  imports: [],
  templateUrl: './create-schedule.component.html',
  styleUrl: './create-schedule.component.css'
})
export class CreateScheduleComponent {

  readonly dialogRef = inject(MatDialogRef<MainScheduleComponent>);

  createNewSchedule() {
    this.dialogRef.close();
  }

  close() {
    this.dialogRef.close();
  }
}
