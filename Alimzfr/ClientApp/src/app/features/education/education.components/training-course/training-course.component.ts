import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {TrainingCourseModel} from '../../education.model/education.model';
import {EducationService} from '../../education.services/education.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {AuthService} from '../../../../authentication/auth.service';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-training-course',
  templateUrl: './training-course.component.html',
  styleUrls: ['./training-course.component.scss']
})
export class TrainingCourseComponent implements OnInit, OnDestroy {
  @Input() trainingCourse: TrainingCourseModel;
  isAuthenticated = false;
  private userSub: Subscription;

  constructor(private service: EducationService,
              private message: MatSnackBar,
              private authService: AuthService) {
  }

  ngOnInit(): void {
    this.userSub = this.authService.user.subscribe(user => {
      this.isAuthenticated = !!user;
    });
  }

  ngOnDestroy(): void {
    this.userSub.unsubscribe();
  }

  createTrainingCourse(trainingCourse: TrainingCourseModel) {
    this.service.createTrainingCourse(trainingCourse).subscribe(value => {
    }, error => {
      console.log(error);
    });
  }

  updateTrainingCourse() {
    this.service.updateTrainingCourse(this.trainingCourse).subscribe(value => {
      this.message.open('Update Success', '×', {
        duration: 5000,
        panelClass: ['alimzfr-message-success'],
        verticalPosition: 'top',
      });
    }, error => {
      if (error.status === 401) {
        this.message.open('Access Denied', '×', {
          duration: 5000,
          panelClass: 'alimzfr-message-error',
          verticalPosition: 'top',
        });
      } else {
        this.message.open('Error Occurred', '×', {
          duration: 5000,
          panelClass: 'alimzfr-message-error',
          verticalPosition: 'top',
        });
      }
    });
  }

  deleteTrainingCourses(ids: number[]) {
    this.service.deleteTrainingCourses(ids).subscribe(value => {
    }, error => {
      console.log(error);
    });
  }
}
