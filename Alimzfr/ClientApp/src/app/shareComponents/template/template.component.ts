import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styleUrls: ['./template.component.scss']
})
export class TemplateComponent implements OnInit {
  sidebarIsOpen: boolean;

  constructor() {
  }

  ngOnInit(): void {
    this.sidebarIsOpen = true;
  }

  sidebarToggleHandler() {
    this.sidebarIsOpen = !this.sidebarIsOpen;
  }
}
