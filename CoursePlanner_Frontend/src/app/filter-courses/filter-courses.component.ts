import { Component, inject } from '@angular/core';
import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { ScheduleCreateEditComponent } from '../schedule-create-edit/schedule-create-edit.component';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormControl, ReactiveFormsModule, FormsModule, FormGroup } from '@angular/forms';
import { globalData } from '../../services/globalData';
import { MatInputModule } from '@angular/material/input';


@Component({
  selector: 'app-filter-courses',
  imports: [MatDialogModule, MatSelectModule, MatFormFieldModule, ReactiveFormsModule, FormsModule, MatInputModule],
  templateUrl: './filter-courses.component.html',
  styleUrl: './filter-courses.component.css'
})
export class FilterCoursesComponent {

  readonly dialogRef = inject(MatDialogRef<ScheduleCreateEditComponent>);

  fullForm = new FormGroup({
    subjectSelected: new FormControl([]),
    attributeSelected: new FormControl([]),
    campusSelected: new FormControl([]),
    min: new FormControl(0),
    max: new FormControl(1000)
  });

  subjects: Array<String> = ["CSE", "CEC"];
  attribute: Array<String> = ["AA", "BP"];
  campus: Array<String> = ["Oxford", "Hamilton"];


  constructor(private globalData: globalData) {}

  // Obtain all subjects/attributes/campuses from db
  ngOnInit() {
    // Check for global data, then localstorage, otherwise pull from db

    // this.globalData.getSubjects().subscribe((value) => {
    //   if(value !== undefined) {
    //     this.subjects = value;
    //   } else {
    //     let tmp = localStorage.getItem('Subjects');
    //     if(tmp === null) {
    //       // Call API Here
    //     } else {
    //       this.subjects = JSON.parse(tmp);
    //     }
    //   }
    // });

    // this.globalData.getAttributes().subscribe((value) => {
    //   if(value !== undefined) {
    //     this.attribute = value;
    //   } else {
    //     let tmp = localStorage.getItem('Attributes');
    //     if(tmp === null) {
    //       // Call API Here
    //     } else {
    //       this.subjects = JSON.parse(tmp);
    //     }
    //   }
    // });

    // this.globalData.getCampuses().subscribe((value) => {
    //   if(value !== undefined) {
    //     this.campus = value;
    //   } else {
    //     let tmp = localStorage.getItem('Campus');
    //     if(tmp === null) {
    //       // Call API Here
    //     } else {
    //       this.subjects = JSON.parse(tmp);
    //     }
    //   }
    // });
  }

  // When x button is clicked, no data sent back
  close() {
   this.dialogRef.close();
  }

  // When filter button is clicked, sends filter data back
  // @Return Object {} returns an object with specific filter options in it
  filterReturn() {
    this.dialogRef.close({
      subjects: this.fullForm.get('subjectSelected'),
      attributes: this.fullForm.get('attributeSelected'),
      campuses: this.fullForm.get('campusSelected'),
      min: this.fullForm.get('min'),
      max: this.fullForm.get('max')
    });
  }
}
