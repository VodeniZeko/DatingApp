import { Component } from '@angular/core';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  model: any = {};
  loggedIn!: boolean;

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {}

  login() {
    this.accountService.login(this.model).subscribe({
      next: (res) => {
        console.log('res', res);
        this.loggedIn = true;
      },
      error: (err) => console.log('err', err),
    });
  }

  logout() {
    this.loggedIn = false;
  }
}
