import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ITrain } from '../models/train.model';
import { TrainService } from '../services/train.service';
import { TransformToTrainService } from '../services/transform-to-train.service';

@Component({
  selector: 'train-form',
  templateUrl: './train-form.component.html',
  styleUrls: ['./train-form.component.css']
})
export class TrainFormComponent {

  @Input() isEditing: boolean = false;
  @Input() isCreating: boolean = false;
  @Input() editedRow!: string;

  @Output() formInfo = new EventEmitter();
  @Output() isCancelled = new EventEmitter();

  form: FormGroup;
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
    let newTrain: ITrain = this._transformService.formToTrain(this.form);
    this._trainService.create(newTrain)
      .subscribe(data => { 
        this.formInfo.emit(this._transformService.jsonToTrain(data));
        this.onCancel(); 
      });
   
  }

  onEdit() {
    let newTrain: ITrain = this._transformService.formToTrain(this.form);
    newTrain.id = this.editedRow;
    this._trainService.update(newTrain)
      .subscribe(data => { 
        this.formInfo.emit(this._transformService.jsonToTrain(data));
        this.onCancel(); 
      });
  }

  onCancel() {
    this.isCancelled.emit();
  }

}
