import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {SkillModel} from '../skills.models/skills.model';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SkillsService {

  constructor(private http: HttpClient) {
  }

  getSkills(): Observable<SkillModel[]> {
    return this.http.get<SkillModel[]>('api/Content/GetSkills');
  }
}
