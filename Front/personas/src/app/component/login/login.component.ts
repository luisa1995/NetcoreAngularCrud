import { Component, OnInit } from '@angular/core';
import {LoginModel,AuthenticatedResponse} from 'src/app/interface/general'
import {LoginService} from 'src/app/api/services'
import { FormGroup, FormControl,FormBuilder,Validators } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  invalidLogin: boolean = false;


  
  loginForm = this.fb.group({
    usuario: ['',Validators.required],
    password: ['',Validators.required],
    FechaCreacion:[''],
    Identificador:[0]
  });

  constructor(private ser: LoginService,private fb: FormBuilder,private router: Router) {}
 
  ngOnInit(): void {
  }

  login() {
    if (this.loginForm.valid) {
      this.loginForm.value.FechaCreacion = null;
      this.ser.apiLoginLoginPost$Response({body:this.loginForm.value})
      .subscribe(data => {
        localStorage.setItem("jwt", JSON.stringify(data.body)); 
        this.invalidLogin = false; 
        this.router.navigate(["/listPersonas"]);
      },
       error => {       
        this.invalidLogin = true; alert(error.error)});
    }
  }
  }
  

  


