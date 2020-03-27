import {Component, OnInit, ViewChild} from '@angular/core';
import {SkillsService} from './skills.services/skills.service';
import {ChartOptions, SkillModel} from './skills.models/skills.model';
import {ChartComponent} from 'ng-apexcharts';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.scss']
})
export class SkillsComponent implements OnInit {
  skills: SkillModel[];
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;


  constructor(private service: SkillsService) {
  }

  ngOnInit(): void {
    this.getSkills();
    this.chartOptions = {
      series: [70],
      chart: {
        height: 350,
        type: 'radialBar'
      },
      plotOptions: {
        radialBar: {
          hollow: {
            size: '70%'
          }
        }
      },
      labels: ['Cricket']
    };
  }

  private getSkills() {
    this.service.getSkills().subscribe(value => {
      this.skills = value;
    });
  }

}
