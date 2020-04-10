import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { PrivateComponent } from './components/private/private.component';
import { UsersComponent } from './components/users/users.component';


const routes: Routes = [
  { path: '', component: LoginComponent},
  { path: 'private', component: PrivateComponent, children: [
    { path: 'users', component: UsersComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
