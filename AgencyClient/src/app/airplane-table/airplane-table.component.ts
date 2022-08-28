import { Component, OnInit } from '@angular/core';
import { EntityType } from '../entity-type.enum';
import { IAirplane } from '../models/airplane.model';
import { AirplaneService } from '../services/airplane.service';

@Component({
  selector: 'airplane-table',
  templateUrl: './airplane-table.component.html',
  styleUrls: ['./airplane-table.component.css']
})
export class AirplaneTableComponent implements OnInit {
  airplanes: IAirplane[] = [ 
    {passengerCapacity: 23, pricePerKilometer: 22, hasFreeFood: true}, 
    {passengerCapacity: 23, pricePerKilometer: 22, hasFreeFood: true}];
  entityType: EntityType = EntityType.Airplane;

  constructor(_service: AirplaneService) {
    
  }

  ngOnInit(): void {
  }

  onElementDeleted(index: number) {
    this.airplanes.splice(index, 1);
  }

}
