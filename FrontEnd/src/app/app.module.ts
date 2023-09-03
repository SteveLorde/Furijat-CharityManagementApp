import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { APIInterceptor } from 'src/app/Services/Interceptor/api.interceptor';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './Components/home/home.component';
import { FileUploadComponent } from './Components/file-upload/file-upload.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SearchFilterPipe } from './Services/Pipes/search-filter.pipe';
import { CasestatusfilterPipe } from './Services/Pipes/casestatusfilter.pipe';
import { CasestatusValidfilterPipe } from './Services/Pipes/casestatusvalidfilter.pipe';
import { EditDataComponent } from './Components/edit-data/edit-data.component';
import { FilterbycharityidPipe } from './Services/Pipes/filterbycharityid.pipe';
import { FilterbystatusPipe } from './Services/Pipes/filterbystatus.pipe';
import { FilterbydonatoridPipe } from './Services/Pipes/filterbydonatorid.pipe';
import { FilterbycaseidPipe } from './Services/Pipes/filterbycaseid.pipe';
import { FilterbycreditorsbycaseIDPipe } from './Services/Pipes/filterbycreditorsbycase-id.pipe';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { DonatorDashboardComponent } from './Components/Dashboard/donator-dashboard/donator-dashboard.component';
import { CharityDashboardComponent } from './Components/Dashboard/charity-dashboard/charity-dashboard.component';
import { CaseDashboardComponent } from './Components/Dashboard/case-dashboard/case-dashboard.component';
import { AdminDashboardComponent } from './Components/Dashboard/admin-dashboard/admin-dashboard.component';
import { MainDashboardComponent } from './Components/Dashboard/main-dashboard.component';
import { CasesPageComponent } from './Components/Pages/cases-page/cases-page.component';
import { ContactFormPageComponent } from './Components/Pages/contact-form-page/contact-form-page.component';
import { CharitiesPageComponent } from './Components/Pages/charities-page/charities-page.component';
import { LoginRegisterComponent } from './Components/login-register/login-register.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FileUploadComponent,
    SearchFilterPipe,
    CasestatusfilterPipe,
    CasestatusValidfilterPipe,
    EditDataComponent,
    FilterbycharityidPipe,
    FilterbystatusPipe,
    FilterbydonatoridPipe,
    FilterbycaseidPipe,
    FilterbycreditorsbycaseIDPipe,
    NavbarComponent,
    DonatorDashboardComponent,
    CharityDashboardComponent,
    CaseDashboardComponent,
    AdminDashboardComponent,
    MainDashboardComponent,
    CasesPageComponent,
    ContactFormPageComponent,
    CharitiesPageComponent,
    LoginRegisterComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    BrowserAnimationsModule,
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
