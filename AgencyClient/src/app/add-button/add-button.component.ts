import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EntityType } from '../entity-type.enum';

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

  onAdd() {
    this.isCreating = true;
  }

  onFormCancelled() {
    this.isCreating = false;
  }

  onFormSubmitted(formInfo: any) {
    this.tableElements.push(formInfo);
  }
}
