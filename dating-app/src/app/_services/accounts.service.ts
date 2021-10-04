import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserRegister, UserToken } from '../_models/user';
import { UserLogin } from '../_models/userLogin';

@Injectable({
  providedIn: 'root',
})
export class AccountsService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  baseUrl = 'https://localhost:5001/api/accounts';
  private currentUser = new BehaviorSubject<UserToken>(null);
  currentUser$ = this.currentUser.asObservable();

  constructor(private httpClient: HttpClient) {}

  login(userLogin: UserLogin): Observable<any> {
    return this.httpClient
      .post<any>(`${this.baseUrl}/login`, userLogin, this.httpOptions)
      .pipe(
        map((response: UserToken) => {
          const user = response;
          if (user) {
            localStorage.setItem('userToken', JSON.stringify(user));
            this.currentUser.next(user);
          }
        })
      );
  }

  logout() {
    localStorage.removeItem('userToken');
    this.currentUser.next(null);
  }

  register(user: UserRegister) {
    return this.httpClient
      .post<any>(`${this.baseUrl}/register`, user, this.httpOptions)
      .pipe(
        map((response: UserToken) => {
          const user = response;
          if (user) {
            localStorage.setItem('userToken', JSON.stringify(user));
            this.currentUser.next(user);
          }
        })
      );
  }
}
