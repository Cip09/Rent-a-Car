import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { differenceInDays } from 'date-fns';
import { element } from 'protractor';
import { CarModel } from 'src/app/models/carModel';
import { RequestModel } from 'src/app/models/requestModel';
import { RequestListComponent } from 'src/app/request-list/request-list.component';
import { RequestService } from 'src/app/service/request.service';

@Component({
  selector: 'app-request-modal',
  templateUrl: './request-modal.component.html',
  styleUrls: ['./request-modal.component.css']
})
export class RequestModalComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private requestServices: RequestService, private dialogRef: MatDialogRef<RequestModalComponent>) { }

  categoryCar: string[] = []

  requestAddCar !: RequestModel
  car !: CarModel
  lastServiceDataFormat: any

 
  ngOnInit(): void {
    this.requestAddCar = this.data.row
    this.car = this.data.row.carDTO
    let data = new Date(this.data.row.carDTO.lastServicesData)
    this.lastServiceDataFormat = `${data.getDate()}/${data.getMonth()+ 1}/${data.getFullYear()}`

  }

  rejectRequest(){
   this.requestServices.responseRequest(this.data.row.id, false).subscribe(x => {
     this.close()
   })
  }

  aproveRequest(){
    this.requestServices.responseRequest(this.data.row.id, true).subscribe(x => {
      this.close()
    })
  }

  close(responseBool = true){
    this.dialogRef.close(responseBool);
  }

  differentceITP(expireITP: any){
    var dif = differenceInDays(new Date(expireITP?.itp), new Date())
    return dif;
  }

}
