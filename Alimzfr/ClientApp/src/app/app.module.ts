import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NgxMaskModule, IConfig} from 'ngx-mask';
import {ReactiveFormsModule} from '@angular/forms';


import {HttpClientModule} from '@angular/common/http';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {TemplateComponent} from './shareComponents/template/template.component';
import {SidebarComponent} from './shareComponents/template/template.components/sidebar/sidebar.component';
import {MainComponent} from './shareComponents/template/template.components/main/main.component';
import {SkillsComponent} from './features/skills/skills.component';
import {HomeComponent} from './features/home/home.component';
import {AboutComponent} from './features/about/about.component';
import {EducationComponent} from './features/education/education.component';
import {ExperienceComponent} from './features/experience/experience.component';
import {BlogComponent} from './features/blog/blog.component';
import {ContactComponent} from './features/contact/contact.component';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';
import {HeaderComponent} from './shareComponents/template/template.components/main/main.components/header/header.component';
import {PictureComponent} from './shareComponents/template/template.components/sidebar/sidebar.components/picture/picture.component';
import {MenuComponent} from './shareComponents/template/template.components/sidebar/sidebar.components/menu/menu.component';
import {FooterComponent} from './shareComponents/template/template.components/sidebar/sidebar.components/footer/footer.component';
import {MatMenuModule} from '@angular/material/menu';
import {ContentComponent} from './shareComponents/template/template.components/main/main.components/content/content.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {NgApexchartsModule} from 'ng-apexcharts';
import {LoadingComponent} from './shareComponents/loading/loading.component';
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import {MatStepperModule} from '@angular/material/stepper';
import {DialogComponent} from './shareComponents/dialog/dialog.component';
import {MatInputModule} from '@angular/material/input';
import {MatTooltipModule} from '@angular/material/tooltip';

export let options: Partial<IConfig> | (() => Partial<IConfig>);

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
    ContentComponent,
    LoadingComponent,
    DialogComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    NgApexchartsModule,
    MatButtonModule,
    MatIconModule,
    FontAwesomeModule,
    MatMenuModule,
    MatProgressBarModule,
    MatCardModule,
    MatDividerModule,
    MatStepperModule,
    MatTooltipModule,
    MatInputModule,
    NgxMaskModule.forRoot(options)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
