import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';


import skillData from './mock.json';
import { SkillService } from '../../services/skill.service';

@Component({
  selector: 'app-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.css']
})
export class SkillComponent implements OnInit {
  cols: any[] = [];
  form!: FormGroup;
  editForm!: FormGroup;
  loading = false;
  submitted = false;
  actionColumn:any;
  dataShow: any = {
    id: "",
    name:"",
    description:''
  };
  tableData: any = [];

  isPageAlert:boolean = false;
  alertPageTxt: String = '';
  isPageSuccess:boolean = true;
  paginator:boolean = false;

  isAlert: boolean = false;
  alertTxt: String = ''; 
  @ViewChild('closeAddPop', { static: false }) closeAddPop: ElementRef<HTMLInputElement> = {} as ElementRef;
  @ViewChild('closeEditPop', { static: false }) closeEditPop: ElementRef<HTMLInputElement> = {} as ElementRef;

  constructor(private skillService: SkillService){}
  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required)
    });

    this.editForm = new FormGroup({
      id: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required)
    });

   // this.tableData = skillData;
    this.getList();

  }

  get f() { return this.form.controls; }

  getList() {
    this.loading = true;
    this.skillService.get().subscribe({
      next: (response) => {
        this.loading = false;
        if (response) {
          this.tableData = response;
          console.log("test",this.tableData);
          if(Object.keys(this.tableData).length>10){
            this.paginator = true;
          } else{
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

  onAddClick(){
    this.submitted = false;
    this.form.reset();
  }

  onEdit(data:any){
    this.submitted = false;
    this.dataShow = JSON.parse(JSON.stringify(data));
  }

  onView(data:any){
    this.dataShow = JSON.parse(JSON.stringify(data));
  }

  onDelete(data:any){
    this.actionColumn = data;
  }

  onAddSubmit(){
    this.submitted = true;

    if (this.form.invalid) {
      this.alertShow("Invalid");
      return;
    }

    let params = {
      "name": this.form.controls['name'].value,
      "description": this.form.controls['description'].value
    };

    this.loading = true;

    // console.log("Add Skill:-----------  ", params);

    // this.loading = false;
    // this.closeAddPop.nativeElement.click();


    this.skillService.add(params).subscribe({
      next: (response) => {

        if (response) {
          this.loading = false;
          this.getList();
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

  onEditSubmit(){
    this.submitted = true;

    // reset alerts on submit
    // this.alertService.clear();

    // stop here if form is invalid
    if (this.editForm.invalid) {
      this.alertShow("Invalid");
      return;
    }

    let params = {
      //"id": Number(this.editForm.controls['id'].value),
      "id": this.editForm.controls['id'].value,
      "name": this.editForm.controls['name'].value,
      "description": this.editForm.controls['description'].value
    };

    // console.log("Update Skill:----   ",params);

    this.loading = true;
    // this.closeEditPop.nativeElement.click();

    this.skillService.edit(params).subscribe({
      next: (response) => {

        if (response) {
          this.loading = false;
          this.getList();
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

  delete(data:any){
    let params = {
      "Id": data.id
    };
    this.loading = true;
    console.log("Delete Skill:----   ",params);
    this.skillService.delete(params).subscribe({
      next: (response) => {
        if (response) {
          this.loading = false;
          this.pageAlertShow(data.name+" deleted Successfully", true);

          this.getList();
          // ($('#add') as any).modal('hide');
        }else{
          this.loading = false;
          
          this.pageAlertShow(response.message, false);
        }
      },
      error: (response) => {
        this.loading = false;
        this.pageAlertShow(response.error.message,false);
      },
    });
  }

  alertShow(txt:String){
    this.isAlert = true;
    this.alertTxt= txt;

    setTimeout(() =>{
      this.isAlert = false;
    },5000);
  }

  pageAlertShow(txt:String,isSuccess:boolean){
    this.isPageAlert = true;
    this.alertPageTxt= txt;
    this.isPageSuccess = isSuccess;
    setTimeout(() =>{
      this.isPageAlert = false;
    },5000);
  }
}
