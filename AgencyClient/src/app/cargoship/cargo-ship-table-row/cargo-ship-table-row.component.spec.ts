import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CargoShipTableRowComponent } from './cargo-ship-table-row.component';

describe('CargoShipTableRowComponent', () => {
  let component: CargoShipTableRowComponent;
  let fixture: ComponentFixture<CargoShipTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CargoShipTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CargoShipTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
