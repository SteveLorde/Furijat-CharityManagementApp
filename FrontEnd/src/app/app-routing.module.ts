import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { CaseListComponent } from './Components/case-list/case-list.component';
import { LoginComponent } from 'src/app/Components/login/login.component';
import { RegisterComponent } from 'src/app/Components/register/register.component';
import { AddcaseComponent } from 'src/app/Components/addcase/addcase.component';
import { AuthGuard } from './Services/AuthGuard/authguard';
import { DonateComponent } from 'src/app/Components/donate/donate.component';
import { ProfileComponent } from 'src/app/Components/profile/profile.component';
import { CharitydonationComponent } from 'src/app/Components/charitydonation/charitydonation.component';
import { DonatecharityComponent } from 'src/app/Components/donatecharity/donatecharity.component';
import { AddcharityComponent } from 'src/app/Components/addcharity/addcharity.component';
import { ValidatecaseComponent } from 'src/app/Components/validatecase/validatecase.component';
import { ContactformbackendComponent } from 'src/app/Components/contactformbackend/contactformbackend.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Case', component: CaseListComponent},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'addcase', component: AddcaseComponent},
  { path: 'donate/:id', component: DonateComponent},
  { path: 'profile', component: ProfileComponent },
  { path: 'charitylist', component:  CharitydonationComponent},
  { path: 'donatecharity/:id', component: DonatecharityComponent },
  { path: 'addcharity', component: AddcharityComponent },
  //Don't Forget to add route guard for Charity logged in user
  { path: 'validatecase', component: ValidatecaseComponent,},
  //{ path: 'contactform', component: ContactformComponent },
  { path: 'contactformbackend', component: ContactformbackendComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
