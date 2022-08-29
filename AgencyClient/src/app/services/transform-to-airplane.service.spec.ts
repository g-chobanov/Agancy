import { TestBed } from '@angular/core/testing';

import { TransformToAirplaneService } from './transform-to-airplane.service';

describe('TransformToAirplaneService', () => {
  let service: TransformToAirplaneService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransformToAirplaneService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
