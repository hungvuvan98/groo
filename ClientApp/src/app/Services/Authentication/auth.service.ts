import { Injectable } from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(private http: HttpClient) { }

  Login(data): Observable<any> {
    var url = environment.apiUrl + 'user/login';
    return this.http.post(url, data);
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
