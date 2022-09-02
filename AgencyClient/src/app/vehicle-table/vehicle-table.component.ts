import { Component, OnInit } from '@angular/core';
import { IVehicle } from '../models/vehicle.model';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: 'vehicle-table',
  templateUrl: './vehicle-table.component.html',
  styleUrls: ['./vehicle-table.component.css']
})
export class VehicleTableComponent implements OnInit {
  vehicles!: IVehicle[];

  constructor(private _service: VehicleService) {
    
  }

  ngOnInit(): void {
    this._service.getAllVehicles()
      .subscribe(data => this.vehicles = data )
  }

  onElementDeleted(index: number) {
    console.log(this.vehicles[index].stringVehicleInfo);
    this.vehicles.splice(index, 1);
  }

}