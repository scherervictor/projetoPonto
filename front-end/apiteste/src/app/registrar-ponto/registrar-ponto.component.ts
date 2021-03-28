import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms'
import { RegistrarPonto } from '../models/RegistrarPonto';
import { PontoService } from '../ponto.service';

@Component({
  selector: 'app-registrar-ponto',
  templateUrl: './registrar-ponto.component.html',
  styleUrls: ['./registrar-ponto.component.css']
})
export class RegistrarPontoComponent implements OnInit {
  entradaOuSaida = [
    {nome: 'Entrada', valor: 'E'},
    {nome: 'Saida', valor: 'S'}
  ];


  profileForm = new FormGroup({
    idColaborador: new FormControl(''),
    nome: new FormControl(''),
    entradaSaida: new FormControl(this.entradaOuSaida[0]),
  });

  constructor(
    private pontoservice: PontoService
  ) { }

  onSubmit(): void {
    const ponto:RegistrarPonto = {
      idColaborador: this.profileForm.value.idColaborador,
      nomeColaborador: this.profileForm.value.nome,
      entradaSaida: this.profileForm.value.entradaSaida.valor
    };
    
    this.pontoservice.registrarPonto(ponto).subscribe();
  }

  ngOnInit(): void {
  }
}
