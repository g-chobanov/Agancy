import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FormDataService {

  formDataEmitter = new Subject<any>();
  raiseFormDataEmitter(data: any) { 
      this.formDataEmitter.next(data);
  }
}
