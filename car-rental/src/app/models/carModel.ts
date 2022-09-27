import { CategoryCar } from "./categoryCar";
import { UserModel } from "./userModel";

export interface CarModel{
    id:number | undefined,
    carBrand: string,
    modelCar: string,
    colorCar: string,
    doorNumbers: number,
    seatNumbers: number,
    carKm: number,
    lastServicesData: Date,
    lastServicesDataFormat: string,
    lastServicesKm: number,
    itp: Date,
    itpFormat: string,
    categotyCar : CategoryCar[],
    carOwner : UserModel,
    activeFlag: boolean,
    engine: string,
    year: number,
    fuel: string,
    fuelConsumption: number,
    traction: string,
    pricePerDay: number,
    gearBox: string,
    enginePower: number,
    climate: boolean,
    navigation: boolean,
    boardComputer: boolean,
    retreatTemporary: boolean,
    base64Image:string

    //user: User
    //rentSchedulingCarLists : RentSchedulingCar
}




