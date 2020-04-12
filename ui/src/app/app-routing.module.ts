import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/user/login/login.component';
import { PrivateComponent } from './components/private/private.component';
import { UsersComponent } from './components/users/users.component';
import { RegisterComponent } from './components/user/register/register.component';
import { ResetPasswordComponent } from './components/user/reset-password/reset-password.component';
import { ForgotPasswordComponent } from './components/user/forgot-password/forgot-password.component';
import { AuthorizationGuard } from './shared/guards/authorization.guard';


const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full'},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'reset-password', component: ResetPasswordComponent},
  { path: 'forgot-password/:token', component: ForgotPasswordComponent},
  { path: 'private', component: PrivateComponent, canActivate: [AuthorizationGuard], children: [
    { path: 'users', component: UsersComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
