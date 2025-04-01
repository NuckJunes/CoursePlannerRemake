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
    if(this.Password !== this.Confirm) {
      //Error here, don't close dialog
    } else {
      // Create account api call and go back to login page
    }
  }
}
