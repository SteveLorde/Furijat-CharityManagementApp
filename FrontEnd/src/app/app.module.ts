import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from 'src/app/Services/AuthGuard/authguard';
import { NgxPaginationModule } from 'ngx-pagination';
import { APIInterceptor } from 'src/app/Services/Interceptor/api.interceptor';
import { MaterialModule } from './material.module';





import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './Components/home/home.component';
import { CaseListComponent } from './Components/case-list/case-list.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { FileUploadComponent } from './Components/file-upload/file-upload.component';
import { CasestableComponent } from './Components/casestable/casestable.component';
import { ProfilepicComponent } from './Components/profilepic/profilepic.component';
import { SearchbarComponent } from './Components/searchbar/searchbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CasetablenativeComponent } from './Components/casetablenative/casetablenative.component';
import { SearchFilterPipe } from './Services/Pipes/search-filter.pipe'


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CaseListComponent,
    LoginComponent,
    RegisterComponent,
    FileUploadComponent,
    CasestableComponent,
    ProfilepicComponent,
    SearchbarComponent,
    CasetablenativeComponent,
    SearchFilterPipe,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    BrowserAnimationsModule,
    MaterialModule,
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: APIInterceptor,
    multi: true,
  },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
