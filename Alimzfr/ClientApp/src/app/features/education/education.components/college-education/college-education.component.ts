import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {CollegeEducationModel} from '../../education.model/education.model';
import {EducationService} from '../../education.services/education.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {AuthService} from '../../../../authentication/auth.service';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-college-education',
  templateUrl: './college-education.component.html',
  styleUrls: ['./college-education.component.scss']
})
export class CollegeEducationComponent implements OnInit, OnDestroy {
  @Input() collegeEducation: CollegeEducationModel;
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

  createCollegeEducation(collegeEducation: CollegeEducationModel) {
    this.service.createCollegeEducation(collegeEducation).subscribe(value => {
    }, error => {
      console.log(error);
    });
  }

  updateCollegeEducation() {
    console.log(this.collegeEducation);
    this.service.updateCollegeEducation(this.collegeEducation).subscribe(value => {
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

  deleteCollegeEducations(ids: number[]) {
    this.service.deleteCollegeEducations(ids).subscribe(value => {
    }, error => {
      console.log(error);
    });
  }

}
