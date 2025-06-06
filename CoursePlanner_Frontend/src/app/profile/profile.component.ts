import { Component } from '@angular/core';
import { NavbarComponent } from "../navbar/navbar.component";
import { globalData } from '../../services/globalData';
import { Router } from '@angular/router';
import AccountReturnDTO from '../models/AccountReturnDTO';
import ScheduleResponseDTO from '../models/ScheduleResponseDTO';
import { NgFor } from '@angular/common';
import ClassInsertDTO from '../models/ClassInsertDTO';
import ScheduleRequestDTO from '../models/ScheduleRequestDTO';
import ClassDTO from '../models/ClassDTO';

@Component({
  selector: 'app-profile',
  imports: [NavbarComponent, NgFor],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {

  value: boolean = true;
  account: AccountReturnDTO = {
      id: -1,
      username: "",
      password: "",
      email: "",
      schedules: Array<ScheduleResponseDTO>()
  };

  constructor(private globalData: globalData, private router: Router){}

  ngOnInit() {
    var accountData;
    this.globalData.getAccount().subscribe((value) => (accountData = value));
    if(accountData !== undefined) {
      this.account = accountData;
    }
  }

  editSchedule(id: number) {
    // Find schedule by id
    // Then convert to scheduleRequestDTO and update global data
    // Finally, navigate to edit schedule page
    let schedule = this.account.schedules.find((Value) => (Value.id === id));

    if(schedule !== undefined) {

      let scheduleToSend:ScheduleRequestDTO = {
        Name: schedule.name,
        Classes: Array<ClassDTO>()
      }
      schedule?.classes.forEach(c => {
        let newClass = {
          id: -1,
          semester: c.semester,
          year: c.year,
          courseId: c.courseId
        };
        scheduleToSend.Classes.push(newClass);
      });

      this.globalData.updateScheduleStatus(scheduleToSend);
      this.globalData.updateScheduleIdStatus(id);
      this.router.navigate(['/schedule-create-edit'])
    }
  }

  logOut() {
    this.globalData.updateAccountStatus(undefined);

    //force reset of navbar component
    if(this.value) {
      this.value = false;
    } else {
      this.value = true;
    }

    this.router.navigate(['/login']);
  }
}
