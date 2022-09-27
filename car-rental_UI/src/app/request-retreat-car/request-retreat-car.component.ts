import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { RetreaCarModalComponent } from '../modal-dialog/retrea-car-modal/retrea-car-modal.component';
import { RentSchedulingService } from '../service/rentScheduling.service';

@Component({
  selector: 'app-request-retreat-car',
  templateUrl: './request-retreat-car.component.html',
  styleUrls: ['./request-retreat-car.component.css']
})
export class RequestRetreatCarComponent implements OnInit {

  requestTemporaryList_displayedColumns: string[] = ['id', 'fullName', 'email', 'carBrand', 'dataInterval'];
  requestTemporaryList_dataSource: Array<any> = new Array<any>()

  requestTemporaryList_dataTable: MatTableDataSource<any> | undefined

  requestPermanetList_displayedColumns: string[] = ['id', 'fullName', 'email', 'carBrand', 'dataInterval'];
  requestPermanetList_dataSource: Array<any> = new Array<any>()

  requestPermanetList_dataTable: MatTableDataSource<any> | undefined

  constructor(private _rentSchedulingService: RentSchedulingService, public dialog: MatDialog) { }

  @ViewChild('paginatorTemporary') paginatorTemporary: MatPaginator | undefined;
  @ViewChild('paginatorPermanent') paginatorPermanent: MatPaginator | undefined;


  ngOnInit(): void {
    this.getRetreatCarRequestTemporary()
    this.getRetreatCarRequestPermanet()
  }

  getRetreatCarRequestTemporary() {
    this._rentSchedulingService.getRequestRetreatCarTemporary().subscribe(x => {

      this.requestTemporaryList_dataSource = x
      this.requestTemporaryList_dataTable = new MatTableDataSource(this.requestTemporaryList_dataSource)
      this.requestTemporaryList_dataTable.paginator = this.paginatorTemporary!
    })

  }

  getRetreatCarRequestPermanet() {
    this._rentSchedulingService.getRequestRetreatCarPermanent().subscribe(x => {
      this.requestPermanetList_dataSource = x
      this.requestPermanetList_dataTable = new MatTableDataSource(this.requestPermanetList_dataSource)
      this.requestPermanetList_dataTable.paginator = this.paginatorPermanent!
    })
  }
  onClickRetreatPermanent(row: any) {
    const modal = this.dialog.open(RetreaCarModalComponent, {
      data: {
        row: row,
        typeModal: "permanent"
      },
      closeOnNavigation: true
    })

    modal.afterClosed().subscribe(x => {
    
        this.getRetreatCarRequestPermanet()

    })
  }

  onCLickOpentTemporaryRetreatModal(row: any) {
    const modal = this.dialog.open(RetreaCarModalComponent, {
      data: {
        row: row,
        typeModal: "temporary"
      },
      closeOnNavigation: true
    })

    modal.afterClosed().subscribe(x => {
     
        this.getRetreatCarRequestTemporary()

    })
  }

}
