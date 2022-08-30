import { TestBed } from '@angular/core/testing';

import { TransformToTrainService } from './transform-to-train.service';

describe('TransformToTrainService', () => {
  let service: TransformToTrainService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransformToTrainService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
