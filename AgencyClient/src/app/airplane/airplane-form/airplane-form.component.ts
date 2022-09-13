import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AirplaneService } from '../../services/airplane.service';
import { IAirplane } from '../../models/airplane.model';
import { TransformToAirplaneService } from '../../services/transform-to-airplane.service';
import { AppError } from '../../common/app-error';
import { BadRequestError } from '../../common/bad-request-error';

@Component({
  selector: 'airplane-form',
  templateUrl: './airplane-form.component.html',
  styleUrls: ['./airplane-form.component.css']
})
export class AirplaneFormComponent  {
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
    this.errorMessage = undefined;
    let newAirplane: IAirplane = this._transformService.transformFromForm(this.form);
    this._airplaneService.create(newAirplane)
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
    let newAirplane: IAirplane = this._transformService.transformFromForm(this.form);
    newAirplane.id = this.editedRow;
    this._airplaneService.update(newAirplane)
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
