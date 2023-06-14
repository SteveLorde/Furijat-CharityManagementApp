import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { map, Observable} from 'rxjs';
import { environment } from 'src/environments/environment';
import { ContactMessage } from '../../Models/ContactMessage';

@Injectable({
  providedIn: 'root'
})
export class MailServiceBackendService {

  mailsubmiturl = environment.baseUrl + "api/email/Send"

  responseStatus: number


  constructor(private http: HttpClient) { }

  postmessage(mail: ContactMessage): Observable<any> {
    return this.http.post<any>(this.mailsubmiturl, mail, { observe: 'response' })
      .pipe(map(data => {
        return data.status
      }))
  }

}
