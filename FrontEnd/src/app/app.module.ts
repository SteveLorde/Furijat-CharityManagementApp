import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CasetablenativeComponent } from './Components/casetablenative/casetablenative.component';
import { SearchFilterPipe } from './Services/Pipes/search-filter.pipe';
import { AddcaseComponent } from 'src/app/Components/addcase/addcase.component';
import { DonateComponent } from 'src/app/Components/donate/donate.component';
import { ProfileComponent } from 'src/app/Components/profile/profile.component';
import { CharitydonationComponent } from 'src/app/Components/charitydonation/charitydonation.component';
import { DonatecharityComponent } from 'src/app/Components/donatecharity/donatecharity.component';
import { AddcharityComponent } from 'src/app/Components/addcharity/addcharity.component';
import { ValidatecaseComponent } from 'src/app/Components/validatecase/validatecase.component';
import { UserlogComponent } from 'src/app/Components/userlog/userlog.component';
import { CasestatusfilterPipe } from './Services/Pipes/casestatusfilter.pipe';
import { CasestatusValidfilterPipe } from './Services/Pipes/casestatusvalidfilter.pipe';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { AboutComponent } from './Components/about/about.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { BlankLayoutComponent } from './layouts/blank-layout/blank-layout.component';
import { NotfoundComponent } from './Components/notfound/notfound.component';
import { FooterComponent } from './Components/footer/footer.component';
import { ContactformComponent  } from './Components/contactform/contactform.component';
import { DonatorprofileComponent } from './Components/donatorprofile/donatorprofile.component';
import { CreditorprofileComponent } from './Components/Profiles/creditorprofile/creditorprofile.component';
import { DebtorprofileComponent } from './Components/Profiles/debtorprofile/debtorprofile.component';
import { CharityprofileComponent } from './Components/Profiles/charityprofile/charityprofile.component';
import { ProvideassistanceComponent } from './Components/provideassistance/provideassistance.component';
import { EditDataComponent } from './Components/edit-data/edit-data.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    CaseListComponent,
    LoginComponent,
    RegisterComponent,
    FileUploadComponent,
    CasetablenativeComponent,
    SearchFilterPipe,
    CasestatusfilterPipe,
    CasestatusValidfilterPipe,
    AddcaseComponent,
    DonateComponent,
    ProfileComponent,
    CharitydonationComponent,
    DonatecharityComponent,
    AddcharityComponent,
    ValidatecaseComponent,
    UserlogComponent,
    AboutComponent,
    AuthLayoutComponent,
    BlankLayoutComponent,
    NotfoundComponent,
    FooterComponent,
    ContactformComponent,
    DonatorprofileComponent,
    CreditorprofileComponent,
    DebtorprofileComponent,
    CharityprofileComponent,
    ProvideassistanceComponent,
    EditDataComponent,
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
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
