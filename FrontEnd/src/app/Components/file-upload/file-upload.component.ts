import { Component, OnInit } from '@angular/core';
import { FileUploadService } from 'src/app/Services/file-upload/file-upload.service';
import { BackendCommunicationService } from 'src/app/Services/BackendCommunication/backend-communication.service';


@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {

  constructor(private http: BackendCommunicationService) { }

  ngOnInit(): void {
  }

  fileName = '';

  onFileSelected(event) {
    const file: File = event.target.files[0];

    if (file) {
      this.fileName = file.name;

      const formData = new FormData();

      formData.append("thumbnail", file);

      const upload$ = this.http.post("/api/upload", formData);

      upload$.subscribe();
    }
  }







}
