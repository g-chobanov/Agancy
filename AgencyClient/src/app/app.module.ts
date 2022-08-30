import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AirplaneFormComponent } from './airplane-form/airplane-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AirplaneTableComponent } from './airplane-table/airplane-table.component';
import { AirplaneService } from './services/airplane.service';
import { AirplaneTableRowComponent } from './airplane-table-row/airplane-table-row.component';
import { AddButtonComponent } from './add-button/add-button.component';
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
import { BusFormComponent } from './bus-form/bus-form.component';
import { BusTableRowComponent } from './bus-table-row/bus-table-row.component';
import { BusTableComponent } from './bus-table/bus-table.component';
import { CargoShipTableComponent } from './cargo-ship-table/cargo-ship-table.component';
import { CargoShipTableRowComponent } from './cargo-ship-table-row/cargo-ship-table-row.component';
import { CargoShipFormComponent } from './cargo-ship-form/cargo-ship-form.component';
import { TruckFormComponent } from './truck-form/truck-form.component';
import { TruckTableComponent } from './truck-table/truck-table.component';
import { TruckTableRowComponent } from './truck-table-row/truck-table-row.component';
import { TrainFormComponent } from './train-form/train-form.component';
import { TrainTableComponent } from './train-table/train-table.component';
import { TrainTableRowComponent } from './train-table-row/train-table-row.component';
import { RouterModule } from '@angular/router';

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
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
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
    TransformToTruckService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
