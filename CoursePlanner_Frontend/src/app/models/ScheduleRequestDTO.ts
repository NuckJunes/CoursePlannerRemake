import ClassInsertDTO from "./ClassInsertDTO";
export default interface ScheduleRequestDTO {
    Name: string,
    Classes: Array<ClassInsertDTO>
}