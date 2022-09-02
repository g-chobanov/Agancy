import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketTableRowComponent } from './ticket-table-row.component';

describe('TicketTableRowComponent', () => {
  let component: TicketTableRowComponent;
  let fixture: ComponentFixture<TicketTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TicketTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
