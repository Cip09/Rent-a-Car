import { HttpClient } from "@angular/common/http";
import { EventEmitter, Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

export interface Device {
    id:number;
    description: string;
    location: string;
    maxEnergyConsumtion: number;
    baselineEnergyConsumtion: number;
   
  }
  
  @Injectable({
    providedIn: 'root'
  })

  

  export class DeviceServices {
    BaseURI:string;
    constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.BaseURI = baseUrl;
     }

     updateDeviceOnSubmit: EventEmitter<any> = new EventEmitter();
     editDeviceOnEdit: EventEmitter<any> = new EventEmitter<any>();

     addDevice(newDevice:any){
        return this.http.post(this.BaseURI + 'addSmartDevice', newDevice);

     }

     getDevices(): Observable<Device[]> {
       return <Observable<Device[]>> this.http.get(this.BaseURI + 'getSmartDevice');
     }

     editDevice(editDevice:any, Id: number){
        return this.http.put(this.BaseURI + 'updateSmartDevice/' + Id, editDevice);
     }

     deleteDevice(Id:number){
       return this.http.delete(this.BaseURI + 'deleteSmartDevice/'+ Id);
     }

}
