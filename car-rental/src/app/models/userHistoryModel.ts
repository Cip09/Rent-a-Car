export interface UserHistoryModel{
    id: number,
    fullNameClient: string,
    brandCar: string,
    modelCar: string,
    dayNumber: number,
    statusScheduling: number,

    declineReason: string,
    kmTraveled: number,
    startData: string,
    endData: string,
    moneyPaid: number,

    dayLate:number,
    externalDefects: boolean,
    internalDefects: boolean,
    returnWarranty: boolean,
    mention: string,


    carId: number,
    schedulingId: number,
    clientId: string
}


