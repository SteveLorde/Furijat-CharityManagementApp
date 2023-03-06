import { Component, OnInit } from '@angular/core';
import { FileUploadService } from 'src/app/Services/file-upload/file-upload.service';


@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {

  constructor(private fileUploadService: FileUploadService) { }

  ngOnInit(): void {
  }

  // Variable to store shortLink from api response

  loading: boolean = false; // Flag variable
  file: File | null = null; // Variable to store file
 // Variable to store file

  //on file selection
  onChange(files: FileList) {
    this.file = files.item(0);
  }

  uploadFileToActivity() {
    this.fileUploadService.upload(this.file).subscribe(data => {
      // do something, if upload success
    }, error => {
      console.log(error);
    });
  }

}

/*
// OnClick of button Upload
onUpload() {
  this.loading = !this.loading;
  console.log(this.file);
  this.fileUploadService.upload(this.file).subscribe(
    (event: any) => {
      if (typeof (event) === 'object') {

        this.loading = false; // Flag variable 
      }
    }
  );
}
*/

          // Short link via api response
          //this.shortLink = event.link;
  //shortLink: string = "";
