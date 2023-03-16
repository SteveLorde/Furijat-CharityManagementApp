import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.getprofilepic();
  }

  imgsrc = environment.baseUrl + 'api/GetFile?filename=kfc.jpg'

  getprofilepic() {
    this.imgsrc
  }

  login = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    phone: new FormControl('', Validators.required),
    Fax: new FormControl('', Validators.required),
    Website: new FormControl('', Validators.required),
    CharityName: new FormControl('', Validators.required),
  });

}
