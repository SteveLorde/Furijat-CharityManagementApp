import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup,Validators} from '@angular/forms';
import { TokenstorageService } from 'src/app/Services/tokenstorage/tokenstorage.service'
import { AuthService } from 'src/app/Services/Authorization/auth.service'
import { LoginModel } from 'src/app/Interfaces/LoginModel'
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { AuthenticatedResponse } from '../../Interfaces/AuthenticatedResponse';
import { User } from '../../Models/User';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean = false;
  user = new User();

  constructor(private router: Router, private authService: AuthService, private http: HttpClient) { }

  ngOnInit() {
  }

  login = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });


  submit(user: User): void {
    this.authService.login(user).subscribe((token: string) => {
      localStorage.setItem('authToken', token);
    })
  }

}


/*


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
