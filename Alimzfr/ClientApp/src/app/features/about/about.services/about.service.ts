import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, Subscription} from 'rxjs';
import {AboutModel} from '../about.models/about.model';

@Injectable({
  providedIn: 'root'
})
export class AboutService {
  constructor(private http: HttpClient) {
  }

  getAbouts(): Observable<AboutModel[]> {
    return this.http.get<AboutModel[]>('api/About/GetAbouts');
  }

  updateAbout(about: AboutModel): Observable<number> {
    return this.http.post<number>('api/About/UpdateAbout', about);
  }
}
