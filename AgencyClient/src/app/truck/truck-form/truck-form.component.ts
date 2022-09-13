import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AppError } from 'src/app/common/app-error';
import { BadRequestError } from 'src/app/common/bad-request-error';
import { ITruck } from '../../models/truck.model';
import { TransformToTruckService } from '../../services/transform-to-truck.service';
import { TruckService } from '../../services/truck.service';

@Component({
  selector: 'truck-form',
  templateUrl: './truck-form.component.html',
  styleUrls: ['./truck-form.component.css']
})
export class TruckFormComponent {

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
    this.errorMessage = undefined;
    let newTruck: ITruck = this._transformService.transformFromForm(this.form);
    this._truckService.create(newTruck)
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
    let newTruck: ITruck = this._transformService.transformFromForm(this.form);
    newTruck.id = this.editedRow;
    this._truckService.update(newTruck)
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
