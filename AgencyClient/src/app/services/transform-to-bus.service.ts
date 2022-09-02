import { Injectable } from '@angular/core';
import { IBus } from '../models/bus.model';
import { TransformToModelService } from './transform-to-model.service';

@Injectable({
  providedIn: 'root'
})
export class TransformToBusService implements TransformToModelService<IBus>{
  transformFromForm(form: any): IBus {
    let newBus: IBus = { 
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      passengerCapacity: form.get('passengerCapacity')?.value,
      pricePerKilometer: form.get('pricePerKilometer')?.value,
    };
    return newBus;
  }
  transformFromJson(json: any): IBus {
    let newBus: IBus = {
      id: json['id'],
      passengerCapacity: json['passengerCapacity'],
      pricePerKilometer: json['pricePerKilometer'],
    };
    return newBus;
  }
}
