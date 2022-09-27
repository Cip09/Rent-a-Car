import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Data, Router } from '@angular/router';
import { CarModel } from '../models/carModel';
import { CarService } from '../service/car.service';
import valid, { number } from 'card-validator'
import { RentSchedulingService } from '../service/rentScheduling.service';
import { RentSchedulingModel } from '../models/rentSchedulingModel';
import { ToastrService } from 'ngx-toastr';
import { differenceInDays } from 'date-fns';

@Component({
  selector: 'app-car-detalis',
  templateUrl: './car-detalis.component.html',
  styleUrls: ['./car-detalis.component.css']
})
export class CarDetalisComponent implements OnInit {
 
  car : CarModel | undefined 
  sub: any;
  locations: string[]=['Aeroport Cluj-Napoca', 'Parcare VIVO', 'Gara Cluj-Napoca']
  rentCar = false;
  payMethod = 'Plata cash la primirea masinii'
  onlinePay = false
  gpsOption = false
  childSeatOption = false
  windshieldFluidOption = false
  SnowChainsOption = false
  conditionsValid = false
  checkBox : any 
  countPrice: number = 0


  dataPickerForm : FormGroup = new FormGroup({
    takeDataForm: new FormControl('', Validators.required),
    returnDataForm: new FormControl('', Validators.required),
    takePlaceForm: new FormControl('', Validators.required),
    returnPlaceForm: new FormControl('', Validators.required),
    timeTakeForm: new FormControl('',Validators.required),
    timeRetunForm: new FormControl('', Validators.required)
  })

  carListGroup: FormGroup = new FormGroup({
    listCarForm: new FormControl('')
  })

