// Responsável por importar os módulos e componentes
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
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
// Responsável por permitir a utilização de formulários
import { FormsModule } from '@angular/forms';

// Responsável por fazer o menu com efeito de collapse
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

// Componentes criados
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { NavComponent } from './shared/nav/nav.component';
import { EventoService } from './services/evento.service';
import { DateTimeFormatPipe } from './helpers/dateTimeFormat.pipe';
import { TituloComponent } from './shared/titulo/titulo.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';

@NgModule({
  // Responsável por declarar os componentes
  declarations: [
    AppComponent,
    TituloComponent,
    PerfilComponent,
    DashboardComponent,
    EventosComponent,
    PalestrantesComponent,
    ContatosComponent,
    NavComponent,
    DateTimeFormatPipe
  ],
  // Responsável por importar os módulos
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule
  ],
  // Responsável por importar os provedores de serviços
  providers: [
    EventoService
  ],
  // Responsável por fazer o bootstrap da aplicação
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
// Classe responsável por gerenciar o módulo principal da aplicação
export class AppModule { }
