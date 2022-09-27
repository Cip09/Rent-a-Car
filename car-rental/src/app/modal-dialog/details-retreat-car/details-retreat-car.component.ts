import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CarService } from 'src/app/service/car.service';
import { RentSchedulingService } from 'src/app/service/rentScheduling.service';

@Component({
  selector: 'app-details-retreat-car',
  templateUrl: './details-retreat-car.component.html',
  styleUrls: ['./details-retreat-car.component.css']
})
export class DetailsRetreatCarComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private _carService: CarService,
  private _rentSchedulingService: RentSchedulingService, private _matRef: MatDialogRef<DetailsRetreatCarComponent>) { }

  car: any
  typeModal!: string
  travelKm = 0;
  carHistory: any
  showHistoryBool: any

  historyAproved_displayedColumns: string[] = ['id', 'fullName', 'data', 'dayLate', 'externalDefects', 'moneyPaid', 'returnWarranty', 'kmTraveled'];
  historyAproved_dataSource: Array<any> = new Array<any>()
  historyApproved_dataTable: MatTableDataSource<any> | undefined
  @ViewChild('paginatorApproved') paginatorApproved: MatPaginator | undefined;

  ngOnInit(): void {
    console.log(this.data.row)
    this.typeModal = this.data.typeModal
    this.getCarById(this.data.row.car.id)
    this.getHistoryCar(this.data.row.car.id)
    console.log(this.data.row)
  }

  getCarById(id: any) {
    debugger
    this._carService.getCarDisabledById(id).subscribe(x => {
      this.car = x;
    })
  }

  getHistoryCar(id: any) {
    this._rentSchedulingService.getAllSchedulingHistoryForCar(id).subscribe(x => {

      this.carHistory = x;
      this.carHistory.forEach((element: any) => {
        this.travelKm += element.kmTraveled
      });

      this.historyAproved_dataSource = x
      this.historyApproved_dataTable = new MatTableDataSource(this.historyAproved_dataSource)

      this.historyApproved_dataTable.paginator = this.paginatorApproved!
    })

  }
  showHistory(){
    this.showHistoryBool = !this.showHistoryBool
  }


}
