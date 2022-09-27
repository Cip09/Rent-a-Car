import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { RequestSchedulingComponent } from '../modal-dialog/request-scheduling/request-scheduling.component';
import { SchedulingEndComponent } from '../modal-dialog/scheduling-end/scheduling-end.component';
import { SchedulingStartComponent } from '../modal-dialog/scheduling-start/scheduling-start.component';

import { RentSchedulingService } from '../service/rentScheduling.service';

@Component({
  selector: 'app-scheduling-request',
  templateUrl: './scheduling-request.component.html',
  styleUrls: ['./scheduling-request.component.css']
})
export class SchedulingRequestComponent implements OnInit {

  programRequestList_displayedColumns: string[] = ['id', 'fullName', 'data','carBrand','model','payMethod'];
  programRequestList_dataSource: Array<any> = new Array<any>()

  schedulingApproved_displayColumns: string[] = ['id', 'fullName', 'data', 'carBrand', 'payMethod']
  schedulingApproved_dataSource : Array<any> = new Array<any>()

  schedulingStart_displayColumns: string[] = ['id', 'fullName', 'data', 'carBrand', 'return']
  schedulingStart_dataSource : Array<any> = new Array<any>()


  @ViewChild('paginator') paginator: MatPaginator | undefined;
  @ViewChild('paginatorApproved') paginatorApproved: MatPaginator | undefined
  @ViewChild('paginatorStart') paginatorStart: MatPaginator | undefined

  dataSource: MatTableDataSource<any> | undefined;
  dataSource_paginatorApproved : MatTableDataSource<any> | undefined;
  dataSource_start:MatTableDataSource<any> | undefined;


  

  constructor(private _rentSchedulingService : RentSchedulingService,  public dialog: MatDialog) { }

  ngOnInit(): void {
    this.getRequestScheduling()
    this.getSchedulingApproved()
    this.getSchedulingStart()
  }

  reloadAllRequest(){
    this.getRequestScheduling()
    this.getSchedulingApproved()
    this.getSchedulingStart()  
  }

  getRequestScheduling(){
    this._rentSchedulingService.getRequestScheduling().subscribe(x => {
      this.programRequestList_dataSource = x
      this.dataSource = new MatTableDataSource(this.programRequestList_dataSource);
      if(this.paginator)
      this.dataSource.paginator = this.paginator;
    })
  }

  getSchedulingStart(){
    this._rentSchedulingService.getSchedulingStart().subscribe(x => {
      this.schedulingStart_dataSource = x;
      this.dataSource_start = new MatTableDataSource(x)
      if(this.paginatorStart)
      this.dataSource_start.paginator = this.paginatorStart
    })
  }

  getSchedulingApproved(){
    this._rentSchedulingService.getSchedulingApproved().subscribe(x => {
      this.schedulingApproved_dataSource = x
      this.dataSource_paginatorApproved = new MatTableDataSource(this.schedulingApproved_dataSource)
      if(this.paginatorApproved)
       this.dataSource_paginatorApproved.paginator = this.paginatorApproved
    })
  }

  onClickPendingRequest(row:any){
    const modal =  this.dialog.open(RequestSchedulingComponent, {
      data: { row: row
      },
      closeOnNavigation: true
    });
    modal.afterClosed().subscribe(x => {
      if(x == true)
        this.reloadAllRequest()

    })

  }

  isClickedRowStartScheduling(row : any){
    const modal = this.dialog.open(SchedulingStartComponent, {
      data: { row: row
      },
      closeOnNavigation: true
    })

    modal.afterClosed().subscribe(x => {
      if(x == true)
        this.reloadAllRequest()

    })
  }

  isClickedRowEndScheduling(row : any){
    const modal = this.dialog.open(SchedulingEndComponent, {
      data: { row: row
      },
      closeOnNavigation: true
    })
    modal.afterClosed().subscribe(x => {
      debugger
        this.reloadAllRequest()

    })
  }

}
