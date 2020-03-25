import {Component, EventEmitter, OnInit, Output} from '@angular/core';


@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  @Output() sidebarToggle = new EventEmitter();

  constructor() {
  }

  ngOnInit(): void {
  }

  sidebarToggleHandler() {
    this.sidebarToggle.emit();
  }
}
