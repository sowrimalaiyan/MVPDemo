import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SkillService {

  private commonUrl: string = environment.mainAPI.apiURL;
  private APIs = environment.skillURL;

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
  get() {
    return this.http.post<any>(this.commonUrl + this.APIs.get,{});
  }

}
