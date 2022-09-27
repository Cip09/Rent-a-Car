import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';

import { RequestModalComponent } from '../modal-dialog/request-modal/request-modal.component';
import { RequestModel } from '../models/requestModel';
import { RequestService } from '../service/request.service';

@Component({
  selector: 'app-request-list',
  templateUrl: './request-list.component.html',
  styleUrls: ['./request-list.component.css']
})
export class RequestListComponent implements OnInit {


  constructor(public requestService: RequestService, public dialog: MatDialog) { }

  clickedRows = new Set<any>();

  requestList_displayedColumns: string[] = ['id', 'fullName', 'carBrand', 'model', 'image', 'message'];
  requestList_dataSource: Array<any> = new Array<any>()

  requestList_Form = new FormGroup({
    id: new FormControl(),
    image: new FormControl(),
    response: new FormControl(),
    message: new FormControl(),
  })

  ngOnInit(): void {
    this.getAllActivRequest();
  }

  getAllActivRequest() {
    this.requestService.getRequest().subscribe(x => {
      this.requestList_dataSource = x
    })
  }

  isClickedRows(row: any) {

    const modal = this.dialog.open(RequestModalComponent, {
      data: {
        row: row
      },
      closeOnNavigation: true
    })
    modal.afterClosed().subscribe(x => {
      this.getAllActivRequest();
    })
  }

}
