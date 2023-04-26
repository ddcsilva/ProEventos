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

// Componentes criados
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';

@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
