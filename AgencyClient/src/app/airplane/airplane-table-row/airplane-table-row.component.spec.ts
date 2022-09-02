import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AirplaneTableRowComponent } from './airplane-table-row.component';

describe('AirplaneTableRowComponent', () => {
  let component: AirplaneTableRowComponent;
  let fixture: ComponentFixture<AirplaneTableRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AirplaneTableRowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AirplaneTableRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
