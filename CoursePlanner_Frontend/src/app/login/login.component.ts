import { Component } from '@angular/core';
import { globalData } from '../../services/globalData';
import { NavbarComponent } from "../navbar/navbar.component";
import { Router } from '@angular/router';
import AccountReturnDTO from '../models/AccountReturnDTO';
import ScheduleResponseDTO from '../models/ScheduleResponseDTO';

@Component({
  selector: 'app-login',
  imports: [NavbarComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  constructor(private globalData: globalData, private router: Router) {}

  value : boolean = false;
  username: string = "username";
  password: string = "password";
  account: AccountReturnDTO | undefined = undefined;

  login() {
    //checks the username and password by calling POST login endpoint
    this.account = {
      Id: -1,
      Username: "username",
      Password: "password",
      Email: "Email@Email.com",
      Schedules: Array<ScheduleResponseDTO>()
    };
    
    if(this.account !== undefined) {
      this.globalData.updateAccountStatus(this.account);
    } //else throw error
    
    //Forces reload of navbar to account for change in login to profile
    if(this.value) {
      this.value = false;
    } else {
      this.value = true;
    }
    this.router.navigate(['/profile']);
  }
}
