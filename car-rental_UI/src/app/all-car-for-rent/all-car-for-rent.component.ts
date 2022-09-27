import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-all-car-for-rent',
  templateUrl: './all-car-for-rent.component.html',
  styleUrls: ['./all-car-for-rent.component.css']
})
export class AllCarForRentComponent implements OnInit {

  constructor() { }
  search : String ="";
  ngOnInit(): void {
  }

}
