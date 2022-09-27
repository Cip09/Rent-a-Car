import { EventEmitter, Inject, Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { BehaviorSubject, Observable } from 'rxjs';


export interface Client {
  fullName:string; 
  email:string;
  id:string;
}

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  BaseURI:string;
  constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseURI = baseUrl;
   }
  

  
  updateClient: EventEmitter<any> = new EventEmitter();
  editClient: EventEmitter<any> = new EventEmitter<any>();
  
  addClient(newClient: any){
    return this.http.post(this.BaseURI + 'addClient', newClient);
  }

  editClientRequest(newClient: any, id:string){
    return this.http.put(this.BaseURI + `updateClient/`+id, newClient);
  }

  getClients(): Observable<Client[]>{

    // return this.clientList.asObservable();
    return <Observable<Client[]>> this.http.get(this.BaseURI + 'getClients');
  }

  
  getUserProfile() {
    return this.http.get(this.BaseURI + 'UserProfile');
  }

  deteleClient(id:Number){
    return this.http.delete(this.BaseURI + 'DeleteClient/' +id);
  }
}
