import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { differenceInDays } from 'date-fns';
import { MyCarDetailsComponent } from '../modal-dialog/my-car-details/my-car-details.component';
import { CarService } from '../service/car.service';


@Component({
  selector: 'app-my-car',
  templateUrl: './my-car.component.html',
  styleUrls: ['./my-car.component.css']
})
export class MyCarComponent implements OnInit {

  constructor(public carService: CarService, public dialog: MatDialog) { }
  imageBlobUrl: string = "";
  imageUrl: string = '';

  carList_displayedColumns: string[] = ['id','carBrand', 'pricePerDay','kmCar', 'itp','image'];
  carList_dataSource: Array<any> = new Array<any>()
  carList_dataTable = new MatTableDataSource()

  @ViewChild('paginatorApproved') paginator: MatPaginator | undefined;
 
  carList_Form = new FormGroup({
    id: new FormControl(),
    image: new FormControl(),
    response: new FormControl(),
    message: new FormControl(),
  })

  ngOnInit(){
    this.getCarByUserId();
  }

  differentceITP(expireITP: any){
    console.log(expireITP?.itp)
    var dif = differenceInDays(new Date(expireITP?.itp), new Date())

    console.log(dif)
    return dif;
  }

  getCarByUserId(){
    this.carService.getUserCar().subscribe(x => {

      this.carList_dataSource = x
      this.carList_dataTable = new MatTableDataSource(this.carList_dataSource);

      this.carList_dataTable.paginator = this.paginator!
    })
  }  

  isClickedRows(row:any){
    this.dialog.open(MyCarDetailsComponent, {
      data: { row: row
      },
      closeOnNavigation: true
    })
  }

}
