import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
// Classe responsável por gerenciar o componente de navegação
export class NavComponent implements OnInit {
  // Variável responsável por armazenar o estado do Collapse
  isCollapsed = true;

  constructor() { }

  ngOnInit(): void {
  }

}
