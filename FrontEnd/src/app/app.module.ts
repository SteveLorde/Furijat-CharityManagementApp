import { HttpClientModule} from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from 'src/app/Services/AuthGuard/authguard';
import { NgxPaginationModule } from 'ngx-pagination';




import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './Components/home/home.component';
import { CaseListComponent } from './Components/case-list/case-list.component';
import { LoginComponent } from './Components/login/login.component';
//import { APIInterceptor } from 'src/app/Services/Interceptor/api.interceptor';
import { RegisterComponent } from './Components/register/register.component';
import { tokenGetter } from 'src/app/Interfaces/tokengetter';
import { FileUploadComponent } from './Components/file-upload/file-upload.component';
import { CasestableComponent } from './Components/casestable/casestable.component';
import { ProfilepicComponent } from './Components/profilepic/profilepic.component'


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CaseListComponent,
    LoginComponent,
    RegisterComponent,
    FileUploadComponent,
    CasestableComponent,
    ProfilepicComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule, FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:3001"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
