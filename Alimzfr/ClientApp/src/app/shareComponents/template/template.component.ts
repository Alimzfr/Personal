import {
  AfterViewInit,
  Component,
  ElementRef,
  HostListener,
  OnInit,
  Renderer2,
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
  @ViewChild(SidebarComponent, {read: ElementRef}) sidebarComponent: ElementRef;
  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.windowInnerHeight = window.innerHeight;
    this.sidebarComponent.nativeElement.style.height = this.windowInnerHeight + 'px';
  }

  constructor(private renderer: Renderer2) {
  }

  ngOnInit(): void {
    this.sidebarIsOpen = true;
    this.windowInnerHeight = window.innerHeight;
  }

  ngAfterViewInit(): void {
    this.sidebarComponent.nativeElement.style.height = this.windowInnerHeight + 'px';
  }

  sidebarToggleHandler() {
    this.sidebarIsOpen = !this.sidebarIsOpen;
    const windowResizeTrigger = setInterval(() => window.dispatchEvent(new Event('resize')), 10);
    setTimeout(() => clearInterval(windowResizeTrigger), 600);
  }
}
