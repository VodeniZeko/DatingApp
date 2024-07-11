import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  inject,
} from '@angular/core';

import { ToastrService } from 'ngx-toastr';

import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  private toastr = inject(ToastrService);
  accountService = inject(AccountService);
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  ngOnInit(): void {}

  register() {
    this.accountService.register(this.model).subscribe({
      next: () => this.cancel(),
      error: (err) => console.log(err),
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
