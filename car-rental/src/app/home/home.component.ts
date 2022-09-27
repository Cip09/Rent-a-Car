import { UserService } from '../service/user.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
// import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { SenzorReadFile } from '../shared/senzor.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { AppComponent } from '../app.component';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userDetails:any;
  array : Array<SenzorReadFile> = new Array<SenzorReadFile>()
  MeasurementValue:any
  TimeStamp:any
  mySenzor? : SenzorReadFile;
  showChangePassord = false;
  showChangeName= false
  changeEmail =  false;

  schedulingList_displayedColumns: string[] = ['id','typeRequest', 'data','response'];
  schedulingList_dataSource: Array<any> = new Array<any>()
  schedulingList_dataTable = new MatTableDataSource()

  @ViewChild('paginator') paginator: MatPaginator | undefined;


  // _hubConnection : HubConnection
  constructor(private router: Router, private service: UserService, private _appComponent: AppComponent) { 
  //   this._hubConnection = new HubConnectionBuilder()
  //     .withUrl('https://energyconsumtion.azurewebsites.net/stockChangesHub')        //  https://localhost:44370/stockChangesHub
  // .build();
  }

  ngOnInit() {
    this.getAllAlet();
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      },
    );
  //   this._hubConnection.on('UpdateStockClient', (id,message) => {
  //     console.log(message);
  //     this.mySenzor = JSON.parse(message);
  //     this.array.push( this.mySenzor!)

  //     this.MeasurementValue = this.mySenzor!.MeasurementValue
  //     this.TimeStamp = this.mySenzor!.TimeStamp
  //   });
      
  //   this._hubConnection.start()
  // .then(() => console.log('connection started'))
  // .catch((err) => console.log('error while establishing signalr connection: ' + err));
  }

  showPassowrd(){
    this.showChangePassord = true;
  }

  changePassord(){
    console.log("Modifica parola")
  }

  showModalChangeName(){
    this.showChangeName = true;
  }

  changeFullName(){

  }

  showChangeEmail(){
    this.changeEmail = true;
  }

  changeEmailFunc(){
    console.log("change emailar")
  }

 

  getAllAlet(){
    
    this.service.getAllAlrt().subscribe(x=>{
      this.schedulingList_dataSource = x;
      this.schedulingList_dataTable = new MatTableDataSource(this.schedulingList_dataSource)
      this.schedulingList_dataTable.paginator = this.paginator!
      
      //this._appComponent.getAlet()
    })
  }

}
