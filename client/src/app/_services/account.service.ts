import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';

import { User } from 'src/app/_models/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = 'https://localhost:5001/api/';
  private currUserSource = new BehaviorSubject<User | null>(null);
  currUser$ = this.currUserSource.asObservable();

  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currUserSource.next(user);
        }
      })
    );
  }

  setCurrUser(user: User) {
    this.currUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currUserSource.next(null);
  }
}
