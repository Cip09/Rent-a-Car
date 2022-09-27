import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { element } from 'protractor';
import { RentSchedulingModel } from 'src/app/models/rentSchedulingModel';
import { RetreatCarRequestModel } from 'src/app/models/retreatCarRequestModel';

import { SchedulingStatusEnum } from 'src/app/models/scheduling-status-enum';
import { CarService } from 'src/app/service/car.service';
import { RentSchedulingService } from 'src/app/service/rentScheduling.service';

@Component({
  selector: 'app-my-car-details',
  templateUrl: './my-car-details.component.html',
  styleUrls: ['./my-car-details.component.css']
})
export class MyCarDetailsComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private _carService: CarService, private _schedelingService: RentSchedulingService,
    private dialogRef: MatDialogRef<MyCarDetailsComponent>, private toastr: ToastrService) { }

  myCar: any
  showHistory = false
  withdrawCarBool = false
  today = new Date()
  minDate: Date | undefined;
  maxDate: Date | undefined
  maxDateTake: Date | undefined
  totalKmCarTravelInRent = 0

  widthdrawTemporaryGroup: FormGroup = new FormGroup({
    dataStartForm: new FormControl('', Validators.required),
    dataEndForm: new FormControl('', Validators.required),
    reasonForm: new FormControl('')
  })

  widthdrawPermanentGroup: FormGroup = new FormGroup({
    dataPermanentStartForm: new FormControl('', Validators.required),

    reasonPermForm: new FormControl('')
  })

  withdtawCarPermanentBool = false

  historyAproved_displayedColumns: string[] = ['id',  'data', 'dayLate', 'externalDefects', 'moneyPaid', 'returnWarranty', 'kmTraveled'];
  historyAproved_dataSource: Array<any> = new Array<any>()
  historyApproved_dataTable: MatTableDataSource<any> | undefined
  @ViewChild('paginatorApproved') paginatorApproved: MatPaginator | undefined;

  ngOnInit(): void {
    this.myCar = this.data.row
    this.getHistoryCar();

    this.minDate = this.today
    this.widthdrawTemporaryGroup.valueChanges.subscribe(res => {
      this.minDate = new Date(res.dataStartForm);
      this.maxDate = new Date(res.dataStartForm)
      this.maxDate.setDate(this.maxDate.getDate() + 30)
      this.maxDateTake = new Date(res.dataEndForm)
    });
  }

  getHistoryCar() {
    this._carService.getCarHistory(this.myCar.id).subscribe(x => {
      this.historyAproved_dataSource = x.filter(x => x.statusScheduling == SchedulingStatusEnum.SchedulingEnd)

      x.forEach(element =>
        this.totalKmCarTravelInRent = this.totalKmCarTravelInRent + element.kmTraveled
      )
      this.historyApproved_dataTable = new MatTableDataSource(this.historyAproved_dataSource)

      if (this.paginatorApproved)
        this.historyApproved_dataTable.paginator = this.paginatorApproved
    })
  }

  showHistorianSubmit() {
    this.showHistory = true
  }

  withdrawCar() {
    this.withdrawCarBool = true
  }

  slideChange() {
    this.withdtawCarPermanentBool = !this.withdtawCarPermanentBool
    console.log(this.withdtawCarPermanentBool)
  }

  retreatCar(period: string) {
    if (period === 'permanent') {

      let dataStart = new Date(this.widthdrawPermanentGroup.value.dataPermanentStartForm)
      let dataFormat = `${dataStart.getDate()}/${dataStart.getMonth() + 1}/${dataStart.getFullYear()}`

      let requestRetreatCar: RetreatCarRequestModel = {
        starDate: dataStart,
        finishDate: new Date(1, 1, 1),
        startDataFormat: dataFormat,
        finishDataFormat: '',
        schedulingStatus: SchedulingStatusEnum.SchedulingRetreatPermanen,
        car: this.myCar,
        mention: this.widthdrawPermanentGroup.value.reasonPermForm,
        id: 0,
        personRetreat: "Proprietar"
      }

      this._schedelingService.addRequestRetreatCar(requestRetreatCar).subscribe(x => {
        this.toastr.success('Cererea a fost inregistrata cu succes', 'Succes!')
        this.dialogRef.close()
      },
        err => {
          debugger
          this.toastr.error('A aparut o eraore, te rugam sa mai incerci', 'Operatiune esuata.');

        })

    }
    if (period === 'temporary') {
      let dataStart = new Date(this.widthdrawTemporaryGroup.value.dataStartForm)
      let dataStartForm = `${dataStart.getDate()}/${dataStart.getMonth() + 1}/${dataStart.getFullYear()}`

      let dataEnd = new Date(this.widthdrawTemporaryGroup.value.dataEndForm)
      let dataEndFormat = `${dataEnd.getDate()}/${dataEnd.getMonth() + 1}/${dataEnd.getFullYear()}`

      let requestRetreatCar: RetreatCarRequestModel = {
        starDate: dataStart,
        finishDate: dataEnd,
        startDataFormat: dataStartForm,
        finishDataFormat: dataEndFormat,
        schedulingStatus: SchedulingStatusEnum.SchedulingRetreatTemporary,
        car: this.myCar,
        mention: this.widthdrawTemporaryGroup.value.reasonForm,
        id: 0,
        personRetreat: "Proprietar"
      }
      this._schedelingService.addRequestRetreatCar(requestRetreatCar).subscribe(x => {
        this.toastr.success('Cererea a fost inregistrata cu succes', 'Succes!')
        this.dialogRef.close()
      },
        err => {
          debugger
          this.toastr.error('A aparut o eraore, te rugam sa mai incerci', 'Operatiune esuata.');

        })

    }


  }

  cancelRetreat() {
    this.withdrawCarBool = false
  }

}
