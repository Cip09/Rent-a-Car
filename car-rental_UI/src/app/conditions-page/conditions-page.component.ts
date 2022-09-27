import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-conditions-page',
  templateUrl: './conditions-page.component.html',
  styleUrls: ['./conditions-page.component.css']
})
export class ConditionsPageComponent implements OnInit {
  menuButton: Array<Boolean> = new Array()
  arr: boolean[] = [true, false, false, false, false];
  constructor() { }

  ngOnInit(): void {

  }
  showContent(index: any){
    this.arr[index] = true;
    for(var i = 0; i< 6; i++){
      if(i != index)
      {
        this.arr[i] = false
      }
    } 
  }

}
