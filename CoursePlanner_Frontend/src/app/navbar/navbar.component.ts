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
    var accountData;
    this.globalData.getAccount().subscribe((value) => (accountData = value));

    //If we are already loggedin through observables
    if(accountData !== undefined) {
      this.loginProfile = "/profile";
      this.loginString = "Profile";
    } else {
      //If the login info is stored on localStorage
      const accountString = localStorage.getItem('Account');
      if(accountString !== 'undefined') {
        this.loginProfile = "/profile";
        this.loginString = "Profile";
        if(accountString !== null)//this should never be null
          this.globalData.updateAccountStatus(JSON.parse(accountString));
      } else {
        this.loginProfile = "/login";
        this.loginString = "Login";
      }
    }
   }
}
