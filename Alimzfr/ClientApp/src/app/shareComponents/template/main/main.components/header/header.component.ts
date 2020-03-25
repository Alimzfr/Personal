import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {fas} from '@fortawesome/free-solid-svg-icons';
import {far} from '@fortawesome/free-regular-svg-icons';
import {fab} from '@fortawesome/free-brands-svg-icons';
import {FaIconLibrary} from '@fortawesome/angular-fontawesome';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Output() sidebarToggle = new EventEmitter();

  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas, far, fab);
  }

  ngOnInit(): void {
  }

  sidebarToggleHandler() {
    this.sidebarToggle.emit();
  }


}
