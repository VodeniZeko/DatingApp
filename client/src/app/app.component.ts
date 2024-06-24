import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { AccountService } from './_services/account.service';

interface User {
  id: number;
  userName: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  private accountService = inject(AccountService);
  users!: User[];
  selectedUser!: User;

  ngOnInit(): void {
    this.getUsers();
    this.setCurrUser();
  }

  setCurrUser() {
    const userString = localStorage.getItem('user');

    if (!userString) return;

    const user = JSON.parse(userString);
    this.accountService.currUser.set(user);
  }

  getUsers(): void {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: (data: any) => (this.users = data as User[]),
      error: (err) => console.log(err),
      complete: () => console.log('req has completed'),
    });
  }
}
