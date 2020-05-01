import {
  ApexAxisChartSeries,
  ApexChart,
  ApexDataLabels,
  ApexPlotOptions,
  ApexYAxis,
  ApexStroke,
  ApexXAxis,
  ApexFill,
  ApexTooltip
} from 'ng-apexcharts';

export interface TrainingCourseModel {
  id: number;
  creatDate: string;
  modifyDate: string;
  persianCourseName: string;
  englishCourseName: string;
  persianDescription: string;
  englishDescription: string;
  gregorianFromDate: string;
  persianFromDate: string;
  gregorianToDate: string;
  persianToDate: string;
  persianEducationalInstitute: string;
  englishEducationalInstitute: string;
  duration: number;
}

export interface CollegeEducationModel {
  id?: number;
  createDate?: string;
  ModifyDate?: string;
  persianDegreeLevel?: string;
  englishDegreeLevel?: string;
  persianAcademicField?: string;
  englishAcademicField?: string;
  persianUniversity?: string;
  englishUniversity?: string;
  persianDescription?: string;
  englishDescription?: string;
  gregorianGraduationDate?: string;
  persianGraduationDate?: string;
}

export interface ChartOptions {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
  fill: ApexFill;
  tooltip: ApexTooltip;
  stroke: ApexStroke;
}
