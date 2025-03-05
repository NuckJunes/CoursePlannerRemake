import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import AccountReturnDTO from "../app/models/AccountReturnDTO";
import CourseResponseDTO from "../app/models/CourseResponseDTO";
import ScheduleRequestDTO from "../app/models/ScheduleRequestDTO";

@Injectable({
    providedIn: 'root',
})

export class globalData {

    private accountSource = new BehaviorSubject<AccountReturnDTO | undefined>(this.loadAccountFromLocalStorage())
    account = this.accountSource.asObservable();

    private courseSource = new BehaviorSubject<Array<CourseResponseDTO> | undefined>(this.loadCoursesFromLocalStorage());
    courses = this.courseSource.asObservable();

    private scheduleSource = new BehaviorSubject<ScheduleRequestDTO | undefined>(this.loadScheduleFromLocalStorage());
    schedule = this.scheduleSource.asObservable();

    private scheduleIdSource = new BehaviorSubject<number>(this.loadScheduleIdFromLocalStorage());
    scheduleId = this.scheduleIdSource.asObservable();

    getAccount() {
        return this.accountSource;
    }

    getCourses() {
        return this.courseSource;
    }

    getSchedule() {
        return this.scheduleSource;
    }

    getScheduleId() {
        return this.scheduleIdSource;
    }

    updateAccountStatus(account: AccountReturnDTO | undefined) {
        this.accountSource.next(account);
        localStorage.setItem('Account', JSON.stringify(account));
    }

    updateCourseStatus(courses: Array<CourseResponseDTO> | undefined) {
        this.courseSource.next(courses);
        localStorage.setItem('Courses', JSON.stringify(courses));
    }

    updateScheduleStatus(schedule: ScheduleRequestDTO | undefined) {
        this.scheduleSource.next(schedule);
        localStorage.setItem('Schedule', JSON.stringify(schedule));
    }

    updateScheduleIdStatus(scheduleId: number) {
        this.scheduleIdSource.next(scheduleId);
        localStorage.setItem('ScheduleId', JSON.stringify(scheduleId));
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

    private loadScheduleFromLocalStorage(): ScheduleRequestDTO | undefined {
        try {
            const scheduleString = localStorage.getItem('Schedule');
            return scheduleString ? JSON.parse(scheduleString) : undefined;
        } catch(error) {

        }
        return undefined;
    }

    private loadScheduleIdFromLocalStorage(): number {
        try {
            const scheduleIdString = localStorage.getItem('ScheduleId');
            return scheduleIdString ? Number(scheduleIdString) : -1;
        } catch(error) {

        }
        return -1;
    }
}