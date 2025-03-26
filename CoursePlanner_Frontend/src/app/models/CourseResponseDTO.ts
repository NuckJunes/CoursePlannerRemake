import CampusDTO from "./CampusDTO";
import FeatureDTO from "./FeatureDTO";
import PrereqDTO from "./PrereqDTO";

export default interface CourseResponseDTO {
    Id: number,
    Name: string,
    Description: string,
    Credit_hours: number,
    Subject: string,
    Course_Number: number,
    FeatureDTOs: Array<FeatureDTO>,
    CampusDTOs: Array<CampusDTO>,
    SectionIds: Array<number>,
    PreRequisites: string
}