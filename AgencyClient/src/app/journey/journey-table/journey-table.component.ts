import { Component, OnInit } from '@angular/core';
import { EntityType } from '../../entity-type.enum';
import { IJourney } from '../../models/journey.model';
import { JourneyService } from '../../services/journey.service';

@Component({
  selector: 'journey-table',
  templateUrl: './journey-table.component.html',
  styleUrls: ['./journey-table.component.css']
})
export class JourneyTableComponent implements OnInit {

  journeys!: IJourney[];
  entityType: EntityType = EntityType.Journey;

  constructor(private _service: JourneyService) {
    
  }

  ngOnInit(): void {
    this._service.getAll()
      .subscribe(data => this.journeys = data )
  }

  onElementDeleted(index: number) {
    this.journeys.splice(index, 1);
  }

}
