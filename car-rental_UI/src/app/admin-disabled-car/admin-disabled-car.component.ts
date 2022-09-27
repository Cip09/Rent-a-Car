import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DetailsRetreatCarComponent } from '../modal-dialog/details-retreat-car/details-retreat-car.component';
import { CarService } from '../service/car.service';

@Component({
  selector: 'app-admin-disabled-car',
  templateUrl: './admin-disabled-car.component.html',
  styleUrls: ['./admin-disabled-car.component.css']
})
export class AdminDisabledCarComponent implements OnInit {

  constructor(private _carService: CarService, public dialog: MatDialog) { }

  carListDisabled_displayedColumns: string[] = ['id','carBrand', 'pricePerDay','fullName', 'interval'];
  carListDisabled_dataSource: Array<any> = new Array<any>()
  carListDisabled_dataTable = new MatTableDataSource()

  @ViewChild('paginator') paginator: MatPaginator | undefined;

  car: any
  ngOnInit(): void {
    this.getDisabledCar();
  }

  getDisabledCar(){
    this._carService.getDisabledCarList().subscribe(x =>{
      this.carListDisabled_dataSource = x;
      this.carListDisabled_dataTable = new MatTableDataSource(this.carListDisabled_dataSource);
      this.carListDisabled_dataTable.paginator = this.paginator!

    })
  }


  onClickOpenDetaliRetreat(row: any){
    const modal = this.dialog.open(DetailsRetreatCarComponent, {
      data: {
        row: row,
     
      },
      closeOnNavigation: true
    })
  }

}
