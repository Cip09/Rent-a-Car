import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SchedulingStatusEnum } from 'src/app/models/scheduling-status-enum';
import { UserHistoryModel } from 'src/app/models/userHistoryModel';
import { RentSchedulingService } from 'src/app/service/rentScheduling.service';

@Component({
  selector: 'app-scheduling-end',
  templateUrl: './scheduling-end.component.html',
  styleUrls: ['./scheduling-end.component.css']
})
export class SchedulingEndComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,  private _rentSchedulingService : RentSchedulingService) { }

  dayLateBool = false
  externalDefectsBool = false
  internalDefectsBool = false
  returnWarrantyBool = false
  kmTravel2 = 2
  numar : number = 0
 
  userHistoryGroup: FormGroup = new FormGroup({
    dayDelayForm: new FormControl(''),
    kmTraveledForm: new FormControl('', Validators.required),
    mentionForm: new FormControl('')
  })

  schedulingEnd: any

  ngOnInit(): void {
    this.schedulingEnd = this.data.row
  }

  dayLate(){
    
    console.log(this.userHistoryGroup.value.dayDelayForm)
    this.dayLateBool = !this.dayLateBool
  }

  externalDefects(event : any){
    if(event.value == 'true'){
      this.externalDefectsBool = true
    } 
    if(event.value == 'false'){
      this.externalDefectsBool = false
    }
   
  }

  internalDefects(event : any){
    
    if(event.value == 'true'){
      this.internalDefectsBool = true
    } 
    if(event.value == 'false'){
      this.internalDefectsBool = false
    }
  }
  returnWarranty(event : any){
    if(event.value == 'true'){
      this.returnWarrantyBool = true
    } 
    if(event.value == 'false'){
      this.returnWarrantyBool = false
    }
  }

  onSubmitEndRent(response: any){

    var kmTravelNumber: number = + this.userHistoryGroup.value.kmTraveledForm
    let dayLateNumber: number = + this.userHistoryGroup.value.dayDelayForm 

    console.log(typeof(kmTravelNumber))
    if(response == true){
      let history : UserHistoryModel ={
        id: 0,
        fullNameClient: this.schedulingEnd.completName,
        brandCar: this.schedulingEnd.car.carBrand,
        modelCar: this.schedulingEnd.car.modelCar,
        dayNumber: this.schedulingEnd.numberOfDay,
        statusScheduling: SchedulingStatusEnum.SchedulingEnd,
        mention: this.userHistoryGroup.value.mentionForm,
        declineReason: '',
        kmTraveled: kmTravelNumber as number,
        startData: this.schedulingEnd.startDataFormat,
        endData: this.schedulingEnd.finishDataFormat,
        moneyPaid: this.schedulingEnd.totalPrice,
        schedulingId: this.schedulingEnd.id,
        carId: this.schedulingEnd.car.id,
        clientId: this.schedulingEnd.client.id,
         dayLate: dayLateNumber as number,
        externalDefects: this.externalDefectsBool ,
        internalDefects: this.internalDefectsBool ,
        returnWarranty: this.returnWarrantyBool ,

      }
      
      this._rentSchedulingService.addSchedulingByUser(history).subscribe(x =>{
        //refresh la tabele
      })
      console.log(history)
    }
  }

}
