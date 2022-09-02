import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleTableRowComponent } from './vehicle-table-row.component';

describe('VehicleTableRowComponent', () => {
  let component: VehicleTableRowComponent;
  let fixture: ComponentFixture<VehicleTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VehicleTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicleTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
