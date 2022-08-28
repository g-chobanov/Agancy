import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IAirplane } from '../models/airplane.model';

@Component({
  selector: '[airplane-table-row]',
  templateUrl: './airplane-table-row.component.html',
  styleUrls: ['./airplane-table-row.component.css']
})
export class AirplaneTableRowComponent  {
  @Input() airplane!: IAirplane ;
  @Input() rowIndex!: number;

  @Output() deletedIndex = new EventEmitter<number>();

  isEditing: boolean = false;
  
  deleteElement() {
    this.deletedIndex.emit(this.rowIndex);
  }

  onEditClick() {
    this.isEditing = true;
  }

  onFormSubmitted(airplane: IAirplane) {
    this.airplane.passengerCapacity = airplane.passengerCapacity;
    this.airplane.pricePerKilometer = airplane.pricePerKilometer;
    this.airplane.hasFreeFood = airplane.hasFreeFood;
  }

  onFormCancelled() {
    this.isEditing = false;
  }

}
