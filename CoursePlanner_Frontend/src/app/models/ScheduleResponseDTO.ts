import ClassDTO from "./ClassDTO"
export default interface ScheduleResponseDTO {
    id: number,
    name: string,
    classes: Array<ClassDTO>
}