import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { CaseListComponent } from './Components/case-list/case-list.component';
import { LoginComponent } from 'src/app/Components/login/login.component'
import { AuthGuard } from './Services/AuthGuard/authguard';

const routes: Routes = [
  { path: 'Home', component: HomeComponent },
  { path: 'Case', component: CaseListComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
