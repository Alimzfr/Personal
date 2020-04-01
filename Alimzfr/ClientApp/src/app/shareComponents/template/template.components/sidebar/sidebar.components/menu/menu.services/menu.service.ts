import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MenuItemsModel} from '../menu.models/menu-Item.model';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor(private http: HttpClient) {
  }

  getMenuItems(): Observable<MenuItemsModel[]> {
    return this.http.get<MenuItemsModel[]>('api/Menu/GetMenuItems');
  }
}
