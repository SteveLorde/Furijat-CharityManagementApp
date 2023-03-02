import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TokenstorageService } from 'src/app/Services/tokenstorage/tokenstorage.service'
import { AuthService } from 'src/app/Services/Authorization/auth.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //signin related variables
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];

  constructor(private authService: AuthService, private tokenStorage: TokenstorageService) { }

  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
      this.roles = this.tokenStorage.getUser().roles;
    }
  }

  //form controls for HTML template
  login = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  submitted = false;

  onSubmit(): void {
    console.log("submitted logged");
  }


}
