import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ITicket } from '../models/ticket.model';
import { TicketService } from '../services/ticket.service';

@Component({
  selector: '[ticket-table-row]',
  templateUrl: './ticket-table-row.component.html',
  styleUrls: ['./ticket-table-row.component.css']
})
export class TicketTableRowComponent implements OnInit {

  @Input() ticket!: ITicket ;
  @Input() rowIndex!: number;

  @Output() deletedIndex = new EventEmitter<number>();

  isEditing: boolean = false;
  price!: number;
  journeyInfo!: string;

  constructor(private _service: TicketService) {

  }
  ngOnInit(): void {
    this._service.getJourneyInfo(this.ticket.journeyID)
        .subscribe(data => {
          this.journeyInfo = data;
    });
    this._service.getPrice(this.ticket.id)
        .subscribe(data => {
          this.price = data;
    });
  }
  
  deleteElement() {
    this._service.delete(this.ticket.id).
      subscribe(
        data => {
          console.log(data);
          this.deletedIndex.emit(this.rowIndex);
        }
      )
  }

  onEditClick() {
    this.isEditing = true;
  }

  onFormSubmitted(ticket: ITicket) {
    this.ticket.administrativeCosts = ticket.administrativeCosts;
    this.ticket.journeyID = ticket.journeyID;
  }

  onFormCancelled() {
    this.isEditing = false;
  }

}
