import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  UntypedFormControl,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
import { AuthService } from 'src/app/Services/Authorization/auth.service';
import { Login } from '../../Models/Login';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AuthGuard } from '../../Services/AuthGuard/authguard';
import { User } from '../../Models/User';
import Swal from 'sweetalert2';
import { UserStorageService } from '../../Services/UserStorageService/user-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  //create object "loginrequest" of Login model
  loginreq: Login;
  //variable that changes to 1/true if login request is successful
  loggedin: any = 0;
  //store user id in variable "id"
  id: any;
  //store error response during login
  loginerror: string = ""
  //role variable for user
  role: any
  error:any

  constructor(private router: Router, private authService: AuthService, private authguard: AuthGuard, private userstorage: UserStorageService) {
  }

  LogintForm: FormGroup = new FormGroup({
    username: new FormControl('', [Validators.required, Validators.minLength(3)]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)]),
  })

  ngOnInit() {
    this.loggedin = localStorage.getItem('loggedin');
    if (this.loggedin == 1) {
      this.GoProfile();
    }
  }

  register(user) {
    this.authService.register(user).subscribe();
  }

  login() {
    this.loginreq = this.LogintForm.value
    this.authService.login(this.loginreq)
      .subscribe(
        (res: any) => {
         this.userstorage.user = res
         this.userstorage.loggedin = 1
        console.log(this.userstorage.user)
        this.GoProfile()
        },
        (error) => {
          Swal.fire({
            icon: 'error',
            title: 'Login Error',
            text: error.error,
          })
        }
      )
  }

  GoProfile() {
    this.router.navigateByUrl('/profile');
  }

  Back() {
    this.router.navigateByUrl('/home')
  }
}
