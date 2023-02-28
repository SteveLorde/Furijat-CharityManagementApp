import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpInterceptor } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Case } from 'src/app/Models/Cases'
import { Charity } from 'src/app/Models/Charity'

@Injectable({
  providedIn: 'root'
})
export class BackendCommunicationService {

  constructor(private http: HttpClient) { }

  //general url link
  serverurl = environment.baseUrl;

  //Defined Cases and Charities List Array
  public CaseList: Case[] = [];
  public CharityList: Charity[] = [];

  public get(url: string, options?: any) {
    return this.http.get(url, options);
  }
  public post(url: string, data: any, options?: any) {
    return this.http.post(url, data, options);
  }
  public put(url: string, data: any, options?: any) {
    return this.http.put(url, data, options);
  }
  public delete(url: string, options?: any) {
    return this.http.delete(url, options);
  }
}
