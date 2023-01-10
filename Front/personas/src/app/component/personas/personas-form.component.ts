import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

import { PersonasService } from 'src/app/api/services'
import { Personas } from 'src/app/interface/general'

@Component({
  selector: 'app-personas-form',
  templateUrl: './personas-form.component.html',
  styleUrls: ['./personas-form.component.css']
})
export class PersonasFormComponent implements OnInit {

  personaslist: any
  data: any;
  EventValue: any = "save";

  personasForm = this.fb.group({
    TipoIdentificacion: ['', Validators.required],
    NoIdentificacion: ['', Validators.required],
    Nombres: ['', Validators.required],
    Apellidos: ['', Validators.required],
    FechaCreacion: [''],
    Identificador: [0],
    Email: ['']
  });
  constructor(private fb: FormBuilder, private ser: PersonasService) { }

  ngOnInit(): void {
    this.EventValue = "save";
    this.ser.apiPersonasGet$Json$Response().subscribe(data => {
      this.personaslist = data.body;
    },
    error => {
      alert(error.error);        
    });
  }


  save() {
    this.personasForm.value.FechaCreacion = null;
    this.personasForm.value.Identificador = 0;
    this.ser.apiPersonasPost$Response({ body: this.personasForm.value })
      .subscribe(data => {
        this.ngOnInit();
        this.clear();
      },
      error => {
        alert(error.error);        
      });
  }

  update() {
    this.ser.apiPersonasIdPut$Response({body: this.personasForm.value })
      .subscribe(data => {
        this.ngOnInit();
        this.clear();
      },
      error => {
        alert(error.error);        
      });
  }

  EditData(item: any) {
   this.personasForm.controls["Identificador"].setValue(item.identificador);
    this.personasForm.controls["TipoIdentificacion"].setValue(item.tipoIdentificacion);
    this.personasForm.controls["NoIdentificacion"].setValue(item.noIdentificacion);
    this.personasForm.controls["Nombres"].setValue(item.nombres);
    this.personasForm.controls["Apellidos"].setValue(item.apellidos);
    this.personasForm.controls["Email"].setValue(item.email);
    this.personasForm.controls["FechaCreacion"].setValue(item.fechaCreacion);
    this.EventValue = "update";
    
  }

  deleteData(item: any) {
    this.ser.apiPersonasIdDelete$Response({ body: item })
      .subscribe(data => {
        this.ngOnInit();
        this.clear();
      },
      error => {
        alert(error.error);        
      });
  }

  validateEvents(){
    if(this.EventValue === "save"){
      this.save();
    }
    else{
      this.update();
    }
  }
  clear(){
    this.personasForm.reset();
    this.EventValue = "save";
  }
}
