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

@NgModule({
  declarations: [
    AppComponent,
    AirplaneFormComponent,
    AirplaneTableComponent,
    AirplaneTableRowComponent,
    AddButtonComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    AirplaneService,
    TransformToAirplaneService],
  bootstrap: [AppComponent]
})
export class AppModule { }
