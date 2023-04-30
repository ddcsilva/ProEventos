import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() tituloPagina: string = '';
  @Input() classeIcone: string | undefined;
  @Input() subtituloPagina: string | undefined;
  @Input() botaoListar: boolean | undefined;

  constructor(private router: Router) { }

  ngOnInit(): void { }

  listar(): void {
    this.router.navigate([`/${this.tituloPagina.toLocaleLowerCase()}/lista`]);
  }

}
