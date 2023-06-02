import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import { AuthService } from 'src/app/Services/Authorization/auth.service'

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService,  private router: Router) { }

  canActivate( route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    //If token data exist, user may login to application
    if (localStorage.getItem('authToken')) {
      return true;
    }


    // otherwise redirect to login page with the return url
    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    this.authService.accesserror();
    return false;
  }
}
