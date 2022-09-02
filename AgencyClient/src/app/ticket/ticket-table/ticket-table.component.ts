import { Component, OnInit } from '@angular/core';
import { EntityType } from '../../entity-type.enum';
import { ITicket } from '../../models/ticket.model';
import { TicketService } from '../../services/ticket.service';

@Component({
  selector: 'ticket-table',
  templateUrl: './ticket-table.component.html',
  styleUrls: ['./ticket-table.component.css']
})
export class TicketTableComponent implements OnInit {

  tickets!: ITicket[];
  entityType: EntityType = EntityType.Ticket;

  constructor(private _service: TicketService) {
    
  }

  ngOnInit(): void {
    this._service.getAll()
      .subscribe(data => this.tickets = data )
  }

  onElementDeleted(index: number) {
    this.tickets.splice(index, 1);
  }

}
