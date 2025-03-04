import ClassDTO from "./ClassDTO"
export default interface ScheduleResponseDTO {
    Id: number,
    Name: string,
    Classes: Array<ClassDTO>
}