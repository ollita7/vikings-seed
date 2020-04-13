import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user/user.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  hide = true;

  get f() { return this.loginForm.controls; }

  constructor(private userService: UserService, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    }
   );
  }

  login(){
    if (this.loginForm.valid){
      this.userService.login(this.loginForm.value);
    }
  }

  getUsernameErrorMessage(){
    if (this.f.username.errors.required){
      return 'Email or Username is required';
    }
  }

  getPasswordErrorMessage(){
    if (this.f.password.errors.required){
      return 'Password is required';
    }
    if (this.f.password.errors.minlength){
      return 'Password need to be at least 6 characteres';
    }
  }

}
