import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AirplaneService } from '../services/airplane.service';
import { IAirplane } from '../models/airplane.model';
import { FormDataService } from '../services/form-data.service';

@Component({
  selector: 'airplane-form',
  templateUrl: './airplane-form.component.html',
  styleUrls: ['./airplane-form.component.css']
})
export class AirplaneFormComponent implements OnInit {
  @Input() isEditing: boolean = false;
  @Input() isCreating: boolean = false;

  @Output() formInfo = new EventEmitter();
  @Output() isCancelled = new EventEmitter();

  //add outputs

  form: FormGroup;
  constructor(fb: FormBuilder, private _airplaneService: AirplaneService, private _formDataService: FormDataService) { 
    this.form = fb.group ({
      passengerCapacity: [],
      pricePerKilometer: [],
      hasFreeFood: []
    })
  }

  ngOnInit(): void {
  }

  onSubmit() {
    let newAirplane: IAirplane = this.formToAirplane();
    this.formInfo.emit(newAirplane);
  }

  onCancel() {
    this.isCancelled.emit();
  }

  private formToAirplane(){
    let newAirplane: IAirplane = { 
      passengerCapacity: this.form.get('passengerCapacity')?.value,
      pricePerKilometer: this.form.get('pricePerKilometer')?.value,
      hasFreeFood: this.form.get('hasFreeFood')?.value };
    return newAirplane;
  }

}
