// Importações do Angular
import { Component, OnDestroy, OnInit, TemplateRef } from '@angular/core';

// Importações de serviços e modelos
import { EventoService } from 'src/app/services/evento.service';
import { Evento } from 'src/app/models/evento';

// Importações de bibliotecas externas
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subscription } from 'rxjs';
import { FiltroEventosPipe } from 'src/app/helpers/filtro-eventos.pipe';
import { Router } from '@angular/router';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

  public modalRef: BsModalRef | undefined;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public mostrarImagem: boolean = true;
  public tamanhoImagem: number = 150;
  public margemImagem: number = 2;
  private filtroListado: string = '';
  private subscriptions: Subscription[] = [];
  private eventosFilterPipe = new FiltroEventosPipe();

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastrService: ToastrService,
    private spinnerService: NgxSpinnerService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    this.carregarEventos();
  }

  public ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

  // Métodos públicos

  public alternarImagem(): void {
    this.mostrarImagem = !this.mostrarImagem;
  }

  public abrirModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  public confirmar(): void {
    this.modalRef?.hide();
    this.toastrService.success('O evento foi excluído com sucesso!', 'Deletado!');
  }

  public recusar(): void {
    this.modalRef?.hide();
  }

  public abrirDetalhesEvento(id: number): void {
    this.router.navigate([`/eventos/detalhe/${id}`]);
  }

  // Getters e Setters

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(valor: string) {
    this.filtroListado = valor;
    this.eventosFiltrados = this.eventosFilterPipe.transform(this.eventos, this.filtroListado);
  }

  // Métodos privados

  private carregarEventos(): void {
    this.spinnerService.show();
    const eventosSubscription = this.eventoService.getEventos().subscribe({
      next: (response: Evento[]) => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        console.log(error);
        this.spinnerService.hide();
      },
      complete: () => {
        console.log('Carregamento dos eventos concluído com sucesso.');
        this.spinnerService.hide();
      }
    });
    this.subscriptions.push(eventosSubscription);
  }

  private filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(
      (evento: Evento) => evento.tema.toLocaleLowerCase().includes(filtrarPor)
    );
  }

}
