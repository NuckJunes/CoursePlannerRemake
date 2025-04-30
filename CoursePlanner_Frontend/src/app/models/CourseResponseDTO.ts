import CampusDTO from "./CampusDTO";
import FeatureDTO from "./FeatureDTO";
import PrereqDTO from "./PrereqDTO";

export default interface CourseResponseDTO {
    id: number,
    name: string,
    description: string,
    credit_hours: number,
    subject: string,
    course_Number: number,
    featureDTOs: Array<FeatureDTO>,
    campusDTOs: Array<CampusDTO>,
    sectionIds: Array<number>,
    preRequisites: string
}