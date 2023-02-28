import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormGroup, FormControl, Validators, AbstractControl, AsyncValidatorFn
} from '@angular/forms';

import { AuthService } from 'src/app/Services/Authorization/auth.service';
import { LoginRequest } from 'src/app/Services/Authorization/login-request';
import { LoginResult } from 'src/app/Services/Authorization/login-result';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  title?: string;
  loginResult?: LoginResult;
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private authService: AuthService) {
  }

  ngOnInit() {
    this.form = new FormGroup({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    var loginRequest = <LoginRequest>{};
    loginRequest.email = this.form.controls['email'].value;
    loginRequest.password = this.form.controls['password'].value;
    this.authService
      .login(loginRequest)
      .subscribe(result => {
        console.log(result);
        this.loginResult = result;
        if (result.success && result.token) {
          localStorage.setItem(this.authService.tokenKey, result.token);
        }
      }, error => {
        console.log(error);
        if (error.status == 401) {
          this.loginResult = error.error;
        }
      });
  }
}
