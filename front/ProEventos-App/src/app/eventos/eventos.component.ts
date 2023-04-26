import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  public tamanhoImagem: number = 150;
  public margemImagem: number = 2;
  public mostrarImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): any {
    // toLocaleLowerCase() converte a string para minúsculo
    filtrarPor = filtrarPor.toLocaleLowerCase();
    // filter() filtra os elementos de um array
    // indexOf() retorna o índice da primeira ocorrência do valor especificado
    return this.eventos.filter(
      (evento: { tema: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) { }

  // Método executado sempre que o componente é iniciado
  ngOnInit(): void {
    this.getEventos();
  }

  // Método para alternar a visibilidade da imagem
  alternarImagem(): void {
    this.mostrarImagem = !this.mostrarImagem;
  }

  public getEventos(): void {
    // Subscribe é um método que fica escutando o retorno do método get
    this.http.get('https://localhost:5001/api/eventos').subscribe({
      // Se o retorno for bem sucedido, o método next é executado
      next: (response: any) => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      // Se ocorrer algum erro, o método error é executado
      error: (error: any) => {
        console.log(error);
      }
    });
  }
}
