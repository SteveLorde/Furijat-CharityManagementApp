import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CasetablenativeComponent } from './Components/casetablenative/casetablenative.component';
import { SearchFilterPipe } from './Services/Pipes/search-filter.pipe'
import { AddcaseComponent } from 'src/app/Components/addcase/addcase.component';
import { DonateComponent } from 'src/app/Components/donate/donate.component';
import { ProfileComponent } from 'src/app/Components/profile/profile.component';
import { CharitydonationComponent } from 'src/app/Components/charitydonation/charitydonation.component';
import { DonatecharityComponent } from 'src/app/Components/donatecharity/donatecharity.component';
import { AddcharityComponent } from 'src/app/Components/addcharity/addcharity.component';
import { ValidatecaseComponent } from 'src/app/Components/validatecase/validatecase.component';
import { UserlogComponent } from 'src/app/Components/userlog/userlog.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CaseListComponent,
    LoginComponent,
    RegisterComponent,
    FileUploadComponent,
    CasestableComponent,
    CasetablenativeComponent,
    SearchFilterPipe,
    AddcaseComponent,
    DonateComponent,
    ProfileComponent,
    CharitydonationComponent,
    DonatecharityComponent,
    AddcharityComponent,
    ValidatecaseComponent,
    UserlogComponent,
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
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: APIInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
