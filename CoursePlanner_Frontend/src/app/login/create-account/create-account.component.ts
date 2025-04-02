import { Component } from '@angular/core';

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

  create() {
    if(this.Password.length < 8) {
      // Password too short
    } 
    else if(this.Password.length > 128) {
      // Password too long
    }
    else if(!(/^[a-zA-Z0-9!%$#]+$/.test(this.Password))) {
      // Can't have other characters in password
    }
    else if(this.Password !== this.Confirm) {
      // Passwords dont match
    }
    else {
      // Create account api call and go back to login page
    }
  }
}
