import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CollegeEducationComponent } from './college-education.component';

describe('CollegeEducationComponent', () => {
  let component: CollegeEducationComponent;
  let fixture: ComponentFixture<CollegeEducationComponent>;

  beforeEach(async(() => {
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
