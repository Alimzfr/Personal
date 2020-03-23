import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {HomeComponent} from './features/home/home.component';
import {AboutComponent} from './features/about/about.component';
import {BlogComponent} from './features/blog/blog.component';
import {ContactComponent} from './features/contact/contact.component';
import {EducationComponent} from './features/education/education.component';
import {ExperienceComponent} from './features/experience/experience.component';
import {SkillsComponent} from './features/skills/skills.component';


const routes: Routes = [
  {component: HomeComponent, path: ':lang?'},
  {component: AboutComponent, path: ':lang?/About'},
  {component: BlogComponent, path: ':lang?/Blog'},
  {component: ContactComponent, path: ':lang?/Contact'},
  {component: EducationComponent, path: ':lang?/Education'},
  {component: ExperienceComponent, path: ':lang?/Experience'},
  {component: SkillsComponent, path: ':lang?/Skills'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
