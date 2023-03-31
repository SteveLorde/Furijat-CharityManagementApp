import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { CaseListComponent } from './Components/case-list/case-list.component';
import { LoginComponent } from 'src/app/Components/login/login.component';
import { RegisterComponent } from 'src/app/Components/register/register.component';
import { AddcaseComponent } from 'src/app/Components/addcase/addcase.component';
import { AuthGuard } from './Services/AuthGuard/authguard';

const routes: Routes = [
  { path: 'Home', component: HomeComponent },
  { path: 'Case', component: CaseListComponent},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'addcase', component: AddcaseComponent, canActivate: [AuthGuard], data: { role: 'User'} },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
