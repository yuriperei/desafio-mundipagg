import { Component, Input } from '@angular/core';

@Component({
    selector: 'item',
})
export class ItemComponent {
    itemId: string;
    @Input() titulo: string;
    @Input() tipoItem: string[] = ["Livro", "Cd", "Dvd"];
    @Input() isEmprestado: boolean;
    @Input() localizacao: string;
    emprestimoId: string;
}