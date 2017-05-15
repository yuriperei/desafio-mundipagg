import { Component, Input } from '@angular/core';
import { ItemComponent } from '../item/item.component';
import { PessoaComponent } from '../pessoa/pessoa.component';


@Component({
    selector: 'emprestimo',
})
export class EmprestimoComponent {
    emprestimoId: string;
    @Input() dataDevolucao: string;
    @Input() dataEmprestimo: string;
    @Input() item: ItemComponent;
    @Input() pessoa: PessoaComponent;
}