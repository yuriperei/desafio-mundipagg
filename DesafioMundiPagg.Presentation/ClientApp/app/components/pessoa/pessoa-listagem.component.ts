import { Component, OnInit } from "@angular/core";
import { PessoaService } from '../../services/pessoa.service';
import { PessoaComponent } from '../pessoa/pessoa.component';

@Component({
    selector: 'pessoaListagem',
    templateUrl: './pessoa-listagem.component.html'
})

export class PessoaListagemComponent implements OnInit {

    public data: Array<PessoaComponent> = [];
    public filterQuery = "";
    public rowsOnPage = 10;
    public sortBy = "nome";
    public sortOrder = "asc";

    service: PessoaService;
    mensagem: string = "";

    constructor(service: PessoaService) {
        this.service = service;
    }

    ngOnInit() {
        this.service.lista().subscribe(
            pessoas => this.data = pessoas,
            erro => console.log(erro));
    }

    remover(item: PessoaComponent) {
        this.service
            .remove(item)
            .subscribe(
            () => {
                let novos = this.data.slice(0);
                let indice = this.data.indexOf(item);
                novos.splice(indice, 1);
                this.data = novos;
                this.mensagem = "Pessoa removido com sucesso!";
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
