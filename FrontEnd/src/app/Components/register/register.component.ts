import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, NgForm, Validators } from '@angular/forms';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserDTO } from '../../Models/UserDTO';
import { AuthService } from '../../Services/Authorization/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private router: Router, private authService: AuthService) {

  }

  user: UserDTO
  registerusertype: string

  ngOnInit(): void {
    this.getprofilepic();
  }

  imgsrc = environment.baseUrl + 'api/GetFile?filename=kfc.jpg'

  getprofilepic() {
    this.imgsrc
  }


  RegisterUser = new UntypedFormGroup({
    UserName: new UntypedFormControl(),
    EMail: new UntypedFormControl(),
    Password: new UntypedFormControl(),
    registerusertype: new UntypedFormControl(),
  })

  register(user: UserDTO) {
    user = this.RegisterUser.value
    this.authService.register(user).subscribe((res: any) => {
      if (res)
        console.log('user', res.userName, 'registered')
    })
  }



}
