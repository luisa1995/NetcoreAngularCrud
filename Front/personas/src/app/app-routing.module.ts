import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from '../app/app.component';
import { LoginComponent } from "src/app/component/login/login.component";
import { UsuariosComponent } from "src/app/component/usuarios/usuarios.component";
import { UsuarioFormComponent } from './component/usuarios/usuario-form/usuario-form.component';
import { PersonasFormComponent } from './component/personas/personas-form.component';
import { AuthGuard } from 'src/app/services/auth.guard';
import { NavbarComponent } from './component/navbar/navbar.component';


const routes: Routes = [
  
  { path: "", component: LoginComponent},
  { path: "login", component: LoginComponent },
  { path: "listaUsuarios", component: UsuariosComponent, pathMatch: "full",canActivate: [AuthGuard]},
  { path: "register", component: UsuarioFormComponent, pathMatch: "full" },
  { path: "listPersonas", component: PersonasFormComponent, pathMatch: "full",canActivate: [AuthGuard] },
  { path: "menu", component: NavbarComponent, pathMatch: "full",canActivate: [AuthGuard] }
 
  
 
]

@NgModule({
  imports: [RouterModule.forRoot(routes), ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
