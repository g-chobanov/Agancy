import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IBus } from '../models/bus.model';
import { BusService } from '../services/bus.service';
import { TransformToBusService } from '../services/transform-to-bus.service';

@Component({
  selector: 'bus-form',
  templateUrl: './bus-form.component.html',
  styleUrls: ['./bus-form.component.css']
})
export class BusFormComponent  {

  @Input() isEditing: boolean = false;
  @Input() isCreating: boolean = false;
  @Input() editedRow!: string;

  @Output() formInfo = new EventEmitter();
  @Output() isCancelled = new EventEmitter();

  form: FormGroup;

  constructor(
    fb: FormBuilder, 
    private _busService: BusService, 
    private _transformService: TransformToBusService
    ) { 
    this.form = fb.group ({
      passengerCapacity: [],
      pricePerKilometer: []
    })
  }

  onCreate() {
    let newBus: IBus = this._transformService.transformFromForm(this.form);
    this._busService.create(newBus)
      .subscribe(data => { 
        console.log(data);
        this.formInfo.emit(this._transformService.transformFromJson(data));
        this.onCancel(); 
      });
   
  }

  onEdit() {
    let newBus: IBus = this._transformService.transformFromForm(this.form);
    newBus.id = this.editedRow;
    this._busService.update(newBus)
      .subscribe(data => { 
        this.formInfo.emit(this._transformService.transformFromJson(data));
        this.onCancel(); 
      });
  }

  onCancel() {
    this.isCancelled.emit();
  }

}
