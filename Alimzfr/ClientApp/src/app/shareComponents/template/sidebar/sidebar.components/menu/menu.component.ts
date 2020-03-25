import { Component, OnInit } from '@angular/core';
import {MenuItemsModel} from '../../sidebar.models/menu-items-model';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  menuItems: MenuItemsModel[];
  constructor() { }

  ngOnInit(): void {
    this.menuItems = [
      {id: 1, title: 'Home', link: 'Home'},
      {id: 2, title: 'About', link: 'About'},
      {id: 3, title: 'Education', link: 'Education'},
      {id: 4, title: 'Experience', link: 'Experience'},
      {id: 5, title: 'Skills', link: 'Skills'},
      {id: 6, title: 'Contact', link: 'Contact'},
      {id: 7, title: 'Blog', link: 'Blog'},
    ];
  }

}
