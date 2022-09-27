import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SchedulingStatusEnum } from 'src/app/models/scheduling-status-enum';
import { RentSchedulingService } from 'src/app/service/rentScheduling.service';


@Component({
  selector: 'app-request-scheduling',
  templateUrl: './request-scheduling.component.html',
  styleUrls: ['./request-scheduling.component.css']
})
export class RequestSchedulingComponent implements OnInit {
  totalDay: any
  request : any
  showHistorian = false

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private _requestService: RentSchedulingService, public dialogRef: MatDialogRef<RequestSchedulingComponent>) { }

  historyAproved_displayedColumns: string[] = ['id', 'fullName','carBrand','numberOfday', 'dayLate','externalDefects', 'internalDefects',  'mention' ];
  historyAproved_dataSource: Array<any> = new Array<any>()
  historyApproved_dataTable : MatTableDataSource<any> | undefined

  historyDecline_displayedColumns: string[] = ['id', 'fullName','carBrand','declineReason'];
  historyDecline_dataSource: Array<any> = new Array<any>()
  historyDecline_dataTable : MatTableDataSource<any> | undefined

  
  @ViewChild('paginatorApproved') paginatorApproved: MatPaginator | undefined;
  @ViewChild('paginatorDecline') paginatorDecline: MatPaginator | undefined;

  ngOnInit(): void {
    this.request = this.data.row
    

  }

  showHistorianSubmit(){

    this._requestService.getHistoryClient(this.request.client.id).subscribe(x =>{
      this.historyAproved_dataSource =  x.filter(x => x.statusScheduling == SchedulingStatusEnum.SchedulingEnd)
      this.historyDecline_dataSource = x.filter(x => x.statusScheduling == SchedulingStatusEnum.SchedulingDecline)
     
      this.historyApproved_dataTable = new MatTableDataSource(this.historyAproved_dataSource)
      this.historyDecline_dataTable =  new MatTableDataSource(this.historyDecline_dataSource)
      
      if(this.paginatorApproved)
        this.historyApproved_dataTable.paginator = this.paginatorApproved

      if(this.paginatorDecline)
         this.historyDecline_dataTable.paginator = this.paginatorDecline
      
      this.showHistorian = true
      
    })

  }

  responseSheduling(response: boolean){
    console.log(this.request.id)
    this._requestService.responseRequestSecheduling(this.request.id, response).subscribe(x =>{
     if(response == true){
       //refresh la tabele
      
     }
    })
  
    
  }

  close(boolResponse: boolean){
    this.dialogRef.close(boolResponse);
  }

}
