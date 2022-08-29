import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAirplane } from '../models/airplane.model';
import { ModelService } from './model.service';

@Injectable({
  providedIn: 'root'
})
export class AirplaneService extends ModelService<IAirplane>{
  constructor(http: HttpClient) { 
    super
    (
      http, 
      "/Airplane/GetAllAirplanes", 
      "/Airplane/CreateAirplane",
      "/Airplane/DeleteAirplane",
      "/Airplane/UpdateAirplane"
    )
  }
}
