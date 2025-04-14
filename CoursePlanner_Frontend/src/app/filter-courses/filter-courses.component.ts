import { Component, inject } from '@angular/core';
import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { ScheduleCreateEditComponent } from '../schedule-create-edit/schedule-create-edit.component';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormControl, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { globalData } from '../../services/globalData';


@Component({
  selector: 'app-filter-courses',
  imports: [MatDialogModule, MatSelectModule, MatFormFieldModule, ReactiveFormsModule, FormsModule],
  templateUrl: './filter-courses.component.html',
  styleUrl: './filter-courses.component.css'
})
export class FilterCoursesComponent {

  readonly dialogRef = inject(MatDialogRef<ScheduleCreateEditComponent>);

  subjects: Array<String> = [];
  subjectSelected = new FormControl([]);
  attribute: Array<String> = [];
  attributeSelected = new FormControl([]);
  campus: Array<String> = [];
  campusSelected = new FormControl([]);
  min = 0;
  max = 1000;

  constructor(private globalData: globalData) {}

  // Obtain all subjects/attributes/campuses from db
  ngOnInit() {
    // Check for global data, then localstorage, otherwise pull from db

    this.globalData.getSubjects().subscribe((value) => {
      if(value !== undefined) {
        this.subjects = value;
      } else {
        let tmp = localStorage.getItem('Subjects');
        if(tmp === undefined) {
          // Call API Here
        }
      }
    });

    this.globalData.getAttributes().subscribe((value) => {
      if(value !== undefined) {
        this.attribute = value;
      } else {
        let tmp = localStorage.getItem('Attributes');
        if(tmp === undefined) {
          // Call API Here
        }
      }
    });

    this.globalData.getCampuses().subscribe((value) => {
      if(value !== undefined) {
        this.attribute = value;
      } else {
        let tmp = localStorage.getItem('Campus');
        if(tmp === undefined) {
          // Call API Here
        }
      }
    });
  }

  // When x button is clicked, no data sent back
  close() {
   this.dialogRef.close();
  }

  // When filter button is clicked, sends filter data back
  // @Return Object {} returns an object with specific filter options in it
  filterReturn() {
    this.dialogRef.close({
      subjects: this.subjectSelected,
      attributes: this.attributeSelected,
      campuses: this.campusSelected,
      min: this.min,
      max: this.max
    });
  }
}
