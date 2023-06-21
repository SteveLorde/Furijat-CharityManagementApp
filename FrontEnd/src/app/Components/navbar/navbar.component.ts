import { Component, HostBinding, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { UserStorageService } from '../../Services/UserStorageService/user-storage.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {

  loggedin: any
  signoutvisible: boolean = false

  constructor(private router: Router, private userstorage: UserStorageService) { }

  ngOnInit() {
    this.loggedin = localStorage.getItem('loggedin');
    if (this.loggedin == '1') {
      this.signoutvisible = true
    }
  }

  @HostBinding('class.new_nav') newNav: boolean;
  @HostListener('window:scroll') onScroll() {
    if (window.scrollY >= 50) {
      this.newNav = true;
    } else {
      this.newNav = false;
    }
  }

  CheckLogin() {
    console.log("logged in is" + this.userstorage.loggedin)
    if (this.userstorage.loggedin == 1) {
      this.signoutvisible = true
      this.router.navigateByUrl('/profile')
    }
    else
    {
      Swal.fire('Please Login or Register')
    }
  }

  Signout() {
    this.userstorage.DeleteStorage()
    this.router.navigateByUrl('/home')
    location.reload()
  }
}
