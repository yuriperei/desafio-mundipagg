import { Component, Input } from '@angular/core';
import { ItemComponent } from '../item/item.component';


@Component({
    selector: 'emprestimo',
})
export class EmprestimoComponent {
    emprestimoId: string;
    @Input() dataDevolucao: string;
    @Input() dataEmprestimo: string;
    @Input() item: ItemComponent;
}