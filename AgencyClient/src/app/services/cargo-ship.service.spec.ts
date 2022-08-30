import { TestBed } from '@angular/core/testing';
import { CargoShipService } from './cargo-ship.service';

describe('CargoShipService', () => {
  let service: CargoShipService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CargoShipService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
