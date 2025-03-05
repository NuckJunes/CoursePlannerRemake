import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleCreateEditComponent } from './schedule-create-edit.component';

describe('ScheduleCreateEditComponent', () => {
  let component: ScheduleCreateEditComponent;
  let fixture: ComponentFixture<ScheduleCreateEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ScheduleCreateEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScheduleCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
