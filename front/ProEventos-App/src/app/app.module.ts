// Responsável por importar os módulos e componentes
import { NgModule } from '@angular/core';
// Responsável por registrar os provedores de serviços
import { BrowserModule } from '@angular/platform-browser';
// Responsável por fazer as requisições HTTP
import { HttpClientModule } from '@angular/common/http';
// Responsável por fazer o roteamento da aplicação
import { AppRoutingModule } from './app-routing.module';
// Responsável por fazer o bootstrap da aplicação
import { AppComponent } from './app.component';
// Responsável por fazer as animações
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// Responsável por fazer o menu com efeito de collapse
import { CollapseModule } from 'ngx-bootstrap/collapse';
// Responsável por permitir a utilização de formulários
import { FormsModule } from '@angular/forms';

// Componentes criados
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { NavComponent } from './nav/nav.component';

@NgModule({
  // Responsável por declarar os componentes
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
    NavComponent
  ],
  // Responsável por importar os módulos
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule
  ],
  // Responsável por importar os provedores de serviços
  providers: [],
  // Responsável por fazer o bootstrap da aplicação
  bootstrap: [AppComponent]
})
// Classe responsável por gerenciar o módulo principal da aplicação
export class AppModule { }
