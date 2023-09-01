
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { EditDataComponent } from './Components/edit-data/edit-data.component';
import { DonatorDashboardComponent } from './Components/Dashboard/donator-dashboard/donator-dashboard.component';
import { CharityDashboardComponent } from './Components/Dashboard/charity-dashboard/charity-dashboard.component';
import { CaseDashboardComponent } from './Components/Dashboard/case-dashboard/case-dashboard.component';
import { AdminDashboardComponent } from './Components/Dashboard/admin-dashboard/admin-dashboard.component';
import { MainDashboardComponent } from './Components/Dashboard/main-dashboard.component';
import { CasesPageComponent } from './Components/Pages/cases-page/cases-page.component';
import { ContactFormPageComponent } from './Components/Pages/contact-form-page/contact-form-page.component';
import { CharitiesPageComponent } from './Components/Pages/charities-page/charities-page.component';


const routes: Routes = [
      { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'cases', component: CasesPageComponent },
    { path: 'contact', component: ContactFormPageComponent },
      { path: 'edit', component: EditDataComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
