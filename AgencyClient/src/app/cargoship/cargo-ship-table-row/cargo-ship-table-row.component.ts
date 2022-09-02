import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ICargoShip } from '../../models/cargo-ship.model';
import { CargoShipService } from '../../services/cargo-ship.service';

@Component({
  selector: '[cargo-ship-table-row]',
  templateUrl: './cargo-ship-table-row.component.html',
  styleUrls: ['./cargo-ship-table-row.component.css']
})
export class CargoShipTableRowComponent {

  @Input() cargoShip!: ICargoShip ;
  @Input() rowIndex!: number;

  @Output() deletedIndex = new EventEmitter<number>();

  isEditing: boolean = false;

  constructor(private _service: CargoShipService) {

  }
  
  deleteElement() {
    this._service.delete(this.cargoShip.id).
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

  onFormSubmitted(cargoShip: ICargoShip) {
    this.cargoShip.passengerCapacity = cargoShip.passengerCapacity;
    this.cargoShip.pricePerKilometer = cargoShip.pricePerKilometer;
    this.cargoShip.storage = cargoShip.storage;
  }

  onFormCancelled() {
    this.isEditing = false;
  }

}
