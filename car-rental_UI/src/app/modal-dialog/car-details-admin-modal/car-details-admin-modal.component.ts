import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { number } from 'card-validator';
import { debug } from 'console';
import { differenceInDays } from 'date-fns';
import { ToastrService } from 'ngx-toastr';
import { RetreatCarRequestModel } from 'src/app/models/retreatCarRequestModel';
import { SchedulingStatusEnum } from 'src/app/models/scheduling-status-enum';
import { UpdateCarModel } from 'src/app/models/updateCarModel';
import { RequestRetreatCarComponent } from 'src/app/request-retreat-car/request-retreat-car.component';
import { CarService } from 'src/app/service/car.service';
import { RentSchedulingService } from 'src/app/service/rentScheduling.service';
import { RetreaCarModalComponent } from '../retrea-car-modal/retrea-car-modal.component';

@Component({
  selector: 'app-car-details-admin-modal',
  templateUrl: './car-details-admin-modal.component.html',
  styleUrls: ['./car-details-admin-modal.component.css']
})
export class CarDetailsAdminModalComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private _carService: CarService,
    private _rentSchedulingService: RentSchedulingService, private _matRef: MatDialogRef<RetreaCarModalComponent>, private toastr: ToastrService) { }
  car: any
  typeModal!: string
  travelKm = 0;
  carHistory: any
  serviceDate = ""
  showHistoryBool = false;
  showEditModalBool = false
  minDateKm !: Date
  retreatCarBool = false;
  today = new Date()


  updateGroup: FormGroup = new FormGroup({
    newServiceData: new FormControl(''),
    newServiceKm: new FormControl('', [Validators.pattern('^[0-9]*$')]),
    newKm: new FormControl('', [Validators.pattern('^[0-9]*$')]),
    newITPData: new FormControl('')
  })

  retreatCarGroup: FormGroup = new FormGroup({
    startDataRetreatForm: new FormControl('', Validators.required),
    mentionRetreatForm: new FormControl('', Validators.required)
  })


  historyAproved_displayedColumns: string[] = ['id', 'fullName', 'data', 'dayLate', 'externalDefects', 'moneyPaid', 'returnWarranty', 'kmTraveled'];
  historyAproved_dataSource: Array<any> = new Array<any>()
  historyApproved_dataTable: MatTableDataSource<any> | undefined
  @ViewChild('paginatorApproved') paginatorApproved: MatPaginator | undefined;

  ngOnInit(): void {

    this.typeModal = this.data.typeModal
    this.getCarById(this.data.row.id)
    this.getHistoryCar(this.data.row.id)
  }

  differentceITP(expireITP: any){
    var dif = differenceInDays(new Date(expireITP?.itp), this.today)
    return dif;
  }

  getCarById(id: any) {

    this._carService.getCarById(id).subscribe(x => {
      this.car = x;

      let data = new Date(this.car.lastServicesData)
      this.serviceDate = `${data.getDate()}/${data.getMonth() + 1}/${data.getFullYear()}`
      this.minDateKm = new Date(this.car.lastServicesData)
    })
  }

  getHistoryCar(id: any) {
    this._rentSchedulingService.getSchedulingHistoryForCar(id).subscribe(x => {

      this.carHistory = x;
      this.carHistory.forEach((element: any) => {
        this.travelKm += element.kmTraveled
      });

      this.historyAproved_dataSource = x.filter(x => x.statusScheduling == SchedulingStatusEnum.SchedulingEnd)
      this.historyApproved_dataTable = new MatTableDataSource(this.historyAproved_dataSource)

      this.historyApproved_dataTable.paginator = this.paginatorApproved!
    })

  }

  showEditModal() {
    this.showEditModalBool = !this.showEditModalBool
  }

  showHistory() {
    this.showHistoryBool = !this.showHistoryBool;
  }

  sendEditCar() {

    let data = new Date(0)
    let dateITP = new Date(0)

    if (this.updateGroup.value.newServiceData != "") {
      data = new Date(this.updateGroup.value.newServiceData);
    }
    if(this.updateGroup.value.newITPData)
      dateITP = new Date(this.updateGroup.value.newITPData)
    

    // if(  this.updateGroup.value.newServiceKm != " ")
    var KmService: number = this.updateGroup.value.newServiceKm

    let NewKmCar: number = this.updateGroup.value.newKm

    let newCar: UpdateCarModel = {
      newServiceDate: data as Date,
      newKmService: Number(KmService),
      newCarKm: Number(NewKmCar),
      newITP: dateITP,
    }
    debugger
    this._carService.updeteCar(this.car.id, newCar).subscribe(x => {

      this.toastr.success('Datele masinii au fost editate', 'Succes!')
      this._matRef.close();
    })
  }

  retreatCar() {
    console.log("retraet Car")
    this.retreatCarBool = !this.retreatCarBool
  }

  retreatCarRequest() {
    let dataStart = new Date(this.retreatCarGroup.value.startDataRetreatForm)
    let dataStartFormat = `${dataStart.getDate()}/${dataStart.getMonth() + 1}/${dataStart.getFullYear()}`
    let requestRetreatCar: RetreatCarRequestModel = {
      starDate: new Date(this.retreatCarGroup.value.startDataRetreatForm),
      finishDate: new Date(0),
      startDataFormat: dataStartFormat,
      finishDataFormat: '',
      schedulingStatus: SchedulingStatusEnum.SchedulingRetreatPermanentApproved,
      car: this.car,
      mention: this.retreatCarGroup.value.mentionRetreatForm,
      id: 0,
      personRetreat: "Admin"
    }

    this._rentSchedulingService.addRequestRetreatCar(requestRetreatCar).subscribe(x => {
      this.toastr.success('Masina a fost retrasa cu succes', 'Succes!')
      this._matRef.close()
    },
      err => {

        this.toastr.error('A aparut o eraore, te rugam sa mai incerci', 'Operatiune esuata.');

      })

  }

}
