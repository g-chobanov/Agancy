import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ITruck } from '../models/truck.model';
import { TruckService } from '../services/truck.service';

@Component({
  selector: '[truck-table-row]',
  templateUrl: './truck-table-row.component.html',
  styleUrls: ['./truck-table-row.component.css']
})
export class TruckTableRowComponent  {

  @Input() truck!: ITruck ;
  @Input() rowIndex!: number;

  @Output() deletedIndex = new EventEmitter<number>();

  isEditing: boolean = false;

  constructor(private _service: TruckService) {

  }
  
  deleteElement() {
    this._service.delete(this.truck.id).
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

  onFormSubmitted(truck: ITruck) {
    this.truck.passengerCapacity = truck.passengerCapacity;
    this.truck.pricePerKilometer = truck.pricePerKilometer;
    this.truck.storage = truck.storage;
  }

  onFormCancelled() {
    this.isEditing = false;
  }


}
