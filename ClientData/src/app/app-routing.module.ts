import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SkillComponent } from './Skill/component/skill/skill.component';
import { EmployeeSkillComponent } from './Employee_Skill/component/employee-skill/employee-skill.component';
import { JobSkillComponent } from './Job_Skill/component/job-skill/job-skill.component';

const routes: Routes = [
  { path: 'skill', component: SkillComponent },
  { path: 'employee', component: EmployeeSkillComponent },
  { path: 'job', component: JobSkillComponent },
  { path: '',   redirectTo: '/skill', pathMatch: 'full' }, // redirect to `first-component`
];

@NgModule({
  imports: [CommonModule,RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
