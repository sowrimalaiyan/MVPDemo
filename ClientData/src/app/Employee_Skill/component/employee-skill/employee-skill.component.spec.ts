import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeSkillComponent } from './employee-skill.component';

describe('EmployeeSkillComponent', () => {
  let component: EmployeeSkillComponent;
  let fixture: ComponentFixture<EmployeeSkillComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeSkillComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeSkillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
