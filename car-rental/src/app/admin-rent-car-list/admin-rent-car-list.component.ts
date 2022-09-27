import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { differenceInDays } from 'date-fns';
import { CarDetailsAdminModalComponent } from '../modal-dialog/car-details-admin-modal/car-details-admin-modal.component';
import { DetailsRetreatCarComponent } from '../modal-dialog/details-retreat-car/details-retreat-car.component';
import { CarService } from '../service/car.service';

@Component({
  selector: 'app-admin-rent-car-list',
  templateUrl: './admin-rent-car-list.component.html',
  styleUrls: ['./admin-rent-car-list.component.css']
})
export class AdminRentCarListComponent implements OnInit {

  constructor(private _carService: CarService, public dialog: MatDialog) { }

  carList_displayedColumns: string[] = ['id','carBrand', 'pricePerDay','kmCar','image'];
  carList_dataSource: Array<any> = new Array<any>()
  carList_dataTable  : MatTableDataSource<any> | undefined;

  carListRetreat_displayedColumns: string[] = ['id','carBrand', 'pricePerDay','fullName', 'interval'];
  carListRetreat_dataSource: Array<any> = new Array<any>()
  carListRetreat_dataTable : MatTableDataSource<any> | undefined;
 

  @ViewChild('paginator') paginator: MatPaginator | undefined;
  @ViewChild('paginatorRetreat') paginatorRetreat!: MatPaginator 

  ngOnInit(): void {
    this.getActivCars();
    this.getRetreatCarList();
  }

  getActivCars(){
    this._carService.getActivCarForAdmin().subscribe(x =>{
      this.carList_dataSource = x;
      this.carList_dataTable = new MatTableDataSource(this.carList_dataSource)
      this.carList_dataTable.paginator = this.paginator!
    });
  }

  differentceITP(expireITP: any){
    var dif = differenceInDays(new Date(expireITP?.itp), new Date())

    return dif;
  }

  getRetreatCarList(){
    this._carService.getRetreatCarList().subscribe(x =>{
      this.carListRetreat_dataSource = x
      this.carListRetreat_dataTable = new MatTableDataSource(this.carListRetreat_dataSource);
      this.carListRetreat_dataTable.paginator = this. paginatorRetreat!
    })  
  }

  onClickedOpenDetalisCar(row: any){
    const modal = this.dialog.open(CarDetailsAdminModalComponent, {
      data: {
        row: row,
        typeModal: 'DetailsCar'
      },
      closeOnNavigation: true
    })
    modal.afterClosed().subscribe(x => {
      this.getActivCars();
      this.getRetreatCarList();
    })
  }

  onClickOpenDetaliRetreat(row: any){
    const modal = this.dialog.open(DetailsRetreatCarComponent, {
      data: {
        row: row,
        typeModal: 'NextRetreatCar'
      },
      closeOnNavigation: true
    })
  }

}
