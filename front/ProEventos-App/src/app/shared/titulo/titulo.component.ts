import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() tituloPagina: string | undefined;
  @Input() classeIcone: string | undefined;
  @Input() subtituloPagina: string | undefined;
  @Input() botaoListar: boolean | undefined;

  constructor() { }

  ngOnInit() {
  }

}
