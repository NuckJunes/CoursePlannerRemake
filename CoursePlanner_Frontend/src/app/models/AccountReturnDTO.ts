import ScheduleResponseDTO from "./ScheduleResponseDTO"
export default interface AccountReturnDTO {
    Id: number,
    Username: string,
    Password: string,
    Email: string,
    Schedules: Array<ScheduleResponseDTO>
};