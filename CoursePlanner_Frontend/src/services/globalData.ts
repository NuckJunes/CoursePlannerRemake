import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import AccountReturnDTO from "../app/models/AccountReturnDTO";
import CourseResponseDTO from "../app/models/CourseResponseDTO";
import ScheduleRequestDTO from "../app/models/ScheduleRequestDTO";
import MajorResponseDTO from "../app/models/MajorResponseDTO";
import FeatureDTO from "../app/models/FeatureDTO";
import CampusDTO from "../app/models/CampusDTO";

@Injectable({
    providedIn: 'root',
})

export class globalData {

    private accountSource = new BehaviorSubject<AccountReturnDTO | undefined>(this.loadAccountFromLocalStorage())
    account = this.accountSource.asObservable();

    private courseSource = new BehaviorSubject<Array<CourseResponseDTO>>(this.loadCoursesFromLocalStorage());
    courses = this.courseSource.asObservable();

    private scheduleSource = new BehaviorSubject<ScheduleRequestDTO | undefined>(this.loadScheduleFromLocalStorage());
    schedule = this.scheduleSource.asObservable();

    private scheduleIdSource = new BehaviorSubject<number>(this.loadScheduleIdFromLocalStorage());
    scheduleId = this.scheduleIdSource.asObservable();

    private majorSource = new BehaviorSubject<Array<MajorResponseDTO>>(this.loadMajorFromLocalStorage());
    majors = this.majorSource.asObservable();

    private subjectSource = new BehaviorSubject<Array<String>>(this.loadSubjectFromLocalStorage());
    subjects = this.subjectSource.asObservable();

    private attributeSource = new BehaviorSubject<Array<FeatureDTO>>(this.loadAttributesFromLocalStorage());
    attributes = this.attributeSource.asObservable();

    private campusSource = new BehaviorSubject<Array<CampusDTO>>(this.loadCampusFromLocalStorage());
    campuses = this.campusSource.asObservable();

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

    getMajors() {
        return this.majorSource;
    }

    getSubjects() {
        return this.subjectSource;
    }

    getAttributes() {
        return this.attributeSource;
    }

    getCampuses() {
        return this.campusSource;
    }

    updateAccountStatus(account: AccountReturnDTO | undefined) {
        this.accountSource.next(account);
        localStorage.setItem('Account', JSON.stringify(account));
    }

    updateCourseStatus(courses: Array<CourseResponseDTO>) {
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

    updateMajorStatus(majors: Array<MajorResponseDTO>) {
        this.majorSource.next(majors);
        localStorage.setItem('Majors', JSON.stringify(majors));
    }

    updateSubjectStatus(subjects: Array<String>) {
        this.subjectSource.next(subjects);
        localStorage.setItem('Subjects', JSON.stringify(subjects));
    }

    updateAttributesStatus(attributes: Array<FeatureDTO>) {
        this.attributeSource.next(attributes);
        localStorage.setItem('Attributes', JSON.stringify(attributes));
    }

    updateCampusStatus(campuses: Array<CampusDTO>) {
        this.campusSource.next(campuses);
        localStorage.setItem('Campus', JSON.stringify(campuses));
    }

    private loadAccountFromLocalStorage(): AccountReturnDTO|undefined {
        try{
            const accountString = localStorage.getItem('Account');
            return accountString ? JSON.parse(accountString) : undefined;
        } catch(error) {

        }
        return undefined;
    }

    private loadCoursesFromLocalStorage(): Array<CourseResponseDTO> {
        try {
            const coursesString = localStorage.getItem('Courses');
            return coursesString ? JSON.parse(coursesString) : [];
        } catch(error) {

        }
        return [];
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

    private loadMajorFromLocalStorage(): Array<MajorResponseDTO> {
        try {
            const majorString = localStorage.getItem('Majors');
            return majorString ? JSON.parse(majorString) : [];
        } catch(error) {

        }
        return [];
    }

    private loadSubjectFromLocalStorage(): Array<String> {
        try {
            const subjectString = localStorage.getItem('Subjects');
            return subjectString ? JSON.parse(subjectString) : [];
        } catch(error) {

        }
        return [];
    }

    private loadAttributesFromLocalStorage(): Array<FeatureDTO> {
        try {
            const attributeString = localStorage.getItem('Attributes');
            return attributeString ? JSON.parse(attributeString) : [];
        } catch(error) {

        }
        return [];
    }

    private loadCampusFromLocalStorage(): Array<CampusDTO> {
        try {
            const campusString = localStorage.getItem('Campus');
            return campusString ? JSON.parse(campusString) : [];
        } catch(error) {

        }
        return [];
    }
}