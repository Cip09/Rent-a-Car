import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { CarModel } from "../models/carModel";
import { RentSchedulingModel } from "../models/rentSchedulingModel";
import { RetreatCarRequestModel } from "../models/retreatCarRequestModel";

import { UserHistoryModel } from "../models/userHistoryModel";

@Injectable({
    providedIn: 'root'
  })
export class RentSchedulingService {
    BaseURI:string;
    constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.BaseURI = baseUrl;
    }

    addRentScheduling(rent: any){
      return this.http.post(this.BaseURI + 'RentScheduling' + '/addRentScheduling/', rent);
    }

    getRequestScheduling(){
      return this.http.get<[RentSchedulingModel]>(this.BaseURI + 'RentScheduling' + '/getRequestScheduling')
    }

    responseRequestSecheduling(id:number, response:boolean){
      return this.http.post(this.BaseURI + 'RentScheduling' +'/response/' + id, response)
    }

    getSchedulingApproved(){
      return this.http.get<[RentSchedulingModel]>(this.BaseURI + 'RentScheduling' + '/getSchedulingApproved')
    }

    getSchedulingStart(){
      return this.http.get<[RentSchedulingModel]>(this.BaseURI + 'RentScheduling' + '/getSchedulingStart')
    }

    updatetatusScheduling(id : number, status: number){
      return this.http.post(this.BaseURI + 'UserHistory' + '/updateStatus/' + id, status)
    }

    addSchedulingByUser(history : any){
      return this.http.post(this.BaseURI + 'UserHistory' + '/addHistory', history)
    }

    getHistoryClient(id : number){
      return this.http.get<[UserHistoryModel]>(this.BaseURI + 'UserHistory' + '/getUserHistory/'  + id)
    }

    addRequestRetreatCar(request: RetreatCarRequestModel){
      return this.http.post(this.BaseURI + 'RentScheduling'+ '/retreatRequest',request)
    }

    getRequestRetreatCarTemporary(){
      return this.http.get<[RetreatCarRequestModel]>(this.BaseURI + 'RentScheduling' + '/getRetreatTemporaryRequest')
    }

    getRequestRetreatCarPermanent(){
      return this.http.get<[RetreatCarRequestModel]>(this.BaseURI + 'RentScheduling' + '/getRetreatPermanentRequest')
    }

    getSchedulingCarForRetreat(idCar: number, startDate: Date, endDate: Date){
      return this.http.get<[RentSchedulingModel]>(this.BaseURI + 'RentScheduling' + '/getSchedulingRetreatCar/' + idCar +'/' + startDate +'/'+ endDate)
    }
    
    getSchedulingCarForRetreatPermanent(idCar: number, startDate: Date){
      return this.http.get<[RentSchedulingModel]>(this.BaseURI + 'RentScheduling' + '/getSchedulingRetreatPermanent/' + idCar + '/' + startDate)
    }

    responseRequestRetreatCar(idRequest: number, typeRetreat: string, response: boolean){
      return this.http.post(this.BaseURI + 'RentScheduling' + '/responseRetreatCar/' + idRequest + '/' +typeRetreat, response) 
    }

    getSchedulingHistoryForCar(idCar:number){
      return this.http.get<[UserHistoryModel]>(this.BaseURI + 'RentScheduling' + '/getRentHistoryCar/' + idCar);
    }

    getAllSchedulingHistoryForCar(idCar:number){
      return this.http.get<[UserHistoryModel]>(this.BaseURI + 'RentScheduling' + '/getAllRentHistoryCar/' + idCar);
    }
    

}




