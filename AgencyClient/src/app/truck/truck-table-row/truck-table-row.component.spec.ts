import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TruckTableRowComponent } from './truck-table-row.component';

describe('TruckTableRowComponent', () => {
  let component: TruckTableRowComponent;
  let fixture: ComponentFixture<TruckTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TruckTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TruckTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
