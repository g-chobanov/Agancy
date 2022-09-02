import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ITruck } from '../models/truck.model';
import { TransformToTruckService } from '../services/transform-to-truck.service';
import { TruckService } from '../services/truck.service';

@Component({
  selector: 'truck-form',
  templateUrl: './truck-form.component.html',
  styleUrls: ['./truck-form.component.css']
})
export class TruckFormComponent {

  @Input() isEditing: boolean = false;
  @Input() isCreating: boolean = false;
  @Input() editedRow!: string;

  @Output() formInfo = new EventEmitter();
  @Output() isCancelled = new EventEmitter();

  form: FormGroup;
  constructor(
    fb: FormBuilder, 
    private _truckService: TruckService, 
    private _transformService: TransformToTruckService
    ) { 
    this.form = fb.group ({
      passengerCapacity: [],
      pricePerKilometer: [],
      storage: []
    })
  }

  onCreate() {
    let newTruck: ITruck = this._transformService.transformFromForm(this.form);
    this._truckService.create(newTruck)
      .subscribe(data => { 
        this.formInfo.emit(this._transformService.transformFromJson(data));
        this.onCancel(); 
      });
   
  }

  onEdit() {
    let newTruck: ITruck = this._transformService.transformFromForm(this.form);
    newTruck.id = this.editedRow;
    this._truckService.update(newTruck)
      .subscribe(data => { 
        this.formInfo.emit(this._transformService.transformFromJson(data));
        this.onCancel(); 
      });
  }

  onCancel() {
    this.isCancelled.emit();
  }

}
