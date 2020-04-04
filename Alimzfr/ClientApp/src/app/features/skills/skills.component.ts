import {Component, OnInit, ViewChild} from '@angular/core';
import {SkillsService} from './skills.services/skills.service';
import {ChartOptions, SkillModel} from './skills.models/skills.model';
import {ChartComponent} from 'ng-apexcharts';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.scss']
})
export class SkillsComponent implements OnInit {
  @ViewChild('chart') chart: ChartComponent;
  skills: SkillModel[];
  chartSkills: ChartOptions[];
  loading: boolean;

  constructor(private service: SkillsService) {
  }

  ngOnInit(): void {
    this.loading = true;
    this.getSkills();
  }

  getSkills() {
    this.service.getSkills().subscribe(value => {
      this.skills = value;
      this.fillChartSkills(value).subscribe(res => {
        this.chartSkills = res;
        this.loading = false;
      });
    }, error => {
      console.log(error);
      this.loading = false;
    });
  }

  fillChartSkills(skills: SkillModel[]): Observable<ChartOptions[]> {
    return new Observable<ChartOptions[]>(subscriber => {
      const tempChartSkills: ChartOptions[] = [];
      skills.map((item) => {
        tempChartSkills.push({
          series: [item.level],
          chart: {
            height: 140,
            type: 'radialBar',
            offsetY: -10
          },
          plotOptions: {
            radialBar: {
              startAngle: -125,
              endAngle: 125,
              dataLabels: {
                name: {
                  fontSize: '13px',
                  color: item.categoryColor,
                  offsetY: 45
                },
                value: {
                  offsetY: 10,
                  fontSize: '15px',
                  color: item.categoryColor,
                  formatter: () => {
                    return item.level + '%';
                  }
                }
              }
            }
          },
          subtitle: {
            text: item.englishCategoryName,
            align: 'center',
            offsetY: 130,
            style: {
              color: '#cccccc',
              fontSize: '10px'
            }
          },
          fill: {
            colors: [item.categoryColor],
            gradient: {
              shade: 'dark',
              shadeIntensity: 0.15,
              inverseColors: false,
              opacityFrom: 1,
              opacityTo: 1,
              stops: [0, 50, 65, 91]
            }
          },
          stroke: {
            width: -10
          },
          labels: [item.englishSkillName]
        });
      });
      return subscriber.next(tempChartSkills);
    });
  }

}
