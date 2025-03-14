import SectionResponseDTO from "./SectionResponseDTO"
export default interface MajorResponseDTO {
    Id: number,
    Name: string,
    College: string,
    Graduate: boolean,
    Credit_Min: number,
    Credit_Max: number,
    Sections: Array<SectionResponseDTO>
}