import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';

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
