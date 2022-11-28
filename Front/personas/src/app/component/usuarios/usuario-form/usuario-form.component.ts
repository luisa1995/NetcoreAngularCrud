import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl,FormBuilder,Validators } from '@angular/forms';
import { Router } from '@angular/router';

import {UsuariosService} from 'src/app/api/services'
import {Usuarios} from 'src/app/interface/general'

@Component({
  selector: 'app-usuario-form',
  templateUrl: './usuario-form.component.html',
  styleUrls: ['./usuario-form.component.css']
})
export class UsuarioFormComponent implements OnInit {


  usuariosForm = this.fb.group({
    usuario: ['',Validators.required],
    password: ['',Validators.required],   
    FechaCreacion:[''],
    Identificador:[0]
  });

  constructor(private fb: FormBuilder,private ser: UsuariosService,public router: Router) { }

  ngOnInit(): void {
  }

  save(){
    this.usuariosForm.value.FechaCreacion = null;
    this.ser.apiUsuariosPost$Response ({body:this.usuariosForm.value})
      .subscribe(data => {
        alert("Guardado Exitosamente");
        this.router.navigateByUrl('/listaUsuarios');
      },
       error => console.log(error));
  }
}
