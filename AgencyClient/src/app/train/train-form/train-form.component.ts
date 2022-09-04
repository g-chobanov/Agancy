import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AppError } from 'src/app/common/app-error';
import { BadRequestError } from 'src/app/common/bad-request-error';
import { ITrain } from '../../models/train.model';
import { TrainService } from '../../services/train.service';
import { TransformToTrainService } from '../../services/transform-to-train.service';

@Component({
  selector: 'train-form',
  templateUrl: './train-form.component.html',
  styleUrls: ['./train-form.component.css']
})
export class TrainFormComponent {

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
    private _trainService: TrainService, 
    private _transformService: TransformToTrainService
    ) { 
    this.form = fb.group ({
      passengerCapacity: [],
      pricePerKilometer: [],
      carts: []
    })
  }

  onCreate() {
    this.errorMessage = undefined;
    let newTrain: ITrain = this._transformService.transformFromForm(this.form);
    this._trainService.create(newTrain)
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
    let newTrain: ITrain = this._transformService.transformFromForm(this.form);
    this._trainService.update(newTrain)
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
