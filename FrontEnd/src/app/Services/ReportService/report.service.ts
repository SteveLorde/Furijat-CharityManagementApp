import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { environment } from 'src/environments/environment'



@Injectable({
  providedIn: 'root'
})
export class ReportService {

  reportapi = environment.baseUrl

  constructor(private http: HttpClient) { }

  //Donator Reports

  //Charity Reports
  GetCharityCases() { }

  //Debtor Reports

  //Creditor Reports

}
