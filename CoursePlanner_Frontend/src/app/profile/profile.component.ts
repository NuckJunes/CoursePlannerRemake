import { Component } from '@angular/core';
import { NavbarComponent } from "../navbar/navbar.component";
import { globalData } from '../../services/globalData';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  imports: [NavbarComponent],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {

  value: boolean = true;

  constructor(private globalData: globalData, private router: Router){}

  logOut() {
    this.globalData.updateLoginStatus(false);

    //force reset of navbar component
    if(this.value) {
      this.value = false;
    } else {
      this.value = true;
    }

    this.router.navigate(['/login']);
  }
}
