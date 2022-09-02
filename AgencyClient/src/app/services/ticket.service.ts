import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITicket } from '../models/ticket.model';
import { JourneyService } from './journey.service';
import { ModelService } from './model.service';

@Injectable({
  providedIn: 'root'
})
export class TicketService extends ModelService<ITicket> {

  private priceUrl: string = "/Ticket/GetPrice";

  constructor(http: HttpClient, private _journeyService: JourneyService) {
    super(
      http,
      "/Ticket/GetAllTickets", 
      "/Ticket/CreateTicket",
      "/Ticket/DeleteTicket",
      "/Ticket/UpdateTicket"
    )
   }

   getPrice(id: string) : Observable<number>{
      return this.http.get<number>(this.hostUrl + this.priceUrl + "?id=" + id);
   }

   getJourneyInfo(id: string) : Observable<string> {
      return this._journeyService.getStringInfo(id);
   }
}
