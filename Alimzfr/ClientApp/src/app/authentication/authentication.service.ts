import {Injectable} from '@angular/core';
import {LoginModel, TokenModel} from './authentication.model';
import {HttpClient} from '@angular/common/http';
import {tap} from 'rxjs/internal/operators/tap';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  public get loggedIn(): boolean {
    return localStorage.getItem('alimzfr_access_token') !== null;
  }

  constructor(private http: HttpClient) {
  }

  login(data: LoginModel) {
    return this.http.post<TokenModel>('api/User/Login', data)
      .pipe(tap(res => {
        localStorage.setItem('alimzfr_access_token', res.access_token);
      }));
  }

  logout() {
    localStorage.removeItem('alimzfr_access_token');
  }
}
