import { Injectable } from '@angular/core';
import { ICargoShip } from '../models/cargo-ship.model';

@Injectable({
  providedIn: 'root'
})
export class TransformToCargoShipService {

  formToCargoShip(form: any) : ICargoShip {
    let newCargoShip: ICargoShip = { 
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      passengerCapacity: form.get('passengerCapacity')?.value,
      pricePerKilometer: form.get('pricePerKilometer')?.value,
      storage: form.get('storage')?.value
    };
    return newCargoShip;
  }

  jsonToCargoShip(json: any): ICargoShip {
    let newCargoShip: ICargoShip = {
      id: json['id'],
      passengerCapacity: json['passengerCapacity'],
      pricePerKilometer: json['pricePerKilometer'],
      storage: json['storage']
    };
    return newCargoShip;
  } 
}
