import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainTableRowComponent } from './train-table-row.component';

describe('TrainTableRowComponent', () => {
  let component: TrainTableRowComponent;
  let fixture: ComponentFixture<TrainTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrainTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrainTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
