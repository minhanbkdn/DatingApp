import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountsService } from '../_services/accounts.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private accountsService: AccountsService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // add auth header with jwt if account is logged in and request is to the api url
    let token = '';
    this.accountsService.currentUser$.subscribe(
      (account) => (token = account?.token)
    );
    if (token) {
      request = request.clone({
        setHeaders: { Authorization: `Bearer ${token}` },
      });
    }
    return next.handle(request);
  }
}
