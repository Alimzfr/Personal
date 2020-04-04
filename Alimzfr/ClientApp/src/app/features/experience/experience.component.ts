import {Component, OnInit} from '@angular/core';
import {ExperienceModel} from './experience.models/experience.model';
import {ExperienceService} from './experience.services/experience.service';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.scss']
})
export class ExperienceComponent implements OnInit {
  experiences: ExperienceModel[];
  loading: boolean;

  constructor(private service: ExperienceService) {
  }

  ngOnInit(): void {
    this.loading = true;
    this.getExperiences();
  }


  getExperiences() {
    this.service.getExperiences().subscribe(value => {
      this.experiences = value;
      this.loading = false;
    }, error => {
      console.log(error);
      this.loading = false;
    });
  }

}
