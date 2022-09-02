import { TestBed } from '@angular/core/testing';

import { TransformToJourneyService } from './transform-to-journey.service';

describe('TransformToJourneyService', () => {
  let service: TransformToJourneyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransformToJourneyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
