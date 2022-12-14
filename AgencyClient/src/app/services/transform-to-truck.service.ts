import { Injectable } from '@angular/core';
import { ITruck } from '../models/truck.model';
import { TransformToModelService } from './transform-to-model.service';

@Injectable({
  providedIn: 'root'
})
export class TransformToTruckService implements TransformToModelService<ITruck> {
  transformFromForm(form: any): ITruck {
    let newTruck: ITruck = { 
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      passengerCapacity: form.get('passengerCapacity')?.value,
      pricePerKilometer: form.get('pricePerKilometer')?.value,
      storage: form.get('storage')?.value
    };
    return newTruck;
  }
  transformFromJson(json: any): ITruck {
    let newTruck: ITruck = {
      id: json['id'],
      passengerCapacity: json['passengerCapacity'],
      pricePerKilometer: json['pricePerKilometer'],
      storage: json['storage']
    };
    return newTruck;
  }
}
