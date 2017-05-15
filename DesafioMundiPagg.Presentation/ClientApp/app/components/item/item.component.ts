import { Component, Input } from '@angular/core';
import { LocalizacaoComponent } from '../localizacao/localizacao.component';

@Component({
    selector: 'item',
})
export class ItemComponent {
    itemId: string;
    @Input() titulo: string;
    @Input() tipoItem: string[] = ["Livro", "Cd", "Dvd"];
    @Input() isEmprestado: boolean;
    @Input() localizacao: LocalizacaoComponent;
    emprestimoId: string;
    pessoaLocalizacao: LocalizacaoComponent;
}