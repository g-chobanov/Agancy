import { TestBed } from '@angular/core/testing';

import { TransformToTicketService } from './transform-to-ticket.service';

describe('TransformToTicketService', () => {
  let service: TransformToTicketService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransformToTicketService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
