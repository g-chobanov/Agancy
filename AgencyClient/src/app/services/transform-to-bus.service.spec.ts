import { TestBed } from '@angular/core/testing';

import { TransformToBusService } from './transform-to-bus.service';

describe('TransformToBusService', () => {
  let service: TransformToBusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransformToBusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
