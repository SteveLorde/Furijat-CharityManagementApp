import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class FileUploadService {

  // API url
  baseApiUrl = "/" + "/api/fileupload"

  constructor(private http: HttpClient) { }

  // Returns an observable
  upload(file): Observable<any> {

    // Create form data
    const formData = new FormData();

    // Store form name as "file" with file data
    formData.append("file", file, file.name);

    // Make http post request over api with formData as request containing file
    return this.http.post(this.baseApiUrl, formData)
  }
}
