import { Component, Inject} from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-section-courses',
  imports: [MatDialogModule, NgFor],
  templateUrl: './section-courses.component.html',
  styleUrl: './section-courses.component.css'
})
export class SectionCoursesComponent {

  constructor(  @Inject(MAT_DIALOG_DATA) public data: any){}

  ngOnInit() {
    console.log(this.data);
  }
}
