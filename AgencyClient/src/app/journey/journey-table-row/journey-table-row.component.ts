import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IJourney } from '../../models/journey.model';
import { JourneyService } from '../../services/journey.service';

@Component({
  selector: '[journey-table-row]',
  templateUrl: './journey-table-row.component.html',
  styleUrls: ['./journey-table-row.component.css']
})
export class JourneyTableRowComponent implements OnInit {

  @Input() journey!: IJourney ;
  @Input() rowIndex!: number;

  @Output() deletedIndex = new EventEmitter<number>();

  isEditing: boolean = false;
  travelCosts!: number;
  vehicleInfo!: string;

  constructor(private _service: JourneyService) {

  }
  ngOnInit(): void {
    this._service.getVehicleInfo(this.journey.vehicleID)
        .subscribe(data => {
          this.vehicleInfo = data.stringVehicleInfo;
    });
    this._service.getTravelCosts(this.journey.id)
        .subscribe(data => {
          this.travelCosts = data;
    });
  }
  
  deleteElement() {
    this._service.delete(this.journey.id).
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

  onFormSubmitted(journey: IJourney) {
    this.journey.startLocation = journey.startLocation;
    this.journey.destination = journey.destination;
    this.journey.distance = journey.distance;
    this.journey.vehicleID = journey.vehicleID;
  }

  onFormCancelled() {
    this.isEditing = false;
  }

}
