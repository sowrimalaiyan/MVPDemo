import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import employeeData from './mock.json';
import skillData from '../../../Skill/component/skill/mock.json';
import { EmployeeService } from '../../services/employee.service';
import { SkillService } from 'src/app/Skill/services/skill.service';

@Component({
  selector: 'app-employee-skill',
  templateUrl: './employee-skill.component.html',
  styleUrls: ['./employee-skill.component.css']
})
export class EmployeeSkillComponent implements OnInit {
  cols: any[] = [];
  form!: FormGroup;
  editForm!: FormGroup;
  loading = false;
  submitted = false;
  actionColumn: any;  
  dataShow: any = {
    id: "",
    name:"",
    phoneNo:0
  };
  tableData: any = [];
  dropdownData: any;
  params: any = {
    id: null,
    name: null
  }

  isPageAlert: boolean = false;
  alertPageTxt: String = '';
  isPageSuccess: boolean = true;
  paginator: boolean = false;

  isAlert: boolean = false;
  alertTxt: String = '';
  @ViewChild('closeAddPop', { static: false }) closeAddPop: ElementRef<HTMLInputElement> = {} as ElementRef;
  @ViewChild('closeEditPop', { static: false }) closeEditPop: ElementRef<HTMLInputElement> = {} as ElementRef;

  constructor(private employeeService: EmployeeService, private skillService: SkillService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      phoneNo: new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      skills: new FormControl([], [Validators.required, Validators.minLength(1)])

    });

    this.editForm = new FormGroup({
      id: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      phoneNo: new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      skills: new FormControl([], [Validators.required, Validators.minLength(1)])
    });

    // this.tableData = employeeData;
    // this.dropdownData = skillData;


    this.getAllEmployeeList(this.params);
    this.getSkill();

  }

  get f() { return this.form.controls; }

  getAllEmployeeList(params: any) {
    this.loading = true;
    this.employeeService.getAllEmployee(params).subscribe({
      next: (response) => {
        this.loading = false;
        if (response) {
          this.tableData = response;
          if (Object.keys(this.tableData).length > 10) {
            this.paginator = true;
          } else {
            this.paginator = false;
          }
          // ($('#add') as any).modal('hide');
        }
      },
      error: (response) => {
        this.loading = false;
        // alert(response.error.message);
      },
    });
  }
  getEmployeeSkill(id: string) {
    this.loading = true;

    this.employeeService.get(id).subscribe({
      next: (response) => {
        this.loading = false;
        if (response) {
          let selectedSkills = [];
          for (let i = 0; i < response.length; i++) {
            delete response[i].employeeSkillId;
            selectedSkills.push(this.dropdownData.find((item:any) => item.id === response[i].id));
          }
          this.editForm.controls['skills'].setValue(selectedSkills);
          // ($('#add') as any).modal('hide');
        }
      },
      error: (response) => {
        this.loading = false;
        // alert(response.error.message);
      },
    });
  }

  getSkill() {
    this.loading = true;
    this.skillService.get().subscribe({
      next: (response) => {
        this.loading = false;
        if (response) {
          this.dropdownData = response;
        }
      },
      error: (response) => {
        this.loading = false;
      },
    });
  }
  onAddClick() {
    this.submitted = false;
    this.form.reset();
    this.form.controls['skills'].setValue([]);
  }

  onEdit(data: any) {
    this.submitted = false;
    this.dataShow = JSON.parse(JSON.stringify(data));
    this.getEmployeeSkill(data.id);
  }

  onView(data: any) {
    this.dataShow = JSON.parse(JSON.stringify(data));
    this.getEmployeeSkill(data.id);
  }

  onDelete(data: any) {
    this.actionColumn = data;
  }

  onAddSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      this.alertShow("Invalid");
      return;
    }
    let skillIds = [];
    for (let i = 0; i < this.form.controls['skills'].value.length; i++) {
      skillIds.push({
        "id": this.form.controls['skills'].value[i].id
      });
    }
    let params = {
      "name": this.form.controls['name'].value,
      "phoneNo": this.form.controls['phoneNo'].value,
      "skills": skillIds
    };

    this.loading = true;

    // console.log("Add Skill:-----------  ", params);

    // this.loading = false;
    // this.closeAddPop.nativeElement.click();


    this.employeeService.add(params).subscribe({
      next: (response) => {

        if (response) {
          this.loading = false;
          this.getAllEmployeeList(this.params);
          this.closeAddPop.nativeElement.click();
          // ($('#add') as any).modal('hide');
        }
      },
      error: (response) => {
        this.loading = false;
        this.alertShow(response.error.message);
      },
    });
  }

  onEditSubmit() {
    this.submitted = true;

    // reset alerts on submit
    // this.alertService.clear();

    // stop here if form is invalid
    if (this.editForm.invalid) {
      this.alertShow("Invalid");
      return;
    }

    let skillIds = [];
    for (let i = 0; i < this.editForm.controls['skills'].value.length; i++) {
      skillIds.push({
        "id": this.editForm.controls['skills'].value[i].id
      });
    }
    let params = {
      "id": this.editForm.controls['id'].value,
      "name": this.editForm.controls['name'].value,
      "phoneNo": this.editForm.controls['phoneNo'].value,
      "skills": skillIds
    };

    // console.log("Update Skill:----   ",params);

    this.loading = true;
    // this.closeEditPop.nativeElement.click();

    this.employeeService.edit(params).subscribe({
      next: (response) => {

        if (response) {
          this.loading = false;
          this.getAllEmployeeList(this.params);
          this.closeEditPop.nativeElement.click();
          // ($('#add') as any).modal('hide');
        }
      },
      error: (response) => {
        this.loading = false;
        this.alertShow(response.error.message);
      },
    });
  }

  delete(data: any) {
    let params = {
      "id": data.id
    };
    this.loading = true;
    // console.log("Delete Skill:----   ",params);
    this.employeeService.delete(params).subscribe({
      next: (response) => {

        if (response) {
          this.loading = false;
          this.pageAlertShow(data.name + " deleted Successfully", true);
          this.getAllEmployeeList(this.params);
          // ($('#add') as any).modal('hide');
        } else {
          this.loading = false;

          this.pageAlertShow(response.message, false);
        }
      },
      error: (response) => {
        this.loading = false;
        this.pageAlertShow(response.error.message, false);
      },
    });
  }

  alertShow(txt: String) {
    this.isAlert = true;
    this.alertTxt = txt;

    setTimeout(() => {
      this.isAlert = false;
    }, 5000);
  }

  pageAlertShow(txt: String, isSuccess: boolean) {
    this.isPageAlert = true;
    this.alertPageTxt = txt;
    this.isPageSuccess = isSuccess;
    setTimeout(() => {
      this.isPageAlert = false;
    }, 5000);
  }

  getColumnContent(col: any) {
    let selectedSkills = '';
    for (let i = 0; i < col.length; i++) {
      let skillName = skillData.find(item => item.id === col[i].id)?.name;
      if (skillName) {
        if (selectedSkills.length == 0) {
          selectedSkills = selectedSkills.concat(skillName.toString());
        } else {
          selectedSkills = selectedSkills.concat(', ' + skillName.toString());
        }
      }
    }
    return selectedSkills; // always [0] as it contains a single element
  }

}
