import CourseDTO from "./CourseDTO"
export default interface SectionResponseDTO {
    Id: number,
    Name: string,
    Credit_Min: number,
    Credit_Max: number,
    Courses: Array<CourseDTO>,
    Credit_Current: number
}