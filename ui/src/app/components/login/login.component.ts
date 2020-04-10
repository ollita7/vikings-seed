import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  login(){
    const data = {username: this.username, password: this.password };
    this.userService.login(data).subscribe((response: any) => {
      if (response.result === 0){
        this.router.navigate(['private']);
      }
    });
  }

}
