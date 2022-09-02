import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CargoShipTableComponent } from './cargo-ship-table.component';

describe('CargoShipTableComponent', () => {
  let component: CargoShipTableComponent;
  let fixture: ComponentFixture<CargoShipTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CargoShipTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CargoShipTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
