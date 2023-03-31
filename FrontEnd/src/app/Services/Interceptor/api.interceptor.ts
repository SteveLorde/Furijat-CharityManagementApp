import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/Services/Authorization/auth.service'


@Injectable()
export class APIInterceptor implements HttpInterceptor {

  constructor(private http: AuthService) { }
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('authToken');

    if (token) {
      req = req.clone({
        setHeaders: { Authorization: `Bearer${token}` },
      });
    }

    return next.handle(req);
  }
}
