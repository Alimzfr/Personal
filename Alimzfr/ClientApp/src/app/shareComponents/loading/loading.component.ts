import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent implements OnInit {
  @Input() size: number;
  @Input() isFullOverlay: boolean;
  @Input() isContainerOverlay: boolean;

  constructor() {
  }

  ngOnInit(): void {
  }

}
