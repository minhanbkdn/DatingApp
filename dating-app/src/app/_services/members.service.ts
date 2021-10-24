import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root',
})
export class MembersService {
  constructor(private httpClient: HttpClient) {}
  baseUrl = 'https://localhost:5001/api/users';

  public getMembers(): Observable<Member[]> {
    return this.httpClient.get<Member[]>(this.baseUrl);
  }

  public getMemberByUsername(username: string): Observable<Member> {
    return this.httpClient.get<Member>(`${this.baseUrl}/${username}`);
  }
}
