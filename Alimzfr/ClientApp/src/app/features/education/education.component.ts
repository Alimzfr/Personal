import {Component, OnInit} from '@angular/core';
import {EducationModel, CollegeEducationModel} from './education.model/education.model';
import {EducationService} from './education.services/education.service';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss']
})
export class EducationComponent implements OnInit {
  educations: EducationModel[];
  collegeEducations: CollegeEducationModel[];

  constructor(private service: EducationService) {
  }

  ngOnInit(): void {
    this.getEducations();
    this.getCollegeEducations();
  }

  getEducations() {
    this.service.getEducations().subscribe(value => {
      this.educations = value;
    });
  }

  getCollegeEducations() {
    this.service.getCollegeEducations().subscribe(value => {
      this.collegeEducations = value;
    });
  }

}
