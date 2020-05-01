import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ExperienceModel} from '../experience.models/experience.model';
import {AuthService} from '../../../authentication/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ExperienceService {
  constructor(private http: HttpClient,
              private authService: AuthService) {
  }

  getExperiences(): Observable<ExperienceModel[]> {
    return this.http.get<ExperienceModel[]>('api/Experience/GetExperiences');
  }

  createExperience(experience: ExperienceModel) {
    return this.http.post<boolean>('api/Experience/CreateExperience', experience);
  }

  updateExperience(experience: ExperienceModel) {
    return this.http.post<boolean>('api/Experience/UpdateExperience', experience);
  }

  deleteExperiences(ids: number[]): Observable<boolean> {
    return this.http.post<boolean>('api/Experience/DeleteExperiences', ids);
  }
}
