import { Component} from '@angular/core';
import { EntityType } from '../entity-type.enum';
import { ITruck } from '../models/truck.model';
import { TruckService } from '../services/truck.service';

@Component({
  selector: 'truck-table',
  templateUrl: './truck-table.component.html',
  styleUrls: ['./truck-table.component.css']
})
export class TruckTableComponent {

  trucks!: ITruck[];
  entityType: EntityType = EntityType.Truck;

  constructor(private _service: TruckService) {
    
  }

  ngOnInit(): void {
    this._service.getAll()
      .subscribe(data => this.trucks = data )
  }

  onElementDeleted(index: number) {
    this.trucks.splice(index, 1);
  }

}
