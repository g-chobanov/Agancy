import { TestBed } from '@angular/core/testing';

import { TransformToTruckService } from './transform-to-truck.service';

describe('TransformToTruckService', () => {
  let service: TransformToTruckService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransformToTruckService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
