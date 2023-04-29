import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

// Anotação para que o serviço possa ser injetado em outros componentes
@Injectable()
// Classe que representa o serviço de eventos
export class EventoService {
  baseUrl = 'https://localhost:5001/api/eventos';

  constructor(private http: HttpClient) { }

  // Método para retornar os eventos
  public getEventos(): any {
    return this.http.get(this.baseUrl);
  }
}
