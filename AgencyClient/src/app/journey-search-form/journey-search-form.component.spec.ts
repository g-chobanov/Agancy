import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JourneySearchFormComponent } from './journey-search-form.component';

describe('JourneySearchFormComponent', () => {
  let component: JourneySearchFormComponent;
  let fixture: ComponentFixture<JourneySearchFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JourneySearchFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JourneySearchFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
