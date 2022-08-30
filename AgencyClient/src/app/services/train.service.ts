import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ITrain } from '../models/train.model';
import { ModelService } from './model.service';

@Injectable({
  providedIn: 'root'
})
export class TrainService extends ModelService<ITrain>{
  constructor(http: HttpClient) { 
    super
    (
      http, 
      "/Train/GetAllTrains", 
      "/Train/CreateTrain",
      "/Train/DeleteTrain",
      "/Train/UpdateTrain"
    )
  }
}
