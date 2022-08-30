import { Component, OnInit } from '@angular/core';
import { EntityType } from '../entity-type.enum';
import { ITrain } from '../models/train.model';
import { TrainService } from '../services/train.service';

@Component({
  selector: 'train-table',
  templateUrl: './train-table.component.html',
  styleUrls: ['./train-table.component.css']
})
export class TrainTableComponent implements OnInit {

  trains!: ITrain[];
  entityType: EntityType = EntityType.Train;

  constructor(private _service: TrainService) {
    
  }

  ngOnInit(): void {
    this._service.getAll()
      .subscribe(data => this.trains = data )
  }

  onElementDeleted(index: number) {
    this.trains.splice(index, 1);
  }

}
