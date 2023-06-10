import { Component, HostBinding, HostListener } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  @HostBinding('class.new_nav') newNav: boolean;
  @HostListener('window:scroll') onScroll() {
    if (window.scrollY >= 50) {
      this.newNav = true;
    } else {
      this.newNav = false;
    }
  }
}
