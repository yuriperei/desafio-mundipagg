import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ItemService } from '../../services/item.service';
import { LocalizacaoService } from '../../services/localizacao.service';
import { ItemComponent } from '../item/item.component';
import { LocalizacaoComponent } from '../localizacao/localizacao.component';

@Component({
    selector: 'itemFormulario',
    templateUrl: './item-formulario.component.html'
})

export class ItemFormularioComponent{

    item: ItemComponent = new ItemComponent();
    localizacoes: Array<LocalizacaoComponent> = [];
    meuForm: FormGroup;

    mensagem: string = "";

    constructor(private service: ItemService, private localizacaoService: LocalizacaoService, fb: FormBuilder, private route: ActivatedRoute) {
        this.service = service;
        this.localizacaoService = localizacaoService;
        this.route = route;

        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.service
                    .buscaPorId(id)
                    .subscribe(item => this.item = item, () => this.mensagem = "Não foi possível obter o item solicitado.");
            }
        });

        this.localizacaoService.lista().subscribe(localizacoes => this.localizacoes = localizacoes, () => this.mensagem = "Não foi possível listar as Localizações.");

        this.meuForm = fb.group({
            titulo: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
            tipoItem: ['', Validators.compose([Validators.required])],
            localizacoes: ['', Validators.compose([Validators.required])]
        });
    }

    manter(event) {
        event.preventDefault();

        this.service.manter(this.item)
            .subscribe(res => {
                this.mensagem = res.mensagem;
                
                if (res.inclusao) {
                    this.item = new ItemComponent();
                };
            }, () => this.mensagem = "Não foi possível efetuar a ação.");
    }

}