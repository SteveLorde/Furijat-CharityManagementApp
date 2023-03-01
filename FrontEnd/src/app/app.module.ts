import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './Components/home/home.component';
import { CommunicationTestComponent } from './Components/communication-test/communication-test.component';
import { CaseListComponent } from './Components/case-list/case-list.component';
import { LoginComponent } from './Components/login/login.component';
import { HTTPInterceptor } from './Services/HTTPInterceptor/http.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CommunicationTestComponent,
    CaseListComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule, FormsModule
  ],
  providers: [
    { provide: HTTPInterceptor, multi: true }]
  ,
  bootstrap: [AppComponent]
})
export class AppModule { }
