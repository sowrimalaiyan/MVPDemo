import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SkillComponent } from './Skill/component/skill/skill.component';
import { JobSkillComponent } from './Job_Skill/component/job-skill/job-skill.component';
import { EmployeeSkillComponent } from './Employee_Skill/component/employee-skill/employee-skill.component';
import { SkillService } from './Skill/services/skill.service';
import { JobService } from './Job_Skill/services/job.service';
import { EmployeeService } from './Employee_Skill/services/employee.service';
import { HeaderComponent } from './Shared_Components/header/header.component';
import { SidebarComponent } from './Shared_Components/sidebar/sidebar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { HttpClientModule } from '@angular/common/http';
import { TableModule } from 'primeng/table';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {MultiSelectModule} from 'primeng/multiselect';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    SkillComponent,
    JobSkillComponent,
    EmployeeSkillComponent,
    HeaderComponent,
    SidebarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    MultiSelectModule,
    HttpClientModule,
    TableModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  providers: [SkillService, JobService, EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
