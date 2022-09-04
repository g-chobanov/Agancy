import { Component, ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AirplaneFormComponent } from './airplane/airplane-form/airplane-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AirplaneTableComponent } from './airplane/airplane-table/airplane-table.component';
import { AirplaneService } from './services/airplane.service';
import { AirplaneTableRowComponent } from './airplane/airplane-table-row/airplane-table-row.component';
import { AddButtonComponent } from './common/add-button/add-button.component';
import { HttpClientModule } from '@angular/common/http'
import { TransformToAirplaneService } from './services/transform-to-airplane.service';
import { BusService } from './services/bus.service';
import { CargoShipService } from './services/cargo-ship.service';
import { TrainService } from './services/train.service';
import { TruckService } from './services/truck.service';
import { TransformToBusService } from './services/transform-to-bus.service';
import { TransformToCargoShipService } from './services/transform-to-cargo-ship.service';
import { TransformToTrainService } from './services/transform-to-train.service';
import { TransformToTruckService } from './services/transform-to-truck.service';
import { BusFormComponent } from './bus/bus-form/bus-form.component';
import { BusTableRowComponent } from './bus/bus-table-row/bus-table-row.component';
import { BusTableComponent } from './bus/bus-table/bus-table.component';
import { CargoShipTableComponent } from './cargoship/cargo-ship-table/cargo-ship-table.component';
import { CargoShipTableRowComponent } from './cargoship/cargo-ship-table-row/cargo-ship-table-row.component';
import { CargoShipFormComponent } from './cargoship/cargo-ship-form/cargo-ship-form.component';
import { TruckFormComponent } from './truck/truck-form/truck-form.component';
import { TruckTableComponent } from './truck/truck-table/truck-table.component';
import { TruckTableRowComponent } from './truck/truck-table-row/truck-table-row.component';
import { TrainFormComponent } from './train/train-form/train-form.component';
import { TrainTableComponent } from './train/train-table/train-table.component';
import { TrainTableRowComponent } from './train/train-table-row/train-table-row.component';
import { RouterModule } from '@angular/router';
import { NavBarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { VehicleTableComponent } from './vehicle/vehicle-table/vehicle-table.component';
import { VehicleTableRowComponent } from './vehicle/vehicle-table-row/vehicle-table-row.component';
import { JourneyTableComponent } from './journey/journey-table/journey-table.component';
import { JourneyTableRowComponent } from './journey/journey-table-row/journey-table-row.component';
import { JourneyFormComponent } from './journey/journey-form/journey-form.component';
import { TicketTableComponent } from './ticket/ticket-table/ticket-table.component';
import { TicketTableRowComponent } from './ticket/ticket-table-row/ticket-table-row.component';
import { ModelTypePipe } from './pipes/modeltype.pipe';
import { TicketFormComponent } from './ticket/ticket-form/ticket-form.component';
import { AppErrorHandler } from './common/app-error-handler';

@NgModule({
  declarations: [
    AppComponent,
    AirplaneFormComponent,
    AirplaneTableComponent,
    AirplaneTableRowComponent,
    AddButtonComponent,
    BusFormComponent,
    BusTableRowComponent,
    BusTableComponent,
    CargoShipTableComponent,
    CargoShipTableRowComponent,
    CargoShipFormComponent,
    TruckFormComponent,
    TruckTableComponent,
    TruckTableRowComponent,
    TrainFormComponent,
    TrainTableComponent,
    TrainTableRowComponent,
    NavBarComponent,
    HomeComponent,
    VehicleTableComponent,
    VehicleTableRowComponent,
    JourneyTableComponent,
    JourneyTableRowComponent,
    JourneyFormComponent,
    ModelTypePipe,
    TicketTableComponent,
    TicketTableRowComponent,
    TicketFormComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path: ' ',
        component: HomeComponent
      },
      {
        path: "airplanes",
        component: AirplaneTableComponent
      },
      {
        path: "buses",
        component: BusTableComponent
      },
      {
        path: "cargoShips",
        component: CargoShipTableComponent
      },
      {
        path: "trucks",
        component: TruckTableComponent
      },
      {
        path: "trains",
        component: TrainTableComponent
      },
      {
        path: "vehicles",
        component: VehicleTableComponent
      },
      {
        path: "journeys",
        component: JourneyTableComponent
      },
      {
        path: "tickets",
        component: TicketTableComponent
      }
    ])
  ],
  providers: [
    AirplaneService,
    BusService,
    CargoShipService,
    TrainService,
    TruckService,
    TransformToAirplaneService,
    TransformToBusService,
    TransformToCargoShipService,
    TransformToTrainService,
    TransformToTruckService,
    {
      provide: ErrorHandler,
      useClass: AppErrorHandler
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
