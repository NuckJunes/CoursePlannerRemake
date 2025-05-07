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
