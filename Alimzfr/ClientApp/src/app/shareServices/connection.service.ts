import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {

  constructor(private http: HttpClient) {
  }

  isOnline(): Observable<void> {
    return this.http.get<void>('api/Connection/CheckConnection');
  }
}
