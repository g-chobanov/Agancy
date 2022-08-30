import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ITruck } from '../models/truck.model';
import { ModelService } from './model.service';

@Injectable({
  providedIn: 'root'
})
export class TruckService extends ModelService<ITruck>{
  constructor(http: HttpClient) { 
    super
    (
      http, 
      "/Truck/GetAllTrucks", 
      "/Truck/CreateTruck",
      "/Truck/DeleteTruck",
      "/Truck/UpdateTruck"
    )
  }
}
