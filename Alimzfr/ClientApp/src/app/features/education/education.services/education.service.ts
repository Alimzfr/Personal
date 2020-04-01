import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {CollegeEducationModel, TrainingCourseModel} from '../education.model/education.model';

@Injectable({
  providedIn: 'root'
})
export class EducationService {

  constructor(private http: HttpClient) {
  }

  getEducations(): Observable<TrainingCourseModel[]> {
    return this.http.get<TrainingCourseModel[]>('api/Education/GetTrainingCourses');
  }

  getCollegeEducations(): Observable<CollegeEducationModel[]> {
    return this.http.get<CollegeEducationModel[]>('api/Education/GetCollegeEducations');
  }
}
