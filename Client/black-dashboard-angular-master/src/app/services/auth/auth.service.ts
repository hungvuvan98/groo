import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,private router:Router) { }

  Login(data): Observable<any> {
    var url = environment.apiUrl + 'User/Login';  
    return this.http.post(url,data);
  }

  LogOut() {
    localStorage.removeItem('token');
    this.router.navigate(['/login'])
  }

  saveToken(token){
    localStorage.setItem('token',token);
  }

  getToken(){
    return localStorage.getItem('token');
  }

  isAuthenticated(){
    if(this.getToken()){
      return true;
    }
    return false;
  }
  
}


