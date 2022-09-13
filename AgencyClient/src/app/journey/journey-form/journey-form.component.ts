import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AppError } from 'src/app/common/app-error';
import { BadRequestError } from 'src/app/common/bad-request-error';
import { IJourney } from '../../models/journey.model';
import { IVehicle } from '../../models/vehicle.model';
import { JourneyService } from '../../services/journey.service';
import { TransformToJourneyService } from '../../services/transform-to-journey.service';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'journey-form',
  templateUrl: './journey-form.component.html',
  styleUrls: ['./journey-form.component.css']
})
export class JourneyFormComponent implements OnInit {

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

  availableVehicles!: IVehicle[];
  showPrice: boolean = false;
  showVehicleInfo: boolean = false;
  errorMessage?: string;

  form: FormGroup;
  constructor(
    fb: FormBuilder, 
    private _journeyService: JourneyService, 
    private _transformService: TransformToJourneyService,
    private _vehicleService: VehicleService,
    ) { 
    this.form = fb.group ({
      startLocation: [],
      destination: [],
      distance: [],
      vehicleID: []
    })
  }
  ngOnInit(): void {
    this._vehicleService.getAllVehicles()
      .subscribe(data => this.availableVehicles = data);
  }

  onCreate() {
    this.errorMessage = undefined;
    let newJourney: IJourney = this._transformService.transformFromForm(this.form);
    this._journeyService.create(newJourney)
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
    let newJourney: IJourney = this._transformService.transformFromForm(this.form);
    newJourney.id = this.editedRow;
    this._journeyService.update(newJourney)
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
