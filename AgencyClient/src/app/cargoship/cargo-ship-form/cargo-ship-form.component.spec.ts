import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CargoShipFormComponent } from './cargo-ship-form.component';

describe('CargoShipFormComponent', () => {
  let component: CargoShipFormComponent;
  let fixture: ComponentFixture<CargoShipFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CargoShipFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CargoShipFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
