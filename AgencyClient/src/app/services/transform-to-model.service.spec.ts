import { TestBed } from '@angular/core/testing';

import { TransformToModelService } from './transform-to-model.service';

describe('TransformToModelService', () => {
  let service: TransformToModelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransformToModelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
