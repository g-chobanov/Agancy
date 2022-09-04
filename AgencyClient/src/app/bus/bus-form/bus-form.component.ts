import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AppError } from 'src/app/common/app-error';
import { BadRequestError } from 'src/app/common/bad-request-error';
import { IBus } from '../../models/bus.model';
import { BusService } from '../../services/bus.service';
import { TransformToBusService } from '../../services/transform-to-bus.service';

@Component({
  selector: 'bus-form',
  templateUrl: './bus-form.component.html',
  styleUrls: ['./bus-form.component.css']
})
export class BusFormComponent  {

  @Input() 
  isEditing: boolean = false;
  @Input() 
  isCreating: boolean = false;
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
    private _busService: BusService, 
    private _transformService: TransformToBusService
    ) { 
    this.form = fb.group ({
      passengerCapacity: [],
      pricePerKilometer: []
    })
  }

  onCreate() {
    this.errorMessage = undefined;
    let newBus: IBus = this._transformService.transformFromForm(this.form);
    this._busService.create(newBus)
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
    let newBus: IBus = this._transformService.transformFromForm(this.form);
    this._busService.update(newBus)
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
