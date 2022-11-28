import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'personas';
  active = 'top';
  constructor(private jwtHelper: JwtHelperService) { }

ngOnInit(): void {
}

isUserAuthenticated = (): boolean => {
  const token = localStorage.getItem("jwt");

  if (token && !this.jwtHelper.isTokenExpired(token)){
    return true;
  }

  return false;
}
  
 
  
}
