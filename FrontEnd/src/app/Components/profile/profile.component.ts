import { Component, OnInit } from '@angular/core';
import { UserDTO } from '../../Models/UserDTO';
import { UserType } from 'src/app/Models/UserType';
import { AuthService } from 'src/app/Services/Authorization/auth.service';
import { BackendCommunicationService } from '../../Services/BackendCommunication/backend-communication.service';

export interface PagingConfig {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
}
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  //create object "user" of User model
  user = {} as UserDTO;
  id: any;
  p: number = 1;
  constructor(private _servercom: BackendCommunicationService) {}

  ngOnInit(): void {
    this.id = localStorage.getItem('UID');
    this.GetProfile();
  }

  GetProfile() {
    this._servercom.getUserbyId(this.id).subscribe((res: any) => {
      this.user = res;
    });
  }
}
