import { Component, OnInit } from '@angular/core';
import { EntityType } from '../../common/entity-type.enum';
import { IAirplane } from '../../models/airplane.model';
import { AirplaneService } from '../../services/airplane.service';

@Component({
  selector: 'airplane-table',
  templateUrl: './airplane-table.component.html',
  styleUrls: ['./airplane-table.component.css']
})
export class AirplaneTableComponent implements OnInit {
  airplanes!: IAirplane[];
  entityType: EntityType = EntityType.Airplane;

  constructor(private _service: AirplaneService) {
    
  }

  ngOnInit(): void {
    this._service.getAll()
      .subscribe(data => this.airplanes = data )
  }

  onElementDeleted(index: number) {
    this.airplanes.splice(index, 1);
  }

}
