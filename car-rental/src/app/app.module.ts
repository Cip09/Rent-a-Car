// import {ClipboardModule} from '@angular/cdk/clipboard';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { OverlayModule } from '@angular/cdk/overlay';
import { PortalModule } from '@angular/cdk/portal';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatBadgeModule } from '@angular/material/badge';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSliderModule } from '@angular/material/slider';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatStepperIntl, MatStepperModule } from '@angular/material/stepper';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTreeModule } from '@angular/material/tree';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServerModule } from '@angular/platform-server';
import { AdminContainerComponent } from './admin/admin-container/admin-container.component';
import { AdminDevicesComponent } from './admin/admin-devices/admin-devices.component';
import { DeviceDetailsComponent } from './admin/admin-devices/device-details/device-details.component';
import { DevicesListComponent } from './admin/admin-devices/devices-list/devices-list.component';
import { AdminSenzorComponent } from './admin/admin-senzor/admin-senzor.component';
import { SenzorDetailsComponent } from './admin/admin-senzor/senzor-details/senzor-details.component';
import { SenzorListComponent } from './admin/admin-senzor/senzor-list/senzor-list.component';
import { AdminUsersComponent } from './admin/admin-users/admin-users.component';
import { ClientDetailsComponent } from './admin/admin-users/client-details/client-details.component';
import { ClientsListComponent } from './admin/admin-users/clients-list/clients-list.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { HomeComponent } from './home/home.component';
import { RequestModalComponent } from './modal-dialog/request-modal/request-modal.component';
import { MyCarComponent } from './my-car/my-car.component';
import { RequestListComponent } from './request-list/request-list.component';

import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';
import { RequestAddedComponent } from './modal-dialog/request-added/request-added.component';
import { ToastrModule } from 'ngx-toastr';
import { AllCarForRentComponent } from './all-car-for-rent/all-car-for-rent.component';
import { RequestComponent } from './request/request.component';
import { JWTTokenService } from './shared/JWTToken.services';
import { RouterModule } from '@angular/router';
import { RentCarListComponent } from './rent-car-list/rent-car-list.component';
import { CarDetalisComponent } from './car-detalis/car-detalis.component';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { FooterComponent } from './footer/footer.component';
import { SchedulingRequestComponent } from './scheduling-request/scheduling-request.component';
import { RequestSchedulingComponent } from './modal-dialog/request-scheduling/request-scheduling.component';
import { SchedulingEndComponent } from './modal-dialog/scheduling-end/scheduling-end.component';
import { SchedulingStartComponent } from './modal-dialog/scheduling-start/scheduling-start.component';
import { MyCarDetailsComponent } from './modal-dialog/my-car-details/my-car-details.component';
import { RequestRetreatCarComponent } from './request-retreat-car/request-retreat-car.component';
import { RetreaCarModalComponent } from './modal-dialog/retrea-car-modal/retrea-car-modal.component';
import { AdminRentCarListComponent } from './admin-rent-car-list/admin-rent-car-list.component';
import { AdminDisabledCarComponent } from './admin-disabled-car/admin-disabled-car.component';
import { CarDetailsAdminModalComponent } from './modal-dialog/car-details-admin-modal/car-details-admin-modal.component';
import { DetailsRetreatCarComponent } from './modal-dialog/details-retreat-car/details-retreat-car.component';
import { ContactPageComponent } from './contact-page/contact-page.component';
import { ConditionsPageComponent } from './conditions-page/conditions-page.component';





@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    AdminContainerComponent,
    AdminUsersComponent,
    ClientsListComponent,
    ClientDetailsComponent,
    AdminDevicesComponent,
    DevicesListComponent,
    DeviceDetailsComponent,
    AdminSenzorComponent,
    SenzorDetailsComponent,
    SenzorListComponent,
    RequestComponent,
    MyCarComponent,
    RequestListComponent,
    RequestModalComponent,
    RequestAddedComponent,
    AllCarForRentComponent,
    RentCarListComponent,
    CarDetalisComponent,
    FooterComponent,
    SchedulingRequestComponent,
    RequestSchedulingComponent,
    SchedulingEndComponent,
    SchedulingStartComponent,
    MyCarDetailsComponent,
    RequestRetreatCarComponent,
    RetreaCarModalComponent,
    AdminRentCarListComponent,
    AdminDisabledCarComponent,
    CarDetailsAdminModalComponent,
    DetailsRetreatCarComponent,
    ContactPageComponent,
    ConditionsPageComponent, 

  ],

  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatInputModule,
    //ClipboardModule,
    CdkStepperModule,
    CdkTableModule,
    CdkTreeModule,
    DragDropModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,

    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    OverlayModule,
    PortalModule,
    ScrollingModule,
    FormsModule,
    MatIconModule,
    CommonModule,
    
    //
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
   //
   BrowserAnimationsModule,
   BrowserModule,
   FormsModule,
   HttpClientModule,
   MatNativeDateModule,
   ReactiveFormsModule,
   NgxMaterialTimepickerModule,
   MatCardModule,
   
  
  ],

  providers: [
    // UserService, 
    JWTTokenService, {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
