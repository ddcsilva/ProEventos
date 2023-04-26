import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];

  constructor(private http: HttpClient) { }

  // Método executado sempre que o componente é iniciado
  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    // Subscribe é um método que fica escutando o retorno do método get
    this.http.get('https://localhost:5001/api/eventos').subscribe({
      // Se o retorno for bem sucedido, o método next é executado
      next: (response: any) => {
        this.eventos = response;
      },
      // Se ocorrer algum erro, o método error é executado
      error: (error: any) => {
        console.log(error);
      }
    });
  }

}
