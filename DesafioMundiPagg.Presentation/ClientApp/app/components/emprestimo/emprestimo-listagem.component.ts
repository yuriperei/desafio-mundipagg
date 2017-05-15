import { Component, OnInit } from "@angular/core";
import { EmprestimoService } from '../../services/emprestimo.service';
import { EmprestimoComponent } from '../emprestimo/emprestimo.component';

@Component({
    selector: 'emprestimoListagem',
    templateUrl: './emprestimo-listagem.component.html'
})

export class EmprestimoListagemComponent implements OnInit {

    public data: Array<EmprestimoComponent> = [];
    public filterQuery = "";
    public rowsOnPage = 10;
    public sortBy = "item.titulo";
    public sortOrder = "asc";

    service: EmprestimoService;
    mensagem: string = "";

    constructor(service: EmprestimoService) {
        this.service = service;
    }

    ngOnInit() {
        this.service.lista().subscribe(
            emprestimos => this.data = emprestimos,
            erro => console.log(erro));
    }

    remover(emprestimo: EmprestimoComponent) {
        this.service
            .remove(emprestimo)
            .subscribe(
            () => {
                let novos = this.data.slice(0);
                let indice = this.data.indexOf(emprestimo);
                novos.splice(indice, 1);
                this.data = novos;
                this.mensagem = "Emprestimo removido com sucesso!";
            },
            erro => {
                console.log(erro);
                this.mensagem = "Não foi possível remover!";
            });
    }

    public toInt(num: string) {
        return +num;
    }

}
