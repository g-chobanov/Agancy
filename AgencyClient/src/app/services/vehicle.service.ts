import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { ErrorHandlingService } from '../common/error-handling-service';
import { GlobalConstants } from '../common/globalconstants';
import { IVehicle } from '../models/vehicle.model';

@Injectable({
  providedIn: 'root'
})
export class VehicleService extends ErrorHandlingService{

  private hostUrl: string = GlobalConstants.apiURL;
  private getUrl: string = "/Vehicle/GetVehicle";
  private getAllUrl: string = "/Vehicle/GetAllVehicles";
  private deleteUrl: string = "/Vehicle/DeleteVehicle"
  
  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getVehicle(id: string) : Observable<IVehicle>{
    return this.http.get<IVehicle>(this.hostUrl + this.getUrl + "?id=" + id)
    .pipe( 
      catchError((error) => {
        return this.handleError(error.error);
      }));
    
  }

  getAllVehicles() : Observable<IVehicle[]> {
    return this.http.get<IVehicle[]>(this.hostUrl + this.getAllUrl)
    .pipe( 
      catchError((error) => {
        return this.handleError(error.error);
      }));
  }

  deleteVehicle(id: string) {
    return this.http.delete(this.hostUrl + this.deleteUrl + "?id=" + id)
    .pipe( 
      catchError((error) => {
        return this.handleError(error.error);
      }));
  }
 
}
