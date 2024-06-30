import { Component, OnInit, inject } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  accountService = inject(AccountService);
  model: any = {};

  ngOnInit(): void {}

  login() {
    this.accountService.login(this.model).subscribe({
      next: (res) => {
        console.log('res', res);
      },
      error: (err) => console.log('err', err),
    });
  }

  logout() {
    this.accountService.logout();
  }
}
