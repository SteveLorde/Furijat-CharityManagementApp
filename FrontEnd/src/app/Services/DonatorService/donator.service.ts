import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Donation } from '../../Models/Donation';

@Injectable({
  providedIn: 'root'
})
export class DonatorService {

  serverUrl = environment.baseUrl

  constructor(private http: HttpClient) { }

//GET Donations
  getDonations(): Observable<Donation> {
    return this.http.get<Donation>(this.serverUrl + 'api/Donation');
  }
  //GET Donations By ID
  getDonationsofDonatorID(id: any): Observable<Donation> {
    return this.http.get<Donation>(this.serverUrl + `api/getdonationfordonator/${id}`);
  }

  getDonationsofCharityID(id: any): Observable<Donation> {
    return this.http.get<Donation>(this.serverUrl + `api/getdonationforcharity/${id}`);
  }

  //Create Donation Recipit
  createDonation(donation: Donation): Observable<Donation> {
    return this.http.post<Donation>(this.serverUrl + 'api/Donation/AddDonation', donation);
  }

}
