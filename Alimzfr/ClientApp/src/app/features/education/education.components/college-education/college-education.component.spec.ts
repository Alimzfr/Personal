import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { CollegeEducationComponent } from './college-education.component';

describe('CollegeEducationComponent', () => {
  let component: CollegeEducationComponent;
  let fixture: ComponentFixture<CollegeEducationComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ CollegeEducationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CollegeEducationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
