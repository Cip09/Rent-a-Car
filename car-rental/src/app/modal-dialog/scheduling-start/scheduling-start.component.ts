import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SchedulingStatusEnum } from 'src/app/models/scheduling-status-enum';
import { UserHistoryModel } from 'src/app/models/userHistoryModel';
import { RentSchedulingService } from 'src/app/service/rentScheduling.service';


@Component({
  selector: 'app-scheduling-start',
  templateUrl: './scheduling-start.component.html',
  styleUrls: ['./scheduling-start.component.css']
})
export class SchedulingStartComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private _rentSchedulingService: RentSchedulingService){ }


  mentionGroup:  FormGroup = new FormGroup({
    mentionForm: new FormControl('', Validators.required)
  })

  
  refuseReson = false
  dataServiceCarFormat!: string
  schedulingStart: any



  ngOnInit(): void {
    this.schedulingStart = this.data.row
    let data = new Date(this.schedulingStart.car.lastServicesData)
  
    this.dataServiceCarFormat = `${data.getDate()}/${data.getMonth() + 1}/${data.getFullYear()}`
 
  }

  onSubmitStartRent(clientResponse: boolean){
    if(clientResponse == true){
      this._rentSchedulingService.updatetatusScheduling(this.schedulingStart.id, SchedulingStatusEnum.SchedulingStart).subscribe(x =>{
        //refresh la tablea
      })
    }
    if(clientResponse == false){
      this.refuseReson = true
    }
  }

  submitRefusReson(response :boolean){
    if(response == true){
      let history : UserHistoryModel ={
        id: 0,
        fullNameClient: this.schedulingStart.completName,
        brandCar: this.schedulingStart.car.carBrand,
        modelCar: this.schedulingStart.car.modelCar,
        dayNumber: 0,
        statusScheduling: SchedulingStatusEnum.SchedulingDecline,
        mention: '',
        declineReason: this.mentionGroup.value.mentionForm,
        kmTraveled: 0,
        startData: '',
        endData: '',
        moneyPaid: 0,
        schedulingId: this.schedulingStart.id,
        carId: this.schedulingStart.car.id,
        clientId: this.schedulingStart.client.id,
        dayLate: 0,
        externalDefects: false,
        internalDefects: false,
        returnWarranty: false,
        
      }
      this._rentSchedulingService.addSchedulingByUser(history).subscribe(x =>{
        //refresh la tabele
      })
      
    }
    if(response == false){

      this.refuseReson = false
    }
  }

}
