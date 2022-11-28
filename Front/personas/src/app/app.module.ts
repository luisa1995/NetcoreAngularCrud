import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonasFormComponent } from './component/personas/personas-form.component';
import { ReactiveFormsModule,FormsModule } from '@angular/forms'
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { UsuariosComponent } from './component/usuarios/usuarios.component';
import { LoginComponent } from './component/login/login.component';
import { UsuarioFormComponent } from './component/usuarios/usuario-form/usuario-form.component'; 
import { JwtModule } from '@auth0/angular-jwt'
import { AuthGuard } from 'src/app/services/auth.guard';
import { NavbarComponent } from './component/navbar/navbar.component';

export function tokenGetter() { 
  return localStorage.getItem("jwt"); 
}

@NgModule({
  declarations: [
    AppComponent,
    PersonasFormComponent,
    UsuariosComponent,
    LoginComponent,
    UsuarioFormComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,FormsModule,
    RouterModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: [],
        disallowedRoutes: []
      }
    })
   
  ],
  providers: [AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
