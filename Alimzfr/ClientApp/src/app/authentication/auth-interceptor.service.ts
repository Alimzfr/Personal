import {Injectable} from '@angular/core';
import {AuthService} from './auth.service';
import {HttpErrorResponse, HttpHandler, HttpHeaders, HttpRequest} from '@angular/common/http';
import {catchError, take} from 'rxjs/operators';
import {exhaustMap} from 'rxjs/internal/operators/exhaustMap';
import {CookieService} from 'ngx-cookie-service';
import {of} from 'rxjs/internal/observable/of';
import {throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService {

  constructor(private authService: AuthService,
              private cookie: CookieService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    return this.authService.user.pipe(
      take(1),
      exhaustMap(user => {
        if (!user) {
          return next.handle(req);
        }
        const modifiedReq = req.clone({
          headers: new HttpHeaders()
            .append('X-XSRF-TOKEN', this.cookie.get('XSRF-TOKEN'))
            .append('Authorization', 'Bearer ' + user.accessToken)
        });
        return next.handle(modifiedReq).pipe(
          catchError((error: HttpErrorResponse) => {
            if (error.status === 401) {
              this.authService.logout().subscribe();
            }
            return throwError(error);
          })
        );
      })
    );
  }
}
