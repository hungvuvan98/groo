import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './Services/Authentication/auth.service';
import { AuthGuardService } from './Services/Authentication/authGuard.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptorService } from './Services/Error/error-interceptor.service';
import { TokenInterceptorService } from './Services/Authentication/tokenInterceptor.service';
import { NotificationService } from './Services/Notification/notification.service';
import { NotifierModule } from 'angular-notifier';
import { customNotifierOptions } from './Services/Notification/notification-config';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [  
    AppComponent,
    LoginComponent
  ],
  imports: [
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    NotifierModule.withConfig(customNotifierOptions),
  ],
  providers: [
    AuthService,
    AuthGuardService,
    {
      provide:HTTP_INTERCEPTORS,
      useClass:TokenInterceptorService,
      multi:true
    },
    {
      provide:HTTP_INTERCEPTORS,
      useClass:ErrorInterceptorService,
      multi:true
    },
    NotificationService,
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
