import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {CollegeEducationModel, EducationModel} from '../education.model/education.model';

@Injectable({
  providedIn: 'root'
})
export class EducationService {

  constructor(private http: HttpClient) {
  }

  getEducations(): Observable<EducationModel[]> {
    return this.http.get<EducationModel[]>('api/Content/GetEducations');
  }

  getCollegeEducations(): Observable<CollegeEducationModel[]> {
    return this.http.get<CollegeEducationModel[]>('api/Content/GetCollegeEducations');
  }
}
