import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BackendCommunicationService {

  constructor(private http: HttpClient) { }

  serverurl = environment.baseUrl;

  GetDebtListTest(): Observable<any[]> {
    return this.http.get<any[]>(this.serverurl + );
  }
}
