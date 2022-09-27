import {  Inject, Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { RequestModel } from '../models/requestModel';




@Injectable({
    providedIn: 'root'
  })
export class RequestService {
    BaseURI:string;
    constructor( private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.BaseURI = baseUrl;
     }

    addRequest(request:FormData){
        return this.http.post(this.BaseURI + 'Request' +'/addRequest', request);
    }

    getRequest(){
      return this.http.get<[RequestModel]>(this.BaseURI + 'Request' + '/getAllRequest');
    }

    responseRequest(id:number, reponse: boolean){
      return this.http.post(this.BaseURI + 'Request' +'/response/' + id, reponse)
    }

}