import { Component, input, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { globalData } from '../../services/globalData';

@Component({
  selector: 'app-navbar',
  imports: [RouterModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  @Input() change: boolean = false;
  loginProfile: string = "/login";
  loginString: string = "Login";

  constructor(private globalData: globalData){}

  ngOnInit() {
    this.updateLoginStatus();
   }

   ngOnChanges() {
    this.updateLoginStatus();
   }

   updateLoginStatus() {
    var loginData = false;
    this.globalData.getLoggedIn().subscribe((value) => (loginData = value));

    if(loginData) {
      //we are logged in already
      this.loginProfile = "/profile";
      this.loginString = "Profile";
    } else {
      //check if localstorage is holding our login
      const loginString = localStorage.getItem('LoggedIn');
      const loginStorage =  loginString ? JSON.parse(loginString) : false;
      if(loginStorage) {
        //we are logged in already
        this.loginProfile = "/profile";
        this.loginString = "Profile";
      }
    }
   }
}
