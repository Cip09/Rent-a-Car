import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ConsoleLogger } from '@microsoft/signalr/dist/esm/Utils';
import { RentSchedulingService } from 'src/app/service/rentScheduling.service';

@Component({
  selector: 'app-retrea-car-modal',
  templateUrl: './retrea-car-modal.component.html',
  styleUrls: ['./retrea-car-modal.component.css']
})
export class RetreaCarModalComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private _rentSchedulingService: RentSchedulingService, private _matRef: MatDialogRef<RetreaCarModalComponent>) { }

  typeModal!: string
  car: any

  nextScheduling_displayedColumns: string[] = ['id', 'fullName', 'phone', 'dataInterval'];
  nextScheduling_dataSource: Array<any> = new Array<any>()
  dataTable = new MatTableDataSource()

  @ViewChild('paginatorPermanent') paginator: MatPaginator | undefined;

  ngOnInit(): void {
    this.typeModal = this.data.typeModal
    this.car = this.data.row.car
    this.getSchedulingCar();
  }

  group: FormGroup = new FormGroup({
    takeDataForm: new FormControl('')
  })

  getSchedulingCar() {
    if (this.typeModal === 'temporary') {
      this._rentSchedulingService.getSchedulingCarForRetreat(this.car.id, this.data.row.starDate, this.data.row.finishDate).subscribe(x => {

        this.nextScheduling_dataSource = x
        this.dataTable = new MatTableDataSource(this.nextScheduling_dataSource)
        this.dataTable.paginator = this.paginator!

      })
    }
    if(this.typeModal === 'permanent'){
      this._rentSchedulingService.getSchedulingCarForRetreatPermanent(this.car.id, this.data.row.starDate).subscribe(x =>{
        this.nextScheduling_dataSource = x
        this.dataTable = new MatTableDataSource(this.nextScheduling_dataSource)
        this.dataTable.paginator = this.paginator!

      })
    }
  }

  responseRequest(response : boolean){
    this._rentSchedulingService.responseRequestRetreatCar(this.data.row.id, this.typeModal, response).subscribe(x =>{
      this._matRef.close();
    })

  }

}
