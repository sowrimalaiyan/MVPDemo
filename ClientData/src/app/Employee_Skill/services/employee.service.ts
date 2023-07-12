import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private commonUrl: string = environment.mainAPI.apiURL;
  private APIs = environment.employeeURL;

  constructor(private http: HttpClient) { }
  add(params: any) {
    return this.http.post<any>(
      this.commonUrl + this.APIs.create,
      params
    );
  }

  edit(params: any) {
    return this.http.post<any>(
      this.commonUrl + this.APIs.update,
      params
    );
  }

  delete(params: any) {
    return this.http.post<any>(
      this.commonUrl + this.APIs.delete,
      params
    );
  }


  get(id: string) {
    return this.http.get<any>(this.commonUrl + this.APIs.get + '?id='+id);
  }
  
  getAllEmployee(params:any) {
    return this.http.post<any>(
      this.commonUrl + this.APIs.getAllEmployee,
      params
    );    
  }


}
