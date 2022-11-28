import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl,FormBuilder,Validators } from '@angular/forms';

import { Router } from '@angular/router';
import {UsuariosService} from 'src/app/api/services'
import {Usuarios} from 'src/app/interface/general'


@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {
  usuarioslist:any

  usuarioForm = this.fb.group({
    Usuario: ['',Validators.required],
    Password: ['',Validators.required]
    
  });
  constructor(private fb: FormBuilder,private ser: UsuariosService,public router: Router) { }

  ngOnInit(): void {
    this.ser.apiUsuariosGet$Json$Response().subscribe(data => {
      this.usuarioslist = data.body;
    },
      error => console.log(error));
  }

}
