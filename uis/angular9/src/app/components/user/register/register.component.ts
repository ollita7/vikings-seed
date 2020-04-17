import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user/user.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatePassowrd } from '../../../shared/validators/custom.validators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  hide = true;

  get f() { return this.registerForm.controls; }

  constructor(private userService: UserService, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      password2: ['', [Validators.required, Validators.minLength(6)]]
    },
    {
      validator: ValidatePassowrd('password', 'password2', 'Password and Password Confirmation doesnt match')
    }
    );
  }

  register(){
    if (this.registerForm.valid){
      this.userService.register(this.registerForm.value).subscribe((response: any) => {
        if (response.result === 0){
          this.router.navigate(['login']);
        }
      });
    }
  }

  getUsernameErrorMessage(){
    if (this.f.username.errors.required){
      return 'Username is required';
    }
  }
  getEmailErrorMessage(){
    if (this.f.email.errors.required){
      return 'Email is required';
    }
    if (this.f.email.errors.email){
      return 'Email is invalid';
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

  getPassword2ErrorMessage(){
    if (this.f.password2.errors.required){
      return 'Password is required';
    }
    if (this.f.password2.errors.minlength){
      return 'Password need to be at least 6 characteres';
    }
    if (this.f.password2.errors.doesntmutch){
      return this.f.password2.errors.doesntmutch;
    }
  }

}
