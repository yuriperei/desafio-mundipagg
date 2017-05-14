import { Component, OnInit } from "@angular/core";
import { LocalizacaoService } from '../../services/localizacao.service';
import { LocalizacaoComponent } from '../localizacao/localizacao.component';

@Component({
    selector: 'localizacaoListagem',
    templateUrl: './localizacao-listagem.component.html'
})

export class LocalizacaoListagemComponent implements OnInit{

    public data: Array<LocalizacaoComponent> = [];
    public filterQuery = "";
    public rowsOnPage = 10;
    public sortBy = "nome";
    public sortOrder = "asc";

    service: LocalizacaoService;
    mensagem: string = "";

    constructor(service: LocalizacaoService) {
        this.service = service;
    }

    ngOnInit() {
        this.service.lista().subscribe(
            localizacoes => this.data = localizacoes,
            erro => console.log(erro));
    }

    remover(localizacao: LocalizacaoComponent) {
        this.service
            .remove(localizacao)
            .subscribe(
            () => {
                let novos = this.data.slice(0);
                let indice = this.data.indexOf(localizacao);
                novos.splice(indice, 1);
                this.data = novos;
                this.mensagem = "Localização removida com sucesso!";
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
