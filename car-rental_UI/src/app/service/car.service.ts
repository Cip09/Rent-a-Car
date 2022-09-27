import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { CarModel } from "../models/carModel";
import { FilterModel } from "../models/filterModel";
import { RentSchedulingModel } from "../models/rentSchedulingModel";
import { UpdateCarModel } from "../models/updateCarModel";
import { UserHistoryModel } from "../models/userHistoryModel";

@Injectable({
    providedIn: 'root'
  })
export class CarService {
    BaseURI:string;
    constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.BaseURI = baseUrl;
    }

    getUserCar(){
        return this.http.get<[CarModel]>(this.BaseURI + 'Car' + '/getCarsById');
    }

    getAllCar(){
      return this.http.get<[CarModel]>(this.BaseURI + 'Car' + '/getAllCars')
    }

    getCarById(id:number){
      return this.http.get<CarModel>(this.BaseURI + 'Car' + '/getCarById/' + id )
    }

    getCarDisabledById(id:number){
      return this.http.get<CarModel>(this.BaseURI + 'Car' + '/getDisabledById/' + id)
    }

    getCarHistory(id: number){
      return this.http.get<[UserHistoryModel]>(this.BaseURI + 'Car' + '/getCarHistory/' +  id )
    }

    getActivCarForAdmin(){
      return this.http.get<[CarModel]>(this.BaseURI + 'Car' + '/getActivCarForAdmin')
    }

    getRetreatCarList(){
      return this.http.get<[RentSchedulingModel]>(this.BaseURI + 'Car' + '/getRetreatCarList')
    }

    getDisabledCarList(){
      return this.http.get<[RentSchedulingModel]>(this.BaseURI + 'Car' + '/getDisabledCarList')
    }

    updeteCar(idCar: number, newCar : UpdateCarModel){
      return this.http.post(this.BaseURI + 'Car' + '/updateCar/' + idCar, newCar)
    }

    postFilter(filters: FilterModel){
      return this.http.post<Array<CarModel>>(this.BaseURI + 'Car' + '/filter', filters)
    }

    getRecommendedCar(){
      return this.http.get<Array<CarModel>>(this.BaseURI + 'Car' + '/getRecommendedCar')
    }
}