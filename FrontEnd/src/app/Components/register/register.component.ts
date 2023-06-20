import { Component, OnInit } from '@angular/core';
import {
  NgForm,
  Validators,
  FormGroup,
  FormControl,
  UntypedFormControl,
  UntypedFormGroup,
} from '@angular/forms';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../../Models/User';
import { AuthService } from '../../Services/Authorization/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(private router: Router, private authService: AuthService) { }

  user: User
  //imgsrc = environment.baseUrl + 'api/GetFile?filename=kfc.jpg'

  registerusertype: string


  ngOnInit(): void {
    this.getprofilepic()
  }



  getprofilepic() {
    //this.imgsrc
  }


  RegisterUser = new UntypedFormGroup({
    userName: new UntypedFormControl('', [Validators.required]),
    //EMail: new FormControl(),
    password: new UntypedFormControl('', [Validators.required]),
    firstName: new UntypedFormControl(),
    lastName: new UntypedFormControl(),
  })

  Register() {
    const user = this.RegisterUser.value
    user.userType = "User"
    this.authService.register(user).subscribe((res: any) => {
      if (res) console.log('user', res.userName, 'registered')
    })
    this.router.navigateByUrl('/profile')
  }

  Back() {
    this.router.navigateByUrl('/home')
  }

}
