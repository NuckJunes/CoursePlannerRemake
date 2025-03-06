import { Component } from '@angular/core';
import { MatButtonToggleModule } from '@angular/material/button-toggle';

@Component({
  selector: 'app-schedule-create-edit',
  imports: [MatButtonToggleModule],
  templateUrl: './schedule-create-edit.component.html',
  styleUrl: './schedule-create-edit.component.css'
})

export class ScheduleCreateEditComponent {

  year: number = 1;
  semester: string = "Fall";

  yearChange(event) {

  }
}
