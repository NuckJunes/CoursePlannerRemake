import { Component } from '@angular/core';
import { globalData } from '../../services/globalData';
import { NavbarComponent } from "../navbar/navbar.component";
import { Router } from '@angular/router';

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

  login() {
    //checks the username and password by calling POST login endpoint
    this.globalData.updateLoginStatus(true);
    
    if(this.value) {
      this.value = false;
    } else {
      this.value = true;
    }
    this.router.navigate(['/profile']);
  }
}
