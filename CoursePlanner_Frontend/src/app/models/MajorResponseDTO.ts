import SectionResponseDTO from "./SectionResponseDTO"
export default interface MajorResponseDTO {
    id: number,
    name: string,
    college: string,
    graduate: boolean,
    credit_Min: number,
    credit_Max: number,
    sections: Array<SectionResponseDTO>
}