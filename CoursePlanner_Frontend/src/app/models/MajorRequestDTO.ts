export default interface MajorRequestDTO {
    Name: string,
    College: string,
    Graduate: boolean,
    Credit_Min: number,
    Credit_Max: number,
    SectionIds: Array<number>
}