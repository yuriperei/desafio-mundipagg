import { Component, Input } from '@angular/core';
import { LocalizacaoComponent } from '../localizacao/localizacao.component';
import { ContatoComponent } from '../contato/contato.component';

@Component({
    selector: 'pessoa',
})
export class PessoaComponent {
    pessoaId: string;
    @Input() nome: string;
    @Input() localizacao: LocalizacaoComponent;
    @Input() contato: ContatoComponent;
}