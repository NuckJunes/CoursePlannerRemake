import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import AccountReturnDTO from "../app/models/AccountReturnDTO";
import CourseResponseDTO from "../app/models/CourseResponseDTO";

@Injectable({
    providedIn: 'root',
})

export class globalData {

    private accountSource = new BehaviorSubject<AccountReturnDTO | undefined>(this.loadAccountFromLocalStorage())
    account = this.accountSource.asObservable();

    private courseSource = new BehaviorSubject<Array<CourseResponseDTO> | undefined>(this.loadCoursesFromLocalStorage());
    courses = this.courseSource.asObservable();

    getAccount() {
        return this.accountSource;
    }

    getCourses() {
        return this.courseSource;
    }

    updateAccountStatus(account: AccountReturnDTO | undefined) {
        this.accountSource.next(account);
        localStorage.setItem('Account', JSON.stringify(account));
    }

    updateCourseStatus(courses: Array<CourseResponseDTO> | undefined) {
        this.courseSource.next(courses);
        localStorage.setItem('Courses', JSON.stringify(courses));
    }

    private loadAccountFromLocalStorage(): AccountReturnDTO|undefined {
        try{
            const accountString = localStorage.getItem('Account');
            return accountString ? JSON.parse(accountString) : undefined;
        } catch(error) {

        }
        return undefined;
    }

    private loadCoursesFromLocalStorage(): Array<CourseResponseDTO> | undefined {
        try {
            const coursesString = localStorage.getItem('Courses');
            return coursesString ? JSON.parse(coursesString) : undefined;
        } catch(error) {

        }
        return undefined;
    }
}