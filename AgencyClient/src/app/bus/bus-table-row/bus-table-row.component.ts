import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IBus } from '../../models/bus.model';
import { BusService } from '../../services/bus.service';

@Component({
  selector: '[bus-table-row]',
  templateUrl: './bus-table-row.component.html',
  styleUrls: ['./bus-table-row.component.css']
})
export class BusTableRowComponent  {
  @Input() bus!: IBus ;
  @Input() rowIndex!: number;

  @Output() deletedIndex = new EventEmitter<number>();

  isEditing: boolean = false;

  constructor(private _service: BusService) {

  }
  
  deleteElement() {
    this._service.delete(this.bus.id).
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

  onFormSubmitted(bus: IBus) {
    this.bus.passengerCapacity = bus.passengerCapacity;
    this.bus.pricePerKilometer = bus.pricePerKilometer;
  }

  onFormCancelled() {
    this.isEditing = false;
  }

}
