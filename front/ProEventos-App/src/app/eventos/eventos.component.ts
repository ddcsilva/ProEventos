import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  tamanhoImagem: number = 150;
  margemImagem: number = 2;
  mostrarImagem: boolean = true;
  filtroLista: string = '';

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
        console.log(this.eventos[1].imagemURL)
      },
      // Se ocorrer algum erro, o método error é executado
      error: (error: any) => {
        console.log(error);
      }
    });
  }
}
