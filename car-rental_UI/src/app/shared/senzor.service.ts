import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { EventEmitter } from "@angular/core";

export interface Senzor{
    id: number,
    senzorDescription: string,
    maximumValue: number
}

export interface SenzorReadFile{
  MeasurementValue : number,
  TimeStamp : number

}

@Injectable({
    providedIn: 'root'
  })

 

  export class SenzorServices {
    BaseURI:string;
    constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.BaseURI = baseUrl;
    }

    updateTable: EventEmitter<any> = new EventEmitter();
    editTable: EventEmitter<any> = new EventEmitter();
    addSenzor(newSenzor: any){
        return this.http.post(this.BaseURI+ 'addSmartSenzor', newSenzor);
    }

    getSenzor():Observable<Senzor[]>{
        return <Observable<Senzor[]>> this.http.get(this.BaseURI + 'getSmartSenzor');
    }

    updateSenzor(editSenzor:any, Id:number){
      return this.http.put(this.BaseURI + 'updateSmartSenzor/'+ Id, editSenzor);
     
    }

    deleteSenzor(Id:number){
      return this.http.delete(this.BaseURI + 'deleteSmartSenzor/' + Id);
    }

    

  }
