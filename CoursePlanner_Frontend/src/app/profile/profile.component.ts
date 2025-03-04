import { Component } from '@angular/core';
import { NavbarComponent } from "../navbar/navbar.component";
import { globalData } from '../../services/globalData';
import { Router } from '@angular/router';
import AccountReturnDTO from '../models/AccountReturnDTO';
import ScheduleResponseDTO from '../models/ScheduleResponseDTO';

@Component({
  selector: 'app-profile',
  imports: [NavbarComponent],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {

  value: boolean = true;
  account: AccountReturnDTO = {
      Id: -1,
      Username: "",
      Password: "",
      Email: "",
      Schedules: Array<ScheduleResponseDTO>()
  };

  constructor(private globalData: globalData, private router: Router){}

  ngOnInit() {
    var accountData;
    this.globalData.getAccount().subscribe((value) => (accountData = value));
    if(accountData !== undefined) {
      this.account = accountData;
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
