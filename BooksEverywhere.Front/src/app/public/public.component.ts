import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { User } from '../models/user';
import { UserService } from '../services/user.service';
import { Helpers } from '../helpers/helpers';
import { Router } from '@angular/router';
import { TokenService } from '../services/token.service';

@Component({
  selector: 'app-public',
  templateUrl: './public.component.html'
})
export class PublicComponent implements OnInit {

  user = new User();
  userForm: FormGroup;

  constructor(private userService: UserService,
              private helpers: Helpers,
              private router: Router,
              private tokenService: TokenService,
              private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      email: [this.user.email, Validators.required],
      username: [this.user.username, Validators.required],
      password: [this.user.password, Validators.required]
    });
  }

  create() {
    if (this.userForm.invalid) { return; }

    this.user.email = this.email.value;
    this.user.username = this.username.value;
    this.user.password = this.password.value;

    if (this.user.id > 0) {
      this.userService.edit(this.user);
    } else {
      this.userService.create(this.user);
    }
  }

  // login in progress
  login(): void {
    this.user.username = this.username.value;
    this.user.password = this.password.value;
    const authValues = { Username: this.user.username, Password: this.user.password };
    this.tokenService.auth(authValues).subscribe(token => {
      this.helpers.setToken(token);
      this.router.navigate(['/dashboard']);
    });
  }

  // this is the logout:
  // this.helpers.logout();
  // this.router.navigate(['/login']);

  get email() {
    return this.userForm.get('email');
  }

  get username() {
    return this.userForm.get('username');
  }

  get password() {
    return this.userForm.get('password');
  }
}
