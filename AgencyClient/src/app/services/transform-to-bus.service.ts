import { Injectable } from '@angular/core';
import { IBus } from '../models/bus.model';

@Injectable({
  providedIn: 'root'
})
export class TransformToBusService {

  formToBus(form: any) : IBus {
    let newBus: IBus = { 
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      passengerCapacity: form.get('passengerCapacity')?.value,
      pricePerKilometer: form.get('pricePerKilometer')?.value,
    };
    return newBus;
  }

  jsonToBus(json: any): IBus {
    let newBus: IBus = {
      id: json['id'],
      passengerCapacity: json['passengerCapacity'],
      pricePerKilometer: json['pricePerKilometer'],
    };
    return newBus;
  } 
}
