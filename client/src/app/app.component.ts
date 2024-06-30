import { Component, OnInit, inject } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/user';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  private accountService = inject(AccountService);

  ngOnInit(): void {
    this.setCurrUser();
  }

  setCurrUser() {
    const userString = localStorage.getItem('user');

    if (!userString) return;

    const user: User = JSON.parse(userString);
    this.accountService.setCurrUser(user);
  }
}
