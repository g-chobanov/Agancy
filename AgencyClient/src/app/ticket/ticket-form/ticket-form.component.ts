import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AppError } from 'src/app/common/app-error';
import { BadRequestError } from 'src/app/common/bad-request-error';
import { IJourney } from '../../models/journey.model';
import { ITicket } from '../../models/ticket.model';
import { JourneyService } from '../../services/journey.service';
import { TicketService } from '../../services/ticket.service';
import { TransformToTicketService } from '../../services/transform-to-ticket.service';

@Component({
  selector: 'ticket-form',
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.css']
})
export class TicketFormComponent implements OnInit {

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

  availableJourneys!: IJourney[];
  showPrice: boolean = false;
  showJourneyInfo: boolean = false;
  errorMessage?: string;

  form: FormGroup;
  constructor(
    fb: FormBuilder, 
    private _ticketService: TicketService, 
    private _transformService: TransformToTicketService,
    private _journeyService: JourneyService,
    ) { 
    this.form = fb.group ({
      administrativeCosts: [],
      journeyID: []
    })
  }
  ngOnInit(): void {
    this._journeyService.getAll()
      .subscribe(data => this.availableJourneys = data);
  }

  onCreate() {
    this.errorMessage = undefined;
    let newTicket: ITicket = this._transformService.transformFromForm(this.form);
    this._ticketService.create(newTicket)
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
    let newTicket: ITicket = this._transformService.transformFromForm(this.form);
    this._ticketService.update(newTicket)
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
