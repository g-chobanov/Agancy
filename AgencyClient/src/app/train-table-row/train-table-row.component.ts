import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ITrain } from '../models/train.model';
import { TrainService } from '../services/train.service';

@Component({
  selector: '[train-table-row]',
  templateUrl: './train-table-row.component.html',
  styleUrls: ['./train-table-row.component.css']
})
export class TrainTableRowComponent  {

  @Input() train!: ITrain ;
  @Input() rowIndex!: number;

  @Output() deletedIndex = new EventEmitter<number>();

  isEditing: boolean = false;

  constructor(private _service: TrainService) {

  }
  
  deleteElement() {
    this._service.delete(this.train.id).
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

  onFormSubmitted(train: ITrain) {
    this.train.passengerCapacity = train.passengerCapacity;
    this.train.pricePerKilometer = train.pricePerKilometer;
    this.train.carts = train.carts;
  }

  onFormCancelled() {
    this.isEditing = false;
  }

}
