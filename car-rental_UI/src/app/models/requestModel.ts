import { CarModel } from "./carModel";

export interface RequestModel{
    id:number,
    response: boolean,
    message: string,
    car: CarModel
}