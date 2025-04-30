import { Component, inject } from '@angular/core';
import { globalData } from '../../services/globalData';
import { NavbarComponent } from "../navbar/navbar.component";
import { Router } from '@angular/router';
import AccountReturnDTO from '../models/AccountReturnDTO';
import ScheduleResponseDTO from '../models/ScheduleResponseDTO';
import { MatDialog } from '@angular/material/dialog';
import { CreateAccountComponent } from './create-account/create-account.component';
import { Post } from '../../services/api';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-login',
  imports: [NavbarComponent, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  constructor(private globalData: globalData, private router: Router) {}

  readonly dialog = inject(MatDialog);

  value : boolean = false;
  username: string = "username";
  password: string = "password";
  account: AccountReturnDTO | undefined = undefined;

  async login() {
    //checks the username and password by calling POST login endpoint
    // this.account = {
    //   Id: -1,
    //   Username: "username",
    //   Password: "password",
    //   Email: "Email@Email.com",
    //   Schedules: Array<ScheduleResponseDTO>()
    // };

    // var class1 = {
    //   id: 1,
    //   semester: "Spring",
    //   year: 2,
    //   courseId: 1
    // };

    // var newSchedule = {
    //   Id: 1,
    //   Name: "Schedule Test 1",
    //   Classes: [class1]
    // };

    // this.account.Schedules.push(newSchedule);
    const options = {
        Username: this.username,
        Password: this.password
    };
    
    try {
      let response = await Post('login', [], options);
        let loginResponse: AccountReturnDTO = response;
        if(loginResponse !== undefined) {
          this.globalData.updateAccountStatus(loginResponse);
          this.router.navigate(['/profile']);
        } else {
          console.log(response.status);
        }
    } catch(error) {
      console.log(error);
    }
    
    //Forces reload of navbar to account for change in login to profile
    if(this.value) {
      this.value = false;
    } else {
      this.value = true;
    }
  }

  createAccount() {
      const dialogRef = this.dialog.open(CreateAccountComponent);
  }
}
