import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IVehicle } from '../models/vehicle.model';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: '[vehicle-table-row]',
  templateUrl: './vehicle-table-row.component.html',
  styleUrls: ['./vehicle-table-row.component.css']
})
export class VehicleTableRowComponent {

  @Input() vehicle!: IVehicle ;
  @Input() rowIndex!: number;

  @Output() deletedIndex = new EventEmitter<number>();

  isEditing: boolean = false;

  constructor(private _service: VehicleService) {

  }
  
  deleteElement() {
    this._service.deleteVehicle(this.vehicle.id).
      subscribe(
        data => {
          console.log(data);
          this.deletedIndex.emit(this.rowIndex);
        }
      )
  }

}