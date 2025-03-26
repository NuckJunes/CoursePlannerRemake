export default interface CourseRequestDTO {
    Name: string,
    Description: string,
    Credit_hours: number,
    Subject: string,
    Course_Number: number,
    PreRequisites: string,
    FeatureIds: Array<number>,
    CampusIds: Array<number>,
    SectionIds: Array<number>
}