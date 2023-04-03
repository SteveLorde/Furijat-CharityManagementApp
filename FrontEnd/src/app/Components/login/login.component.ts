import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup,Validators} from '@angular/forms';
import { AuthService } from 'src/app/Services/Authorization/auth.service'
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { User } from '../../Models/User';
import { Login } from '../../Models/Login';
import { Student } from '../../Models/classtest';





@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  signinForm: FormGroup;



  constructor(private router: Router, private authService: AuthService, private http: HttpClient, public fb: FormBuilder) {
    this.signinForm = this.fb.group({
      userName: [''],
      password: [''],
    });
  }

  LogintForm = new FormGroup({
    userName: new FormControl(),
    password: new FormControl(),
  })

  ngOnInit() {

  }

  loginreq: Login = new Login()

  register(user) {
    this.authService.register(user).subscribe();
  }

  login(loginreq: Login) {
    loginreq = this.LogintForm.value
    this.authService.login(loginreq)
      .subscribe((res: any) => {
        localStorage.setItem('token', res.token)
        console.log(res.token)
      this.loginreq.userName = loginreq.userName
    })
  }

  getme() {
    this.authService.getMe().subscribe((name: string) => {
      console.log(name);
    });
  }
}
