import {Component, OnDestroy, OnInit} from '@angular/core';
import {ExperienceModel} from './experience.models/experience.model';
import {ExperienceService} from './experience.services/experience.service';
import {Subscription} from 'rxjs';
import {MatSnackBar} from '@angular/material/snack-bar';
import {AuthService} from '../../authentication/auth.service';
import {ConnectionService} from '../../shareServices/connection.service';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.scss']
})
export class ExperienceComponent implements OnInit, OnDestroy {
  experiences: ExperienceModel[];
  loading: boolean;
  isAuthenticated = false;
  private userSub: Subscription;
  isOnline: boolean;

  constructor(private service: ExperienceService,
              private message: MatSnackBar,
              private authService: AuthService,
              private connection: ConnectionService) {
    this.isOnline = true;
  }

  ngOnInit(): void {
    this.userSub = this.authService.user.subscribe(user => {
      this.isAuthenticated = !!user;
    });
    this.loading = true;
    this.getExperiences();
    this.connection.isOnline().subscribe(() => {
      this.isOnline = true;
    }, error => {
      this.isOnline = false;
    });
  }

  ngOnDestroy(): void {
    this.userSub.unsubscribe();
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

  createExperience(experience: ExperienceModel) {
    this.service.createExperience(experience).subscribe(value => {
    }, error => {
      console.log(error);
    });
  }

  updateExperience(experience: ExperienceModel) {
    this.service.updateExperience(experience).subscribe(value => {
    }, error => {
      console.log(error);
    });
  }

  deleteExperiences() {
    this.service.deleteExperiences([1, 2, 3]).subscribe(value => {
    }, error => {
      console.log(error);
    });
  }

}
