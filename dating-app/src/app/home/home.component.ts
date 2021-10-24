import { Component, OnInit } from '@angular/core';
import { UserRegister } from '../_models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  isRegisterMode = false;
  user: UserRegister = {
    username: '',
    email: '',
    password: '',
  };
  constructor() {}

  ngOnInit(): void {}

  cancelRegisterMode(event) {
    this.isRegisterMode = event;
  }
}
