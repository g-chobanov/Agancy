import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IJourney } from '../models/journey.model';
import { IVehicle } from '../models/vehicle.model';
import { ModelService } from './model.service';
import { VehicleService } from './vehicle.service';

@Injectable({
  providedIn: 'root'
})
export class JourneyService extends ModelService<IJourney>{

  private travelCostsUrl: string = "/Journey/GetTravelCosts";
  private stringInfoUrl: string = "/Journey/GetJourneyStringInfo";


  constructor(http: HttpClient, private vehicleService: VehicleService) {
    super(
      http,
      "/Journey/GetAllJourneys", 
      "/Journey/CreateJourney",
      "/Journey/DeleteJourney",
      "/Journey/UpdateJourney"
    )
   }

   getStringInfo(id: string) : Observable<string>{
      return this.http.get(this.hostUrl + this.stringInfoUrl + "?id=" + id, {responseType: 'text'});
   }

   getTravelCosts(id: string) : Observable<number>{
      return this.http.get<number>(this.hostUrl + this.travelCostsUrl + "?id=" + id);
   }

   getVehicleInfo(id: string) : Observable<IVehicle> {
      return this.vehicleService.getVehicle(id);
   }
}
