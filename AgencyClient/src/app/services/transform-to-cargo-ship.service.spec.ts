import { TestBed } from '@angular/core/testing';

import { TransformToCargoShipService } from './transform-to-cargo-ship.service';

describe('TransformToCargoShipService', () => {
  let service: TransformToCargoShipService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransformToCargoShipService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
