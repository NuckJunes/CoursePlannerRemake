export default interface SectionRequestDTO {
    Name: string,
    Credit_Min: number,
    Credit_Max: number,
    MajorId: number,
    CourseIds: Array<number>
}