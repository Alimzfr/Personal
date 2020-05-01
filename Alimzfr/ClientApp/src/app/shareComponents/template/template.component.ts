import {
  AfterViewInit,
  Component,
  ElementRef,
  HostListener,
  OnInit,
  ViewChild
} from '@angular/core';
import {SidebarComponent} from './template.components/sidebar/sidebar.component';

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styleUrls: ['./template.component.scss']
})
export class TemplateComponent implements OnInit, AfterViewInit {
  sidebarIsOpen: boolean;
  windowInnerHeight: number;
  windowInnerWidth: number;
  @ViewChild(SidebarComponent, {read: ElementRef}) sidebarComponent: ElementRef;

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.windowInnerHeight = window.innerHeight;
    this.windowInnerWidth = window.innerWidth;
    this.sidebarComponent.nativeElement.style.height = this.windowInnerHeight + 'px';
  }

  constructor() {
  }


  ngOnInit(): void {
    this.windowInnerHeight = window.innerHeight;
    this.windowInnerWidth = window.innerWidth;
    this.sidebarIsOpen = window.innerWidth >= 768;
  }

  ngAfterViewInit(): void {
    this.sidebarComponent.nativeElement.style.height = this.windowInnerHeight + 'px';
  }

  sidebarToggleHandler() {
    this.sidebarIsOpen = !this.sidebarIsOpen;
    if (this.windowInnerWidth >= 768) {
      const windowResizeTrigger = setInterval(() => window.dispatchEvent(new Event('resize')), 10);
      setTimeout(() => clearInterval(windowResizeTrigger), 600);
    }
  }
}
