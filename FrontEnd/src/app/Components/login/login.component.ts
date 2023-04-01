import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup,Validators} from '@angular/forms';
import { AuthService } from 'src/app/Services/Authorization/auth.service'
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { User } from '../../Models/User';
import { Login } from '../../Models/Login';
import { ClassTest } from '../../Models/classtest';





@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: User = <User>{};
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

 

  loginDTO: Login;

  register(user) {
    this.authService.register(user).subscribe();
  }

  login(loginDTO) {
    this.authService.login(loginDTO).subscribe((token: string) => {
      localStorage.setItem('authToken', token);
    })
    //this.obj.userName = 'mumford'
    //console.log(this.obj.userName);
  }

  getme() {
    this.authService.getMe().subscribe((name: string) => {
      console.log(name);
    });
  }
}


/*


  loginUser() {
    this.authService.login(this.signinForm.value);
  }
/*
//form controls for HTML template

*/


/*
login = new FormGroup({
  email: new FormControl('', Validators.required),
  password: new FormControl('', Validators.required),
});
*/

/*
login = (form: NgForm) => {
  if (form.valid) {
    this.http.post<AuthenticatedResponse>("https://localhost:5001/api/auth/login", this.credentials, {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    })
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.token;
          localStorage.setItem("jwt", token);
          this.invalidLogin = false;
          this.router.navigate(["/"]);
        },
        error: (err: HttpErrorResponse) => this.invalidLogin = true
      })
  }
}
*/
