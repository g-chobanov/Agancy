import { Component, OnInit } from '@angular/core';
import { EntityType } from '../../common/entity-type.enum';
import { ICargoShip } from '../../models/cargo-ship.model';
import { CargoShipService } from '../../services/cargo-ship.service';

@Component({
  selector: 'cargo-ship-table',
  templateUrl: './cargo-ship-table.component.html',
  styleUrls: ['./cargo-ship-table.component.css']
})
export class CargoShipTableComponent implements OnInit {
  cargoShips!: ICargoShip[];
  entityType: EntityType = EntityType.CargoShip;

  constructor(private _service: CargoShipService) {
    
  }

  ngOnInit(): void {
    this._service.getAll()
      .subscribe(data => this.cargoShips = data )
  }

  onElementDeleted(index: number) {
    this.cargoShips.splice(index, 1);
  }

}
