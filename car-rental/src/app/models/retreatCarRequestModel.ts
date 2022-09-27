import { CarModel } from "./carModel";

export interface RetreatCarRequestModel{
    id: number
    starDate: Date,
    finishDate: Date,
    startDataFormat: string,
    finishDataFormat: string,
    schedulingStatus: number,
    personRetreat: string,
    car: CarModel,
    mention: string,
}