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
  {component: HomeComponent, path: ''},
  {component: HomeComponent, path: 'Home'},
  {component: AboutComponent, path: 'About'},
  {component: BlogComponent, path: 'Blog'},
  {component: ContactComponent, path: 'Contact'},
  {component: EducationComponent, path: 'Education'},
  {component: ExperienceComponent, path: 'Experience'},
  {component: SkillsComponent, path: 'Skills'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
