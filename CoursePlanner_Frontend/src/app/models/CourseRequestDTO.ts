export default interface CourseRequestDTO {
    Name: string,
    Description: string,
    Credit_hours: number,
    Subject: string,
    Course_Number: number,
    FeatureIds: Array<number>,
    CampusIds: Array<number>,
    PreReqIds: Array<number>,
    SectionIds: Array<number>
}