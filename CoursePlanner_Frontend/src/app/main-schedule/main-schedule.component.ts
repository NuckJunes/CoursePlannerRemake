import { Component, inject } from '@angular/core';
import { NavbarComponent } from "../navbar/navbar.component";
import { MatDialog } from '@angular/material/dialog';
import { CreateScheduleComponent } from './create-schedule/create-schedule.component';
import { EditScheduleComponent } from './edit-schedule/edit-schedule.component';
import { globalData } from '../../services/globalData';
import { MatTooltipModule } from '@angular/material/tooltip';
@Component({
  selector: 'app-main-schedule',
  imports: [NavbarComponent, MatTooltipModule],
  templateUrl: './main-schedule.component.html',
  styleUrl: './main-schedule.component.css'
})
export class MainScheduleComponent {

  loggedIn: boolean = false;

  readonly dialog = inject(MatDialog);

  constructor(private globalData: globalData) {}

  ngOnInit() {
    var data;
    this.globalData.getAccount().subscribe((value) => (data = value))
    if(data !== undefined) {
      this.loggedIn = true;
    } else {
      this.loggedIn = false;
    }
  }

  openCreateMenu(): void {
    const dialogRef = this.dialog.open(CreateScheduleComponent);
  }

  openEditMenu(): void {
    const dialogRef = this.dialog.open(EditScheduleComponent);
  }

  notLoggedIn(): void {

  }
}
