import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusTableRowComponent } from './bus-table-row.component';

describe('BusTableRowComponent', () => {
  let component: BusTableRowComponent;
  let fixture: ComponentFixture<BusTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BusTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
