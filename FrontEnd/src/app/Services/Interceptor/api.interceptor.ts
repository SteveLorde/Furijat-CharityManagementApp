import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenstorageService } from 'src/app/Services/tokenstorage/tokenstorage.service'


const tokenheaderk = 'Authorization';


@Injectable()
export class APIInterceptor implements HttpInterceptor {

  constructor(private token: TokenstorageService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    //put request modifications here

    let authReq = request;
    const token = this.token.getToken();
    if (token != null) {
      authReq = request.clone({ headers: request.headers.set(tokenheaderk, 'Bearer' + token) });
    }
      return next.handle(authReq);
    }
}
