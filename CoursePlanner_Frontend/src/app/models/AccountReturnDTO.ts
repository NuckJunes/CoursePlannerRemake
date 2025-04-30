import ScheduleResponseDTO from "./ScheduleResponseDTO"
export default interface AccountReturnDTO {
    id: number,
    username: string,
    password: string,
    email: string,
    schedules: Array<ScheduleResponseDTO>
};