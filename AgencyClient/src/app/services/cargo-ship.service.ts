import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ModelService } from './model.service';
import { ICargoShip } from '../models/cargo-ship.model';
@Injectable({
  providedIn: 'root'
})
export class CargoShipService extends ModelService<ICargoShip>{
  constructor(http: HttpClient) { 
    super
    (
      http, 
      "/CargoShip/GetAllCargoShips", 
      "/CargoShip/CreateCargoShip",
      "/CargoShip/DeleteCargoShip",
      "/CargoShip/UpdateCargoShip"
    )
  }
}