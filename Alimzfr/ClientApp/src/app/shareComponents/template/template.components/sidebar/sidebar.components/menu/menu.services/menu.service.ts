import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MenuItemsModel} from '../menu.models/menu-Item.model';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor(private http: HttpClient) {
  }

  getMenuItems() {
    return this.http.get<MenuItemsModel[]>('api/Content/GetMenuItems');
  }
}
