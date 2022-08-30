import { Injectable } from '@angular/core';
import { IAirplane } from '../models/airplane.model';

@Injectable({
  providedIn: 'root'
})
export class TransformToAirplaneService {

  formToAirplane(form: any) : IAirplane {
    let newAirplane: IAirplane = { 
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      passengerCapacity: form.get('passengerCapacity')?.value,
      pricePerKilometer: form.get('pricePerKilometer')?.value,
      hasFreeFood: form.get('hasFreeFood')?.value 
    };
    return newAirplane;
  }

  jsonToAirplane(json: any): IAirplane {
    let newAirplane: IAirplane = {
      id: json['id'],
      passengerCapacity: json['passengerCapacity'],
      pricePerKilometer: json['pricePerKilometer'],
      hasFreeFood: json['hasFreeFood']
    };
    return newAirplane;
  } 
}
