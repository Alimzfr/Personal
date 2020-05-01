import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {CollegeEducationModel, TrainingCourseModel} from '../education.model/education.model';
import {AuthService} from '../../../authentication/auth.service';

@Injectable({
  providedIn: 'root'
})
export class EducationService {
  constructor(private http: HttpClient,
              private authService: AuthService) {
  }

  getTrainingCourses(): Observable<TrainingCourseModel[]> {
    return this.http.get<TrainingCourseModel[]>('api/Education/GetTrainingCourses');
  }

  createTrainingCourse(trainingCourse: TrainingCourseModel): Observable<number> {
    return this.http.post<number>('api/Education/CreateTrainingCourse', trainingCourse);
  }

  updateTrainingCourse(trainingCourse: TrainingCourseModel): Observable<number> {
    return this.http.post<number>('api/Education/UpdateTrainingCourse', trainingCourse);
  }

  deleteTrainingCourses(ids: number[]): Observable<boolean> {
    return this.http.post<boolean>('api/Education/DeleteTrainingCourses', ids);
  }


  getCollegeEducations(): Observable<CollegeEducationModel[]> {
    return this.http.get<CollegeEducationModel[]>('api/Education/GetCollegeEducations');
  }

  createCollegeEducation(collegeEducation: CollegeEducationModel): Observable<number> {
    return this.http.post<number>('api/Education/CreateCollegeEducation', collegeEducation);
  }

  updateCollegeEducation(collegeEducation: CollegeEducationModel): Observable<number> {
    console.log(collegeEducation);
    return this.http.post<number>('api/Education/UpdateCollegeEducation', collegeEducation);
  }

  deleteCollegeEducations(ids: number[]): Observable<boolean> {
    return this.http.post<boolean>('api/Education/DeleteCollegeEducations', ids);
  }
}
