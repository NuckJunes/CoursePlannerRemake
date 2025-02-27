import { Component } from '@angular/core';
import { globalData } from '../../services/globalData';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  constructor(private globalData: globalData) {}

  username: string = "username";
  password: string = "password";

  login() {
    //checks the username and password by calling POST login endpoint

    this.globalData.updateLoginStatus(true);
  }
}
