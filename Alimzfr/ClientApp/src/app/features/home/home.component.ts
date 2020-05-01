import {AfterViewInit, Component, HostListener, OnDestroy, OnInit} from '@angular/core';
import {Observable} from 'rxjs';

declare var Particles: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, AfterViewInit, OnDestroy {
  particles: any;

  constructor() {
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    this.initParticles();
    if (window.innerWidth < 768) {
      window.dispatchEvent(new Event('resize'));
    }
  }

  ngOnDestroy(): void {
    this.destroyParticles();
  }

  initParticles() {
    this.particles = Particles.init({
      selector: '.Particles-background',
      maxParticles: 50,
      color: '#6c757d',
      speed: 0.3,
      connectParticles: true,
    });
  }

  destroyParticles() {
    this.particles.destroy();
  }
}
