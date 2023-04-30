import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/usuarios/perfil/perfil.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './components/eventos/evento-lista/evento-lista.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { LoginComponent } from './components/usuarios/login/login.component';
import { RegistroComponent } from './components/usuarios/registro/registro.component';

// Constante que define as rotas da aplicação
const routes: Routes = [
  {
    path: 'usuarios', component: UsuariosComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registro', component: RegistroComponent }
    ]
  },
  {
    path: 'usuarios/perfil', component: PerfilComponent
  },
  {
    path: 'eventos', redirectTo: 'eventos/lista'
  },
  {
    path: 'eventos', component: EventosComponent,
    children: [
      { path: 'detalhe/:id', component: EventoDetalheComponent },
      { path: 'detalhe', component: EventoDetalheComponent },
      { path: 'lista', component: EventoListaComponent }
    ]
  },
  {
    path: 'dashboard', component: DashboardComponent
  },
  {
    path: 'palestrantes', component: PalestrantesComponent
  },
  {
    path: 'contatos', component: ContatosComponent
  },
  {
    path: '', redirectTo: 'dashboard', pathMatch: 'full'
  },
  {
    path: '**', redirectTo: 'dashboard', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
// Classe responsável por gerenciar as rotas da aplicação
export class AppRoutingModule { }
