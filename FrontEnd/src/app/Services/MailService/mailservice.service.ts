import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ContactMessage } from '../../Models/ContactMessage';

@Injectable({
  providedIn: 'root'
})
export class MailserviceService {

  contactmessage: ContactMessage

  contactUrl = 'https://formspree.io/f/xeqwpdlk';

  constructor(private http: HttpClient) { }


  postmessage(contactmessage: ContactMessage): Observable<any> {
    return this.http.post<any>(this.contactUrl, contactmessage);
  }


}
