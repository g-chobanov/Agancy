import { Injectable } from '@angular/core';
import { ITrain } from '../models/train.model';

@Injectable({
  providedIn: 'root'
})
export class TransformToTrainService {

  formToTrain(form: any) : ITrain {
    let newTrain: ITrain = { 
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      passengerCapacity: form.get('passengerCapacity')?.value,
      pricePerKilometer: form.get('pricePerKilometer')?.value,
      carts: form.get('carts')?.value
    };
    return newTrain;
  }

  jsonToTrain(json: any): ITrain {
    let newTrain: ITrain = {
      id: json['id'],
      passengerCapacity: json['passengerCapacity'],
      pricePerKilometer: json['pricePerKilometer'],
      carts: json['carts']
    };
    return newTrain;
  } 
}
