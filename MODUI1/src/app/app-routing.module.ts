import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserSignupComponent} from './signup/user/user-signup/user-signup.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/',
    pathMatch: 'full'
  },
  {
    path:'usersignup',
    component : UserSignupComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
