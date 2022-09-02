import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JourneyTableRowComponent } from './journey-table-row.component';

describe('JourneyTableRowComponent', () => {
  let component: JourneyTableRowComponent;
  let fixture: ComponentFixture<JourneyTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JourneyTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JourneyTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
