import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Constante que define as rotas da aplicação
const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
// Classe responsável por gerenciar as rotas da aplicação
export class AppRoutingModule { }
