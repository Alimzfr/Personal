import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {SkillModel} from '../skills.models/skills.model';
import {Observable} from 'rxjs';
import {AuthService} from '../../../authentication/auth.service';

@Injectable({
  providedIn: 'root'
})
export class SkillsService {
  constructor(private http: HttpClient,
              private authService: AuthService) {
  }

  getSkills(): Observable<SkillModel[]> {
    return this.http.get<SkillModel[]>('api/Skill/GetSkills');
  }

  createSkill(skill: SkillModel): Observable<boolean> {
    return this.http.post<boolean>('api/Skill/CreateSkill', skill);
  }

  updateSkill(skill: SkillModel): Observable<boolean> {
    return this.http.post<boolean>('api/Skill/UpdateSkill', skill);
  }

  deleteSkills(ids: number[]): Observable<boolean> {
    return this.http.post<boolean>('api/Skill/DeleteSkills', ids);
  }
}
