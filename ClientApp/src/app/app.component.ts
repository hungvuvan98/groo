import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './Services/Authentication/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private authService:AuthService,private route:Router) {
    
  }
  ngOnInit() {
    if (this.authService.isAuthenticated() == false)
      this.route.navigate(['/login']);
 }
}
