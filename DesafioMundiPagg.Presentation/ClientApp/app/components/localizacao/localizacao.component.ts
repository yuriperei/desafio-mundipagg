import { Component, Input } from '@angular/core';

@Component({
    selector: 'localizacao',
})
export class LocalizacaoComponent {
    localizacaoId: string;
    @Input() nome: string;
    @Input() endereco: string;
    @Input() cidade: string;
    @Input() estado: string;
    @Input() pais: string;
}