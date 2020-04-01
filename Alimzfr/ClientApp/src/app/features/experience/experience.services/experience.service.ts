import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ExperienceModel} from '../experience.models/experience.model';

@Injectable({
  providedIn: 'root'
})
export class ExperienceService {

  constructor(private http: HttpClient) {
  }

  getExperiences(): Observable<ExperienceModel[]> {
    return this.http.get<ExperienceModel[]>('api/Experience/GetExperiences');
  }
}
