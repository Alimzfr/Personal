import {Component, OnInit, ViewChild} from '@angular/core';
import {TrainingCourseModel, CollegeEducationModel, ChartOptions} from './education.model/education.model';
import {EducationService} from './education.services/education.service';
import {ChartComponent} from 'ng-apexcharts';
import {MatSnackBar} from '@angular/material/snack-bar';
import {AuthService} from '../../authentication/auth.service';

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

  constructor(private service: EducationService) {
  }

  ngOnInit(): void {
    this.loading = true;
    this.getTrainingCourses();
    this.getCollegeEducations();
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
        categories: trainingCourses.map(value => {
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

  getCollegeEducations() {
    this.service.getCollegeEducations().subscribe(value => {
      this.collegeEducations = value;
    }, error => {
      console.log(error);
    });
  }

}
