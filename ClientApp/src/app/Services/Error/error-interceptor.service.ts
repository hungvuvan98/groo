import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {retry, catchError} from 'rxjs/operators'
import { Observable, throwError } from 'rxjs';
import { NotificationService } from '../Notification/notification.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService {

  constructor(private noticeService : NotificationService) { }
  
  intercept(request: HttpRequest<any>,next: HttpHandler): Observable<HttpEvent<any>>{
      
      return next.handle(request).pipe(
          retry(1),
          catchError((err)=>{
              if(err.status==401){
                  this.noticeService.show("error", `${err.error}`);
              }
              else if(err.status==404){
                  this.noticeService.show("error", `${err.error}`);
              }
              else if(err.status==400){
                  this.noticeService.show("error", "status 400");
              }
               else if(err.status==403){
                  this.noticeService.show("error", "status 403, Not Role");
              }
              else{
                  this.noticeService.show("error", "Failed");
              }
              return throwError(err)
          })
      )
    }

}

