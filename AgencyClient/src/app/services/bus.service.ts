import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBus } from '../models/bus.model';
import { ModelService } from './model.service';

@Injectable({
  providedIn: 'root'
})
export class BusService extends ModelService<IBus>{
  constructor(http: HttpClient) { 
    super
    (
      http, 
      "/Bus/GetAllBuses", 
      "/Bus/CreateBus",
      "/Bus/DeleteBus",
      "/Bus/UpdateBus"
    )
  }
}
