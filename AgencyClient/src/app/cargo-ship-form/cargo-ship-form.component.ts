import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ICargoShip } from '../models/cargo-ship.model';
import { CargoShipService } from '../services/cargo-ship.service';
import { TransformToCargoShipService } from '../services/transform-to-cargo-ship.service';

@Component({
  selector: 'cargo-ship-form',
  templateUrl: './cargo-ship-form.component.html',
  styleUrls: ['./cargo-ship-form.component.css']
})
export class CargoShipFormComponent  {
  @Input() isEditing: boolean = false;
  @Input() isCreating: boolean = false;
  @Input() editedRow!: string;

  @Output() formInfo = new EventEmitter();
  @Output() isCancelled = new EventEmitter();

  form: FormGroup;

  constructor(
    fb: FormBuilder, 
    private _cargoShipService: CargoShipService, 
    private _transformService: TransformToCargoShipService
    ) { 
    this.form = fb.group ({
      passengerCapacity: [],
      pricePerKilometer: [],
      storage: [],
    })
  }

  onCreate() {
    let newCargoShip: ICargoShip = this._transformService.transformFromForm(this.form);
    this._cargoShipService.create(newCargoShip)
      .subscribe(data => { 
        console.log(data);
        this.formInfo.emit(this._transformService.transformFromJson(data));
        this.onCancel(); 
      });
   
  }

  onEdit() {
    let newCargoShip: ICargoShip = this._transformService.transformFromForm(this.form);
    newCargoShip.id = this.editedRow;
    this._cargoShipService.update(newCargoShip)
      .subscribe(data => { 
        this.formInfo.emit(this._transformService.transformFromJson(data));
        this.onCancel(); 
      });
  }

  onCancel() {
    this.isCancelled.emit();
  }


}
