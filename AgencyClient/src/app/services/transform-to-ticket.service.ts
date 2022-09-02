import { Injectable } from '@angular/core';
import { ITicket } from '../models/ticket.model';
import { TransformToModelService } from './transform-to-model.service';

@Injectable({
  providedIn: 'root'
})
export class TransformToTicketService implements TransformToModelService<ITicket> {

  constructor() { }
  transformFromForm(form: any): ITicket {
    let newJourney: ITicket = { 
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      administrativeCosts: form.get('administrativeCosts').value,
      journeyID: form.get('journeyID').value
    };
    return newJourney;
  }
  transformFromJson(json: any): ITicket {
    let newJourney: ITicket = { 
      id: json['id'],
      administrativeCosts: json['administrativeCosts'],
      journeyID: json['journeyID']
    };
    return newJourney;
  }
}
