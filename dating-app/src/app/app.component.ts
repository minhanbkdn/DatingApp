import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Dating ABC';
  users: User[] = [];

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.fetchUsers();
  }

  fetchUsers() {
    this.httpClient
      .get('https://localhost:5001/api/users')
      .subscribe((response) => {
        this.users = response as User[];
      });
  }
}
