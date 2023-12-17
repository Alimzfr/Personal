import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TrainingCourseComponent } from './training-course.component';

describe('TrainingCourseComponent', () => {
  let component: TrainingCourseComponent;
  let fixture: ComponentFixture<TrainingCourseComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainingCourseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainingCourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
