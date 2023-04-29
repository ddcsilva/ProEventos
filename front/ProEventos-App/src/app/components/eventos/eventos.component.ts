import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../../models/evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public modalRef: BsModalRef | undefined;

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public tamanhoImagem: number = 150;
  public margemImagem: number = 2;
  public mostrarImagem: boolean = true;

  private filtroListado: string = '';

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(
      (evento: Evento) => evento.tema.toLocaleLowerCase().includes(filtrarPor)
    );
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  public ngOnInit(): void {
    this.getEventos();
  }

  public alternarImagem(): void {
    this.mostrarImagem = !this.mostrarImagem;
  }

  public getEventos(): void {
    this.spinner.show();
    this.eventoService.getEventos().subscribe({
      next: (response: Evento[]) => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        console.log(error);
        this.spinner.hide();
      },
      complete: () => {
        console.log('Carregamento dos eventos concluído com sucesso.');
        this.spinner.hide();
      }
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O evento foi excluído com sucesso!', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}