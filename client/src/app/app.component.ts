import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';

import { NavComponent } from './nav/nav.component';

interface User {
  id: number;
  userName: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule, NavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  title = 'Angular added!!';
  users!: User[];
  selectedUser!: User;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.makeApiCall();
  }

  makeApiCall(): void {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: (data: any) => (this.users = data as User[]),
      error: (err) => console.log(err),
      complete: () => console.log('req has completed'),
    });
  }
}
