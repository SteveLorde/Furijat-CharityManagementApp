import { Injectable } from '@angular/core';
import { HttpRequest,HttpHandler,HttpEvent,HttpInterceptor} from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class APIInterceptor implements HttpInterceptor {

  //function to watch any HTTP request, clone it, and add new "Token" header to it
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('authToken');

    if (token) {
      req = req.clone({
        setHeaders: { Token: `Bearer ${token}` },
      });
    }

    return next.handle(req);
  }
}
