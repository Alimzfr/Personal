import {Component, HostListener, OnInit, ViewChild} from '@angular/core';
import {EducationModel, CollegeEducationModel, ChartOptions} from './education.model/education.model';
import {EducationService} from './education.services/education.service';
import {ChartComponent} from 'ng-apexcharts';
import {toArray} from 'rxjs/operators';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss']
})
export class EducationComponent implements OnInit {
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: ChartOptions;
  educations: EducationModel[];
  collegeEducations: CollegeEducationModel[];
  loading: boolean;

  constructor(private service: EducationService) {
  }

  ngOnInit(): void {
    this.loading = true;
    this.getEducations();
    this.getCollegeEducations();
  }

  getEducations() {
    this.service.getEducations().subscribe(value => {
      this.educations = value;
      this.fillCartEducations(value);
    });
  }

  getCollegeEducations() {
    this.service.getCollegeEducations().subscribe(value => {
      this.collegeEducations = value;
    });
  }

  fillCartEducations(educations: EducationModel[]) {
    this.chartOptions = {
      series: [
        {
          name: 'Duration',
          data: educations.map(value => {
            return value.duration;
          })
        }
      ],
      chart: {
        type: 'bar',
        height: 200
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '50%',
          endingShape: 'rounded'
        }
      },
      dataLabels: {
        enabled: false
      },
      stroke: {
        show: true,
        width: 2,
        colors: ['transparent']
      },
      xaxis: {
        title: {
          text: '(Courses)'
        },
        categories: educations.map(value => {
          return value.englishCourseName;
        }),
        labels: {
          show: false
        }
      },
      yaxis: {
        title: {
          text: '(hours)'
        }
      },
      fill: {
        opacity: 1
      },
      tooltip: {
        y: {
          formatter: (val) => {
            return val + ' hours';
          }
        }
      }
    };
    this.loading = false;
  }

}
