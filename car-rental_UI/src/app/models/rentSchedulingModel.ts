import { CarModel } from "./carModel";
import { UserModel } from "./userModel";

export interface RentSchedulingModel{
    id: number
    starDate: Date,
    mention:string
     finishDate: Date,
     totalPrice: number,
     takeLocation: string,
     returnLocation: string,
     numberOfDay: number,
     takeTime: string,
     returnTime: string,
     completName: string,
    address: string,
    phoneNumber: string,
    gps: boolean,
    childSeatOption: boolean,
    windshieldFluid: boolean,
    snowChains: boolean,
    payMethod: string,
    startDataFormat: string,
    finishDataFormat: string,
    schedulingStatus : number,
    car: CarModel | undefined,
    client: UserModel | undefined,
    
}



