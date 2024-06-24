import { Component, inject } from '@angular/core';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
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