  personalDataGroup:  FormGroup = new FormGroup({
    completNameForm: new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]),
    adressForm: new FormControl('', Validators.required),
    phoneNumberForm: new FormControl('',[Validators.required, Validators.pattern('^[0-9]*$')]),
    mentionForm: new FormControl('')
  })

 
  minDate:Date | undefined;
  maxDate: Date | undefined
  maxDateTake: Date | undefined
  today = new Date()
  priceHide = false;
  totalPrice : number = 0
  totalDayRent = 0
  cars: [CarModel] | undefined
  DataStartFormat: string | undefined
  DataEndFormat: string | undefined
 

  constructor(private route: ActivatedRoute, private carService: CarService, private _formBuilder: FormBuilder, private _rentSchedulingService : RentSchedulingService, 
     private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {

    this.sub=this.route.snapshot.paramMap.get("id");
    this.getDetailsCar(this.sub);
    this.getAllCar()

    this.dataPickerForm.patchValue({takePlaceForm: this.locations[0]})
    this.dataPickerForm.patchValue({returnPlaceForm: this.locations[0]})

    //set date and location
    this.dataPickerForm.patchValue({timeTakeForm: `12:00`})
    this.dataPickerForm.patchValue({timeRetunForm: `12:00`})


    this.minDate = this.today

    this.dataPickerForm.valueChanges.subscribe(res=>{
        this.minDate = new Date(res.takeDataForm);
        this.maxDate = new Date(res.takeDataForm)
        this.maxDate.setDate(this.maxDate.getDate() + 5)
        this.maxDateTake = new Date(res.returnDataForm)
        this.onSubmit()
     });
    this.carListGroup.valueChanges.subscribe(res =>{
      this.car = res.listCarForm
     
     this.totalPrice = this.totalDayRent * this.car!.pricePerDay 
    })

  }

  getDetailsCar(id: number){
    this.carService.getCarById(id).subscribe(x => {
      this.car = x
    })
  }

  getAllCar(){
    this.carService.getAllCar().subscribe(x => {
      this.cars = x
    })
  }

  differentceITP(expireITP: any){
    var dif = differenceInDays(new Date(expireITP?.itp), this.today)
    return dif;
  }
  
 
  
  onSubmit(){
      this.priceHide =  true
 
      console.log(this.totalPrice)
    var dataStart = new Date(this.dataPickerForm.value.takeDataForm);
    var dataEnd = new Date(this.dataPickerForm.value.returnDataForm);
    if(dataStart.getMonth() == dataEnd.getMonth()){
      this.totalDayRent =dataEnd.getDate() - dataStart.getDate() + 1

    }else{

      if((dataStart.getMonth() + 1) % 2 == 0 && dataStart.getMonth() != 8){

        this.totalDayRent = 31 + dataEnd.getDate() - dataStart.getDate()
      }else{

        this.totalDayRent = 32 + dataEnd.getDate() - dataStart.getDate()
      }
    }
   if(!isNaN(this.totalDayRent)){
 
    this.totalPrice = this.totalDayRent * this.car!.pricePerDay 
   }

    this.DataStartFormat = `${dataStart.getDate()}/${dataStart.getMonth()+ 1}/${dataStart.getFullYear()}`
   
    this.DataEndFormat = `${dataEnd.getDate()}/${dataEnd.getMonth()+ 1}/${dataEnd.getFullYear()}`

  }

 


 
  radioChange(event : any){
       console.log(event.value)
    if(event.value == 1){
      this.payMethod = "Plata cash la primirea masinii"
    }
    if(event.value == 2){
      this.payMethod = "Plata cu cardul la primirea masinii"
    }
    if(event.value == 3){
      this.onlinePay = true
      this.payMethod = "Plata online efectuata"
    }
    else{
      this.onlinePay = false
    }
  }


  onChnageNumberCardInput(event: any) {
    console.log("intru aici");
    let response = valid.number(event.value);
    console.log({response});
  }

  chackBoxOptionChange(event:any){
    console.log(event.source.id)
    if(event.source.id == 'mat-checkbox-1'){
      this.gpsOption = !this.gpsOption
      if(this.gpsOption == true)
      {
        this.totalPrice = this.totalPrice + 5
      }else
      {
        this.totalPrice = this.totalPrice - 5
      }
    }
    if(event.source.id == 'mat-checkbox-2'){
      this.childSeatOption = !this.childSeatOption
        if(this.childSeatOption == true)
        {
          this.totalPrice = this.totalPrice + 10
        }else
        {
          this.totalPrice = this.totalPrice - 10
        }
    }
    if(event.source.id == 'mat-checkbox-3'){
      this.windshieldFluidOption = !this.windshieldFluidOption
        if(this.windshieldFluidOption == true)
        {
          this.totalPrice = this.totalPrice + 3
        }else
        {
          this.totalPrice = this.totalPrice - 3
        }
    }
    if(event.source.id == 'mat-checkbox-4'){
      this.SnowChainsOption = !this.SnowChainsOption
        if(this.SnowChainsOption == true)
        {
          this.totalPrice = this.totalPrice + 5
        }else
        {
          this.totalPrice = this.totalPrice - 5
        }
    }
    if(event.source.id == 'mat-checkbox-5'){
      this.conditionsValid = true
      console.log("sunt aici")
     }
    
    
  }
  sentRequestRent(){

    let number = this.personalDataGroup.value.phoneNumberForm
    console.log("sunt aici si numarul e " + number)
    var rentRequest: RentSchedulingModel = {
      car: this.car,
      starDate: this.dataPickerForm.value.takeDataForm,
      finishDate: this.dataPickerForm.value.returnDataForm,
      takeLocation: this.dataPickerForm.value.takePlaceForm,
      returnLocation: this.dataPickerForm.value.returnPlaceForm,
      takeTime: this.dataPickerForm.value.timeTakeForm,
      returnTime: this.dataPickerForm.value.timeRetunForm,

      //  //personal Data form
      completName: this.personalDataGroup.value.completNameForm,
      address: this.personalDataGroup.value.adressForm,
      phoneNumber: this.personalDataGroup.value.phoneNumberForm,
      mention: this.personalDataGroup.value.mentionForm,


      //    //other options
      gps: this.gpsOption,
      childSeatOption: this.childSeatOption,
      windshieldFluid: this.windshieldFluidOption,
      snowChains: this.SnowChainsOption,
      numberOfDay: this.totalDayRent,
      payMethod: this.payMethod,
      totalPrice: this.totalPrice,
      client: undefined,
      startDataFormat:  this.dataPickerForm.value.takeDataForm,
      finishDataFormat: `${this.dataPickerForm.value.returnDataForm.getDate()}/${this.dataPickerForm.value.returnDataForm.getMonth() + 1}/${this.dataPickerForm.value.returnDataForm.getFullYear()}`,
      id: 0,
      schedulingStatus: 0
    }
    console.log(this.personalDataGroup.value.phoneNumberForm)
    debugger
    

    console.log(rentRequest)
    debugger
    this._rentSchedulingService.addRentScheduling(rentRequest).subscribe(x=> {
        this.dataPickerForm.reset();
        this.personalDataGroup.reset()
        this.checkBox = false
        this.toastr.success('Cererea a fost inregistrata. Urmeaza sa fii contactat de noi','Programare efecutata' );
    })


  }

 
}
