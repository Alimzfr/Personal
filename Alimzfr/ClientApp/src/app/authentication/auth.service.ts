import {Injectable} from '@angular/core';
import {AuthResponseModel, LoginModel, User} from './auth.model';
import {BehaviorSubject, Observable, throwError} from 'rxjs';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {CookieService} from 'ngx-cookie-service';
import {catchError} from 'rxjs/internal/operators';
import {tap} from 'rxjs/internal/operators/tap';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user = new BehaviorSubject<User>(null);

  constructor(private http: HttpClient,
              private cookie: CookieService) {
  }

  login(loginData: LoginModel): Observable<AuthResponseModel> {
    return this.http.post<AuthResponseModel>('api/Auth/Login', loginData)
      .pipe(
        // catchError(this.handleError),
        tap(response => this.handleAuthentication(response))
      );
  }

  autoLogin() {
    const authData: AuthResponseModel = JSON.parse(localStorage.getItem('alimzfr_user'));
    if (!authData) {
      return;
    }

    const loadedUser = new User(authData);
    if (loadedUser.accessToken) {
      this.user.next(loadedUser);
    }
  }

  loginWithRefreshToken(refToken: string) {
    return this.http.post<AuthResponseModel>('api/Auth/RefreshToken', {refreshToken: refToken})
      .pipe(
        // catchError(this.handleError),
        tap(response => this.handleAuthentication(response))
      );
  }

  logout() {
    const authData: AuthResponseModel = JSON.parse(localStorage.getItem('alimzfr_user'));
    if (authData) {
      return this.http.post<boolean>('api/Auth/Logout', {refreshToken: authData.refreshToken})
        .pipe(tap(res => {
          if (res) {
            localStorage.removeItem('alimzfr_user');
            this.cookie.delete('HangFireCookie');
            this.user.next(null);
          }
        }));
    } else {
      localStorage.removeItem('alimzfr_user');
      this.cookie.delete('HangFireCookie');
      this.user.next(null);
    }
  }

  private handleAuthentication(authData: AuthResponseModel) {
    const newUser = new User(authData);
    this.user.next(newUser);
    this.cookie.set('HangFireCookie', authData.accessToken);
    localStorage.setItem('alimzfr_user', JSON.stringify(authData));
  }

  // private handleError(errorRes: HttpErrorResponse) {
  //   let errorMessage = 'An unknown error occurred!';
  //   if (!errorRes.error || !errorRes.error.error) {
  //     return throwError(errorMessage);
  //   }
  //   switch (errorRes.error.error.message) {
  //     case 'EMAIL_EXISTS':
  //       errorMessage = 'This email exists already';
  //       break;
  //     case 'EMAIL_NOT_FOUND':
  //       errorMessage = 'This email does not exist.';
  //       break;
  //     case 'INVALID_PASSWORD':
  //       errorMessage = 'This password is not correct.';
  //       break;
  //   }
  //   return throwError(errorMessage);
  // }

}
