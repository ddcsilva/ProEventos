import { Pipe, PipeTransform } from '@angular/core';
import { Evento } from '../models/evento';

@Pipe({
  name: 'filtroEventos'
})
export class FiltroEventosPipe implements PipeTransform {
  transform(eventos: Evento[], filtro: string): Evento[] {
    if (!filtro) {
      return eventos;
    }
    
    const filtroLowerCase = filtro.toLocaleLowerCase();
    return eventos.filter(evento => evento.tema.toLocaleLowerCase().includes(filtroLowerCase));
  }
}
