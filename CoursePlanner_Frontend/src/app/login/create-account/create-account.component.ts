import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../../../services/api';
import AccountCreateDTO from '../../models/AccountCreateDTO';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-create-account',
  imports: [MatFormFieldModule, ReactiveFormsModule],
  templateUrl: './create-account.component.html',
  styleUrl: './create-account.component.css'
})
export class CreateAccountComponent {

  fullForm = new FormGroup({
    Email: new FormControl(""),
    Username: new FormControl(""),
    Password: new FormControl(""),
    Confirm: new FormControl("")
  })

  loading: boolean = false;

  Email: string = "";
  Username: string  = "";
  Password: string = "a";
  Confirm: string = "";
  ErrorText: string = "";
  PasswordErrorColor: string = "#C41230";
  ConfirmErrorColor: string = "#C41230";

  constructor(private router: Router){}

  checkForm() {
    let e = this.fullForm.get('Email');
    let u = this.fullForm.get('Username');
    let p = this.fullForm.get('Password');
    let c = this.fullForm.get('Confirm');

    if(e !== null && e.value !== null) {
      this.Email = e.value;
    }
    if(u !== null && u.value !== null) {
      this.Username = u.value;
    }
    if(p !== null && p.value !== null) {
      this.Password = p.value;
    }
    if(c !== null && c.value !== null) {
      this.Confirm = c.value;
    }
  }

  async create() {
    this.checkForm();
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
          if(accountResponse != null) {
            this.ErrorText = "Good!";
            if(accountResponse.Email === "Exists") {
              this.ErrorText = "Email is already in use!";
            } else if(accountResponse.Username === "Exists") {
              this.ErrorText = "Username already in use!";
            }
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
