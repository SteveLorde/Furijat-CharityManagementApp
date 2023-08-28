
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from 'src/app/Components/login/login.component';
import { RegisterComponent } from 'src/app/Components/register/register.component';
import { ContactformComponent } from './Components/contactform/contactform.component';
import { EditDataComponent } from './Components/edit-data/edit-data.component';


const routes: Routes = [
      { path: '', component: HomeComponent },
      { path: 'contactform', component: ContactformComponent },
      { path: 'edit', component: EditDataComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
