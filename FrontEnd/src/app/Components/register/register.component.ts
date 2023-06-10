import { Component, OnInit } from '@angular/core';
import {
  UntypedFormControl,
  UntypedFormGroup,
  NgForm,
  Validators,
  FormGroup,
  FormControl,
} from '@angular/forms';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserDTO } from '../../Models/UserDTO';
import { AuthService } from '../../Services/Authorization/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(private router: Router, private authService: AuthService) {}

  user: UserDTO;

  ngOnInit(): void {
    this.getprofilepic();
  }

  imgsrc = environment.baseUrl + 'api/GetFile?filename=kfc.jpg';

  getprofilepic() {
    this.imgsrc;
  }

  RegisterUser: FormGroup = new FormGroup({
    UserName: new FormControl(''),
    FirstName: new FormControl(''),
    LastName: new FormControl(''),
    EMail: new FormControl(''),
    Password: new FormControl(''),
  });

  register(user: UserDTO) {
    user = this.RegisterUser.value;
    this.authService.register(user).subscribe((res: any) => {
      if (res) console.log('user', res.userName, 'registered');
    });
  }
}
