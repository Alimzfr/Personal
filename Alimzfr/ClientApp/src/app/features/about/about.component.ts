import {Component, OnInit} from '@angular/core';
import {AboutService} from './about.services/about.service';
import {AboutModel} from './about.models/about.model';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  abouts: AboutModel[];

  constructor(private service: AboutService) {
  }

  ngOnInit(): void {
    this.getAbouts();
  }

  getAbouts() {
    this.service.getAbouts().subscribe(value => {
      this.abouts = value;
    });
  }

}
