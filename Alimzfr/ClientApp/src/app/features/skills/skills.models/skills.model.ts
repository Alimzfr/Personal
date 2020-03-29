import {
  ApexNonAxisChartSeries,
  ApexPlotOptions,
  ApexChart,
  ApexTitleSubtitle,
  ApexFill,
  ApexStroke
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
  skillCategoryId: number;
  persianCategoryName: string;
  englishCategoryName: string;
  categoryColor: string;
}

export interface ChartOptions {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  labels: string[];
  plotOptions: ApexPlotOptions;
  fill?: ApexFill;
  stroke?: ApexStroke;
  colors?: string[];
  subtitle?: ApexTitleSubtitle;
}
