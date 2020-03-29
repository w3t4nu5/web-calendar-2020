import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {UserService} from "../shared/services/user.service";
import {User} from "../shared/User";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  loginForm: FormGroup;
  submitted = false;

  constructor(private _formBuilder: FormBuilder, private _router: Router, private _userService: UserService) {
  }

  ngOnInit() {
    this.loginForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.pattern(".*[a-zA-Z].*")]]
    });
  }

  get f() {
    return this.loginForm.controls;
  }


  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      console.log(this.loginForm);
      return;
    }

    const user: User = {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password
    }
  }
}
