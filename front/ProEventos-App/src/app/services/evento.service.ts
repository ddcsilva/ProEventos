import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Evento } from '../models/evento';
import { AppConfig } from '../config/app-config';

@Injectable()
export class EventoService {
  baseUrl = `${AppConfig.apiUrl}eventos`;

  constructor(private http: HttpClient) { }

  getEventos(): Observable<Evento[]> {
    return this.http.get<any>(this.baseUrl).pipe(
      map((response) => response.data)
    );
  }  

  public getEventosPorTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseUrl}/tema/${tema}`);
  }

  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseUrl}/${id}`);
  }
}
