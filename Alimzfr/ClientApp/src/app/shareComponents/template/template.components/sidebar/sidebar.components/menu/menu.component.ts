import {Component, OnInit} from '@angular/core';
import {MenuItemsModel} from './menu.models/menu-Item.model';
import {MenuService} from './menu.services/menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  menuItems: MenuItemsModel[];

  constructor(private service: MenuService) {
  }

  ngOnInit(): void {
    this.getMenuItems();
  }

  private getMenuItems() {
    this.service.getMenuItems().subscribe(value => {
      this.menuItems = value;
    });
  }
}
