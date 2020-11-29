import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

 
  isFocusName: boolean=true
  isFocusPass: boolean = false
  loginForm:FormGroup
  constructor(private fb: FormBuilder,private authService:AuthService,private route:Router) {
    this.loginForm = this.fb.group({
      id: ['',Validators.required],
      password: ['',Validators.required]
    });
  }

  ngOnInit() {
    document.getElementById("onFocus").focus(); 
  }

  Login(data) {   
    this.authService.Login(data).subscribe(data => {
      this.authService.saveToken(data['token']);
      if (this.authService.isAuthenticated() == true) {
        this.route.navigate(['/dashboard']);
      }
    })   
  }

  onKey(event: any) { 
    if (this.isFocusName == true) {
      this.isFocusName = false
    } 
    if (this.isFocusName == false) {
      this.isFocusName = true

    } 
    if (this.isFocusPass == true) { 
      this.isFocusPass = false
    }
    if (this.isFocusPass == false) {
      this.isFocusPass = true
     }
    
  }
  onFocusName() {

    if (this.isFocusName == false) {
      this.isFocusName=true
    } 
  }
  onFocusPass() {

    if (this.isFocusPass == false) {
      this.isFocusPass=true
    }   
  }


}
