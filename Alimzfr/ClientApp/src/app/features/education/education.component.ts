import {Component, OnInit, ViewChild} from '@angular/core';
import {TrainingCourseModel, CollegeEducationModel, ChartOptions} from './education.model/education.model';
import {EducationService} from './education.services/education.service';
import {ChartComponent} from 'ng-apexcharts';
import {MatSnackBar} from '@angular/material/snack-bar';
import {AuthService} from '../../authentication/auth.service';
import {ConnectionService} from '../../shareServices/connection.service';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss']
})
export class EducationComponent implements OnInit {
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: ChartOptions;
  educations: TrainingCourseModel[];
  collegeEducations: CollegeEducationModel[];
  loading: boolean;
  isOnline: boolean;

  constructor(private service: EducationService,
              private connection: ConnectionService) {
    this.isOnline = true;
  }

  ngOnInit(): void {
    this.loading = true;
    this.getTrainingCourses();
    this.getCollegeEducations();
    this.connection.isOnline().subscribe(() => {
      this.isOnline = true;
    }, error => {
      this.isOnline = false;
    });
  }

  getTrainingCourses() {
    this.service.getTrainingCourses().subscribe(value => {
      this.educations = value;
      this.fillCartTrainingCourses(value);
    }, error => {
      console.log(error);
    });
  }

  fillCartTrainingCourses(trainingCourses: TrainingCourseModel[]) {
    this.chartOptions = {
      series: [
        {
          name: 'Duration',
          data: trainingCourses.map(value => {
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
          endingShape: 'rounded',
          colors: {
            ranges: [{from: 0, to: 1000, color: '#ffcc33'}]
          }
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
          text: '(Courses)',
          style: {
            color: '#6c757d'
          }
        },
        categories: trainingCourses.map(value => {
          return value.englishCourseName;
        }),
        labels: {
          show: false
        }
      },
      yaxis: {
        title: {
          text: '(Hours)',
          style: {
            color: '#6c757d'
          }
        }
      },
      fill: {
        opacity: 1
      },
      tooltip: {
        marker: {
          fillColors: ['#ffcc33']
        },
        y: {
          formatter: (val) => {
            return val + ' hours';
          }
        }
      }
    };
    this.loading = false;
  }

  getCollegeEducations() {
    this.service.getCollegeEducations().subscribe(value => {
      this.collegeEducations = value;
    }, error => {
      console.log(error);
    });
  }

}
