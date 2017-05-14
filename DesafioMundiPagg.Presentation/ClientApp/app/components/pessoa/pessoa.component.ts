import { Component, Input } from '@angular/core';

@Component({
    selector: 'pessoa',
})
export class PessoaComponent {
    pessoaId: string;
    @Input() nome: string;
}