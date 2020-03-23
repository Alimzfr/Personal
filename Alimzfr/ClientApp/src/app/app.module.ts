import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TemplateComponent } from './shareComponents/template/template.component';
import { SidebarComponent } from './shareComponents/template/sidebar/sidebar.component';
import { ContentComponent } from './shareComponents/template/content/content.component';
import { SkillsComponent } from './features/skills/skills.component';
import { HomeComponent } from './features/home/home.component';
import { AboutComponent } from './features/about/about.component';
import { EducationComponent } from './features/education/education.component';
import { ExperienceComponent } from './features/experience/experience.component';
import { BlogComponent } from './features/blog/blog.component';
import { ContactComponent } from './features/contact/contact.component';

@NgModule({
  declarations: [
    AppComponent,
    TemplateComponent,
    SidebarComponent,
    ContentComponent,
    SkillsComponent,
    HomeComponent,
    AboutComponent,
    EducationComponent,
    ExperienceComponent,
    BlogComponent,
    ContactComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
