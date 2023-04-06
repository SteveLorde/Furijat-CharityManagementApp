import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup,Validators} from '@angular/forms';
import { AuthService } from 'src/app/Services/Authorization/auth.service'
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { User } from '../../Models/User';
import { Login } from '../../Models/Login';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';





@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  signinForm: FormGroup;
  loggedin: any = 0
  id: any



  constructor(private router: Router, private route: ActivatedRoute, private authService: AuthService, private http: HttpClient, public fb: FormBuilder) {
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
    this.loggedin = localStorage.getItem('loggedin')
    if (this.loggedin == 1) {
      //this.GoProfile()
    }
  }


  loginreq: Login = new Login()

  register(user) {
    this.authService.register(user).subscribe();
  }

  login(loginreq: Login) {
    loginreq = this.LogintForm.value
    this.authService.login(loginreq)
      .subscribe((res: any) => {
        this.id = res.userId
        localStorage.setItem('authToken', res.token)
        localStorage.setItem('loggedin', "1")
        localStorage.setItem('UID', res.userId)
        console.log(res.token)
        this.loginreq.userName = loginreq.userName
        this.loggedin = 1
        //this.GoProfile()
      })
  }

  getme() {
    this.authService.getMe().subscribe((name: string) => {
      console.log(name);
    });
  }
  /*
  GoProfile() {
    this.router.navigateByUrl('profile')
  }
  */
}
