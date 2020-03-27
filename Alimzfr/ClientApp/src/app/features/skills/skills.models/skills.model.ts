import {
  ApexNonAxisChartSeries,
  ApexPlotOptions,
  ApexChart
} from 'ng-apexcharts';

export interface SkillModel {
  id: number;
  creatDate: string;
  modifyDate: string;
  persianSkillName: string;
  englishSkillName: string;
  persianDescription: string;
  englishDescription: string;
  level: number;
}

export interface ChartOptions {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  labels: string[];
  plotOptions: ApexPlotOptions;
}
