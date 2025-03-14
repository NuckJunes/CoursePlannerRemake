import CourseDTO from "./CourseDTO"
export default interface SectionResponseDTO {
    Name: string,
    Credit_Min: number,
    Credit_Max: number,
    Courses: Array<CourseDTO>
}