import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { User } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-public',
  templateUrl: './public.component.html',
})
export class PublicComponent implements OnInit {

  user = new User();
  rForm: FormGroup;
  
  constructor(private userService: UserService) {
  }

  ngOnInit() {
    this.rForm = new FormGroup({
      name: new FormControl(this.user.name),
      email: new FormControl(this.user.email),
      username: new FormControl(this.user.username),
      password: new FormControl(this.user.password)
    });
  }

  create(): void {
    if (this.rForm.invalid) return;

    this.user.name = this.name.value;
    this.user.email = this.email.value;
    this.user.username = this.username.value;
    this.user.password = this.password.value;

    if (this.user.id > 0) {
      this.userService.edit(this.user);
    } else {
      this.userService.create(this.user);
    }
  }

  get name() {
    return this.rForm.get('nome');
  }

  get email() {
    return this.rForm.get('email');
  }

  get username() {
    return this.rForm.get('username');
  }

  get password() {
    return this.rForm.get('password');
  }

  get unidades() {
    return this.rForm.get('unidades');
  }
}
