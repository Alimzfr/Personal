export interface EducationModel {
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
  id: number;
  creatDate: string;
  modifyDate: string;
  persianDegreeLevel: string;
  englishDegreeLevel: string;
  persianAcademicField: string;
  englishAcademicField: string;
  persianUniversity: string;
  englishUniversity: string;
  persianDescription: string;
  englishDescription: string;
  gregorianGraduationDate: string;
  persianGraduationDate: string;
}
