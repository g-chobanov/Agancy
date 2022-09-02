import { Injectable } from '@angular/core';
import { IJourney } from '../models/journey.model';
import { TransformToModelService } from './transform-to-model.service';

@Injectable({
  providedIn: 'root'
})
export class TransformToJourneyService implements TransformToModelService<IJourney>{
  transformFromForm(form: any): IJourney {
    let newJourney: IJourney = { 
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      startLocation: form.get('startLocation').value,
      destination: form.get('destination').value,
      distance: form.get('distance').value,
      vehicleID: form.get('vehicleID').value
    };
    return newJourney;
  }
  transformFromJson(json: any): IJourney {
    let newJourney: IJourney = {
      id: json['id'],
      startLocation: json['startLocation'],
      destination: json['destination'],
      distance: json['distance'],
      vehicleID: json['vehicleID']
    };
    return newJourney;
  }
}
