import { Component, Input } from '@angular/core';

@Component({
    selector: 'localizacao',
})
export class LocalizacaoComponent {
    localizacaoId: string;
    @Input() nome: string;
}