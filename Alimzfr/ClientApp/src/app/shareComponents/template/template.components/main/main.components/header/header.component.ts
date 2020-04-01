import {Component, OnInit, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Output() sidebarToggle = new EventEmitter();

  constructor() {
  }

  ngOnInit(): void {
  }

  sidebarToggleHandler() {
    this.sidebarToggle.emit();
  }

}
