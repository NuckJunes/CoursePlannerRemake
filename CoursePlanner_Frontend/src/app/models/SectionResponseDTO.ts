import CourseDTO from "./CourseDTO"
export default interface SectionResponseDTO {
    id: number,
    name: string,
    credit_Min: number,
    credit_Max: number,
    courses: Array<CourseDTO>,
    credit_Current: number
}