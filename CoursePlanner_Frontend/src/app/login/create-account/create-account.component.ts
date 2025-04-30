import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../../../services/api';
import AccountCreateDTO from '../../models/AccountCreateDTO';

@Component({
  selector: 'app-create-account',
  imports: [],
  templateUrl: './create-account.component.html',
  styleUrl: './create-account.component.css'
})
export class CreateAccountComponent {

  Email: string = "";
  Username: string  = "";
  Password: string = "";
  Confirm: string = "";
  ErrorText: string = "";
  PasswordErrorColor: string = "#C41230";
  ConfirmErrorColor: string = "#C41230";

  constructor(private router: Router){}

  async create() {
    if(this.Password.length < 8) {
      // Password too short
      this.ErrorText = "Password is Too Short!";
      this.PasswordErrorColor = "Red";
      this.ConfirmErrorColor = "#C41230";
    } 
    else if(this.Password.length > 128) {
      // Password too long
      this.ErrorText = "Password is Too Long!";
      this.PasswordErrorColor = "Red";
      this.ConfirmErrorColor = "#C41230";
    }
    else if(!(/^[a-zA-Z0-9!%$#]+$/.test(this.Password))) {
      // Can't have other characters in password
      this.ErrorText = "No Special Characters besides !%$# are allowed!";
      this.PasswordErrorColor = "Red";
      this.ConfirmErrorColor = "#C41230";
    }
    else if(this.Password !== this.Confirm) {
      // Passwords dont match
      this.ErrorText = "Passwords do not match!";
      this.PasswordErrorColor = "Red";
      this.ConfirmErrorColor = "Red";
    }
    else {
      // Create account api call and go back to login page
      const account: AccountCreateDTO = {
        Username: this.Username,
        Password: this.Password,
        Email: this.Email
      }
      try {
        let response = await Post('account', [], account);
          let accountResponse: AccountCreateDTO = response;
          if(accountResponse !== undefined) {
            this.router.navigate(['/login']);
          } else {
            console.log(response);
          }
            
      } catch(error) {
        console.log(error);
      }
      //If response is an error, show user
    }
  }
}
