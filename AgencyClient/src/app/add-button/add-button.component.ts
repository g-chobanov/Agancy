import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EntityType } from '../entity-type.enum';
import { IAirplane } from '../models/airplane.model';

@Component({
  selector: 'add-button',
  templateUrl: './add-button.component.html',
  styleUrls: ['./add-button.component.css']
})
export class AddButtonComponent {
  @Input() entityType!: EntityType;
  @Input() tableElements!: any[];

  allEntityTypes = EntityType;
  isCreating: boolean = false;

  constructor() {

  }

  onAdd() {
    this.isCreating = true;
  }

  onFormCancelled() {
    this.isCreating = false;
  }

  onFormSubmitted(formInfo: IAirplane) {
    console.log(formInfo)
    this.tableElements.push(formInfo);
  }
}
