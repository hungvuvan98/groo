import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import{environment} from '../../../environments/environment'

@Injectable()
export class ProductService {

 private url = environment.apiUrl + 'product/';

constructor(private http: HttpClient) {
  
 }

  GetAll(): Observable<any[]>{
    return this.http.get<any[]>(this.url + 'GetAll');
  }
  
}
