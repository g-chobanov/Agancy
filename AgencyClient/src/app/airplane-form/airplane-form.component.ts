import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AirplaneService } from '../services/airplane.service';
import { IAirplane } from '../models/airplane.model';
import { TransformToAirplaneService } from '../services/transform-to-airplane.service';

@Component({
  selector: 'airplane-form',
  templateUrl: './airplane-form.component.html',
  styleUrls: ['./airplane-form.component.css']
})
export class AirplaneFormComponent  {
  @Input() isEditing: boolean = false;
  @Input() isCreating: boolean = false;
  @Input() editedRow!: string;

  @Output() formInfo = new EventEmitter();
  @Output() isCancelled = new EventEmitter();

  form: FormGroup;
  constructor(
    fb: FormBuilder, 
    private _airplaneService: AirplaneService, 
    private _transformService: TransformToAirplaneService
    ) { 
    this.form = fb.group ({
      passengerCapacity: [],
      pricePerKilometer: [],
      hasFreeFood: []
    })
  }

  onCreate() {
    let newAirplane: IAirplane = this._transformService.formToAirplane(this.form);
    this._airplaneService.create(newAirplane)
      .subscribe(data => { 
        this.formInfo.emit(this._transformService.jsonToAirplane(data));
        this.onCancel(); 
      });
   
  }

  onEdit() {
    let newAirplane: IAirplane = this._transformService.formToAirplane(this.form);
    newAirplane.id = this.editedRow;
    this._airplaneService.update(newAirplane)
      .subscribe(data => { 
        this.formInfo.emit(this._transformService.jsonToAirplane(data));
        this.onCancel(); 
      });
  }

  onCancel() {
    this.isCancelled.emit();
  }

}
