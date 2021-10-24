import { AccountsService } from './_services/accounts.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(public accountsService: AccountsService) {}

  ngOnInit(): void {
    this.accountsService.refreshToken();
  }
}
