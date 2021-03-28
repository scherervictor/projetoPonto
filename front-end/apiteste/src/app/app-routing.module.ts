import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarpontoComponent } from './listarponto/listarponto.component';
import { RegistrarPontoComponent } from './registrar-ponto/registrar-ponto.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
  { path: 'listarPonto', component: ListarpontoComponent },
  { path: 'registrarPonto', component: RegistrarPontoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
            FormsModule,
            ReactiveFormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
