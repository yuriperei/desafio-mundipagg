import { Component, OnInit } from "@angular/core";
import { ItemService } from '../../services/item.service';
import { ItemComponent } from '../item/item.component';

@Component({
    selector: 'itemListagem',
    templateUrl: './item-listagem.component.html'
})

export class ItemListagemComponent implements OnInit{

    public data: Array<ItemComponent> = [];
    public filterQuery = "";
    public rowsOnPage = 10;
    public sortBy = "titulo";
    public sortOrder = "asc";

    service: ItemService;
    mensagem: string = "";

    constructor(service: ItemService) {
        this.service = service;

       
    }

    ngOnInit() {
        this.service.lista().subscribe(
            itens => this.data = itens,
            erro => console.log(erro));
    }

    remover(item: ItemComponent) {
        this.service
            .remove(item)
            .subscribe(
            () => {
                let novos = this.data.slice(0);
                let indice = this.data.indexOf(item);
                novos.splice(indice, 1);
                this.data = novos;
                this.mensagem = "Item removido com sucesso!";
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
