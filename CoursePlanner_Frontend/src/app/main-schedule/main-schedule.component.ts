import { Component, inject } from '@angular/core';
import { NavbarComponent } from "../navbar/navbar.component";
import { MatDialog } from '@angular/material/dialog';
import { CreateScheduleComponent } from './create-schedule/create-schedule.component';
import { EditScheduleComponent } from './edit-schedule/edit-schedule.component';

@Component({
  selector: 'app-main-schedule',
  imports: [NavbarComponent],
  templateUrl: './main-schedule.component.html',
  styleUrl: './main-schedule.component.css'
})
export class MainScheduleComponent {

  readonly dialog = inject(MatDialog);

  openCreateMenu(): void {
    const dialogRef = this.dialog.open(CreateScheduleComponent);
  }

  openEditMenu(): void {
    const dialogRef = this.dialog.open(EditScheduleComponent);
  }
}
