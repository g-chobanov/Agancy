import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GlobalConstants } from '../common/globalconstants';
import { IVehicle } from '../models/vehicle.model';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private hostUrl: string = GlobalConstants.apiURL;
  private getUrl: string = "/Vehicle/GetVehicle";
  private getAllUrl: string = "/Vehicle/GetAllVehicles";
  private deleteUrl: string = "/Vehicle/DeleteVehicle"
  
  constructor(
    private http: HttpClient
  ) { }

  getVehicle(id: string) : Observable<IVehicle>{
    return this.http.get<IVehicle>(this.hostUrl + this.getUrl + "?id=" + id);
  }

  getAllVehicles() : Observable<IVehicle[]> {
    return this.http.get<IVehicle[]>(this.hostUrl + this.getAllUrl);
  }

  deleteVehicle(id: string) {
    return this.http.delete(this.hostUrl + this.deleteUrl + "?id=" + id);
  }
}
