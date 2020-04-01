import {Injectable} from '@angular/core';
import {UserCommentModel} from '../contact.models/contact.model';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) {
  }

  sendComment(userComment: UserCommentModel): Observable<number> {
    const model: UserCommentModel = {
      ...userComment,
      userAgentInfo: navigator.userAgent
    };
    return this.http.post<number>('api/Contact/SendComment', model);
  }
}
