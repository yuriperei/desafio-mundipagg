import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemService } from '../../services/item.service';
import { ItemComponent } from '../item/item.component';

@Component({
    selector: 'itemFormulario',
    templateUrl: './item-formulario.component.html'
})

export class ItemFormularioComponent{

    item: ItemComponent = new ItemComponent();
    meuForm: FormGroup;
    service: ItemService;
    route: ActivatedRoute;
    router: Router;
    mensagem: string = "";

    constructor(service: ItemService, fb: FormBuilder, route: ActivatedRoute, router: Router) {
        this.service = service;
        this.route = route;
        this.router = router;

        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.service
                    .buscaPorId(id)
                    .subscribe(item => this.item = item, erro => console.log(erro));
            }
        });

        this.meuForm = fb.group({
            titulo: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
            tipoItem: [''],
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
            }, erro => console.log(erro));
    }

}