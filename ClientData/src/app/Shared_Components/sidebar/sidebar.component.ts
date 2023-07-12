import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
// import mock from './mock.json';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit{

  menus: any = [];
  currentPath:any;
  subNode:any;
  subSubNode:any;
  constructor(private router: Router) { }

  ngOnInit(): void {
    // const myArray = this.router.url.split("/");
    // if(myArray[1]=='custom'){
    //   this.currentPath = myArray[1]+"/"+myArray[2];
    //   this.subNode = myArray[3];
    // }else{
    //   this.currentPath = myArray[1];
    //   this.subNode = myArray[2];
    //   this.subSubNode = myArray[3];
    // }
    
    // let user:any = localStorage.getItem('user_details');

    // let roleId = JSON.parse(user).roleId;

    // this.menus = mock;
    // this.setSideBar();

  }
  // getSideMenu(roleId:any) {
  //   this.commonService.getMenuList(roleId).subscribe({
  //     next: (response) => {
  //       if (response.data) {
  //         this.menus = response.data;
  //         this.setSideBar();
  //       }
  //     },
  //     error: (response) =>{
  //       // alert(response.error.message);
  //     }
  //   })
  // }

  // setSideBar(){
  //   this.menus.forEach( (value:any) => {
  //     value['menu_isCollapsed'] = true;
  //     if(value.URL == this.currentPath){
  //       value['menu_isCollapsed'] = false;
  //       value.subMenu.forEach( (sub:any) => {
  //         sub['sub_menu_isCollapsed'] = true;
  //         if(sub.SubURL == this.subNode){
  //           sub['sub_menu_isCollapsed'] = false;
  //         }
  //       }); 
  //     }
  //   }); 
  // }
}
