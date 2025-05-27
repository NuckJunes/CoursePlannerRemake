import ClassDTO from "./ClassDTO";
export default interface ScheduleRequestDTO {
    Name: string,
    Classes: Array<ClassDTO>
}