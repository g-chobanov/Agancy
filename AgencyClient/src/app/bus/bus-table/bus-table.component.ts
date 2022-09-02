import { Component, OnInit } from '@angular/core';
import { EntityType } from '../../common/entity-type.enum';
import { IBus } from '../../models/bus.model';
import { BusService } from '../../services/bus.service';

@Component({
  selector: 'bus-table',
  templateUrl: './bus-table.component.html',
  styleUrls: ['./bus-table.component.css']
})
export class BusTableComponent implements OnInit {
  buses!: IBus[];
  entityType: EntityType = EntityType.Bus;

  constructor(private _service: BusService) {
    
  }

  ngOnInit(): void {
    this._service.getAll()
      .subscribe(data => this.buses = data )
  }

  onElementDeleted(index: number) {
    this.buses.splice(index, 1);
  }

}
