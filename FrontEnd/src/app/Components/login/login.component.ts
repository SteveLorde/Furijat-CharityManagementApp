import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup,Validators} from '@angular/forms';
import { AuthService } from 'src/app/Services/Authorization/auth.service'
import { Login } from '../../Models/Login';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AuthGuard } from '../../Services/AuthGuard/authguard';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  //create object "loginrequest" of Login model
  loginreq: Login
  //variable that changes to 1/true if login request is successful
  loggedin: any = 0
  //store user id in variable "id"
  id: any
  //store error response during login
  loginerror: string = ""

  constructor(private router: Router, private authService: AuthService, private authguard: AuthGuard) {
  }

  LogintForm = new UntypedFormGroup({
    username: new UntypedFormControl(),
    password: new UntypedFormControl(),
  })

  ngOnInit() {
    this.loggedin = localStorage.getItem('loggedin')
    if (this.loggedin == 1) {
      this.GoProfile()
    }
  }

  register(user) {
    this.authService.register(user).subscribe();
  }

  login() {
    this.loginreq = this.LogintForm.value
    this.authService.login(this.loginreq)
      .subscribe((res: any) => {
        this.id = res.userId
        //set token
        localStorage.setItem('authToken', res.token)
        //variable used to check if logged in (to influnece other HTML elements)
        localStorage.setItem('loggedin', "1")
        localStorage.setItem('UID', res.userId)
        //set user role
        if (res.userId == 1) {
          localStorage.setItem('UType', 'admin')
        }
        else if (res.userId == 2) { localStorage.setItem('UType', 'charity') }
        else if (res.userId == 3) { localStorage.setItem('UType', 'debtor') }
        else if (res.userId == 4) { localStorage.setItem('UType', 'donator') }
        else if (res.userId == 5) { localStorage.setItem('UType', 'creditor') }
        this.authguard.currentuserole = localStorage.getItem('UType')
        //this.loginreq.username = this.loginreq.username
        this.loggedin = 1
        this.GoProfile()
      })
  }

  GoProfile() {
    this.router.navigateByUrl('profile')
  }

  GoRegister() {
    this.router.navigateByUrl('register')
  }
}
