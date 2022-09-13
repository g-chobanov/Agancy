import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AppError } from 'src/app/common/app-error';
import { BadRequestError } from 'src/app/common/bad-request-error';
import { ICargoShip } from '../../models/cargo-ship.model';
import { CargoShipService } from '../../services/cargo-ship.service';
import { TransformToCargoShipService } from '../../services/transform-to-cargo-ship.service';

@Component({
  selector: 'cargo-ship-form',
  templateUrl: './cargo-ship-form.component.html',
  styleUrls: ['./cargo-ship-form.component.css']
})
export class CargoShipFormComponent  {
  @Input() 
  isEditing: boolean = false;
  @Input()
  isCreating: boolean = false;

  //the id of the row that is being created/edited
  @Input() 
  editedRow!: string;

  @Output() 
  formInfo = new EventEmitter();
  @Output() 
  isCancelled = new EventEmitter();

  form: FormGroup;
  errorMessage?: string;

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
    this.errorMessage = undefined;
    let newCargoShip: ICargoShip = this._transformService.transformFromForm(this.form);
    this._cargoShipService.create(newCargoShip)
      .subscribe({
        next: (response) => { 
          this.formInfo.emit(this._transformService.transformFromJson(response));
          this.onCancel(); 
        }, 
        error : (error: AppError) => {
          if(error instanceof BadRequestError) {
            this.setErrors(error.originalError.errors);
          } else {
            throw error;
          }
        }
      });
   
  }

  onEdit() {
    this.errorMessage = undefined;
    let newCargoShip: ICargoShip = this._transformService.transformFromForm(this.form);
    newCargoShip.id = this.editedRow;
    this._cargoShipService.update(newCargoShip)
      .subscribe({
        next: (response) => { 
          this.formInfo.emit(this._transformService.transformFromJson(response));
          this.onCancel(); 
        }, 
        error : (error: AppError) => {
          if(error instanceof BadRequestError) {
            this.setErrors(error.originalError.errors);
          } else {
            throw error;
          }
        }
      });
  }

  onCancel() {
    this.isCancelled.emit();
  }

  private setErrors(errorMessage: any){
    let temp: string = " ";
    Object.keys(errorMessage).forEach( key => {
      temp += errorMessage[key] + "\n";
    });
    this.errorMessage = temp;

  }


}
