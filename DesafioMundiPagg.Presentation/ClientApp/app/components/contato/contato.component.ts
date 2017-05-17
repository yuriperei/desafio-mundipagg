import { Component, Input } from '@angular/core';

@Component({
    selector: 'contato',
})
export class ContatoComponent {
    contatoId: string;
    @Input() valor: string;
    @Input() tipo: string;
}