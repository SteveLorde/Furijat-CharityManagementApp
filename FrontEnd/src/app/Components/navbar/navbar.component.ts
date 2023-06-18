import { Component, HostBinding, HostListener } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {

  loggedin: any
  signoutvisible: boolean = false

  constructor(private router: Router) { }

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

  Signout() {
    localStorage.clear()
    this.router.navigateByUrl('/home')
    location.reload()
  }
}
