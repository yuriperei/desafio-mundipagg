import { Component, OnInit } from "@angular/core";
import { ContatoService } from '../../services/contato.service';
import { ContatoComponent } from '../contato/contato.component';

@Component({
    selector: 'contatoListagem',
    templateUrl: './contato-listagem.component.html'
})

export class ContatoListagemComponent implements OnInit {

    public data: Array<ContatoComponent> = [];
    public filterQuery = "";
    public rowsOnPage = 10;
    public sortBy = "valor";
    public sortOrder = "asc";

    service: ContatoService;
    mensagem: string = "";

    constructor(service: ContatoService) {
        this.service = service;
    }

    ngOnInit() {
        this.service.lista().subscribe(
            contatos => this.data = contatos,
            erro => () => this.mensagem = "Não foi possível listar os contatos.");
    }

    remover(contato: ContatoComponent) {
        this.service
            .remove(contato)
            .subscribe(
            () => {
                let novos = this.data.slice(0);
                let indice = this.data.indexOf(contato);
                novos.splice(indice, 1);
                this.data = novos;
                this.mensagem = "Contato removido com sucesso!";
            },
            () =>
                this.mensagem = "Não foi possível remover!"
            );
    }

    public toInt(num: string) {
        return +num;
    }

}
