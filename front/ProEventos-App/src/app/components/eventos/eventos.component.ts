// Importações do Angular
import { Component, OnDestroy, OnInit, TemplateRef } from '@angular/core';

// Importações de serviços e modelos
import { EventoService } from '../../services/evento.service';
import { Evento } from '../../models/evento';

// Importações de bibliotecas externas
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subscription } from 'rxjs';
import { FiltroEventosPipe } from 'src/app/helpers/filtro-eventos.pipe';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
// Classe responsável por gerenciar o componente de eventos
export class EventosComponent implements OnInit {
  ngOnInit(): void {
  }
}