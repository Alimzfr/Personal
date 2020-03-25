import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TemplateComponent } from './shareComponents/template/template.component';
import { SidebarComponent } from './shareComponents/template/sidebar/sidebar.component';
import { MainComponent } from './shareComponents/template/main/main.component';
import { SkillsComponent } from './features/skills/skills.component';
import { HomeComponent } from './features/home/home.component';
import { AboutComponent } from './features/about/about.component';
import { EducationComponent } from './features/education/education.component';
import { ExperienceComponent } from './features/experience/experience.component';
import { BlogComponent } from './features/blog/blog.component';
import { ContactComponent } from './features/contact/contact.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HeaderComponent } from './shareComponents/template/main/main.components/header/header.component';
import { PictureComponent } from './shareComponents/template/sidebar/sidebar.components/picture/picture.component';
import { MenuComponent } from './shareComponents/template/sidebar/sidebar.components/menu/menu.component';
import { FooterComponent } from './shareComponents/template/sidebar/sidebar.components/footer/footer.component';
import {MatMenuModule} from '@angular/material/menu';


@NgModule({
  declarations: [
    AppComponent,
    TemplateComponent,
    SidebarComponent,
    MainComponent,
    SkillsComponent,
    HomeComponent,
    AboutComponent,
    EducationComponent,
    ExperienceComponent,
    BlogComponent,
    ContactComponent,
    HeaderComponent,
    PictureComponent,
    MenuComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatIconModule,
    FontAwesomeModule,
    MatMenuModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
