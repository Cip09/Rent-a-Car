import { UserService } from './../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { SenzorReadFile } from '../shared/senzor.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
  userDetails:any;
  array : Array<SenzorReadFile> = new Array<SenzorReadFile>()
  MeasurementValue:any
  TimeStamp:any
  mySenzor : SenzorReadFile;
  _hubConnection : HubConnection
  constructor(private router: Router, private service: UserService) { 
    this._hubConnection = new HubConnectionBuilder()
      .withUrl('https://energyconsumtion.azurewebsites.net/stockChangesHub')        //  https://localhost:44370/stockChangesHub
  .build();
  }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      },
    );
    this._hubConnection.on('UpdateStockClient', (id,message) => {
      console.log(message);
      this.mySenzor = JSON.parse(message);
      this.array.push( this.mySenzor)

      this.MeasurementValue = this.mySenzor.MeasurementValue
      this.TimeStamp = this.mySenzor.TimeStamp
    });
      
    this._hubConnection.start()
  .then(() => console.log('connection started'))
  .catch((err) => console.log('error while establishing signalr connection: ' + err));
  }

}
