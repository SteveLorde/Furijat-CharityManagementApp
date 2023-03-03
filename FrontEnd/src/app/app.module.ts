import { HttpClientModule} from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from 'src/app/Services/AuthGuard/authguard';



import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './Components/home/home.component';
import { CaseListComponent } from './Components/case-list/case-list.component';
import { LoginComponent } from './Components/login/login.component';
import { APIInterceptor } from 'src/app/Services/Interceptor/api.interceptor';
import { RegisterComponent } from './Components/register/register.component';

import { tokenGetter } from 'src/app/Interfaces/tokengetter'


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CaseListComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule, FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5001"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
