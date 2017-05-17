import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContatoService } from '../../services/contato.service';
import { ContatoComponent } from '../contato/contato.component';

@Component({
    selector: 'contatoFormulario',
    templateUrl: './contato-formulario.component.html'
})

export class ContatoFormularioComponent{

    contato: ContatoComponent = new ContatoComponent();
    meuForm: FormGroup;
    service: ContatoService;
    route: ActivatedRoute;
    router: Router;
    mensagem: string = "";

    constructor(service: ContatoService, fb: FormBuilder, route: ActivatedRoute, router: Router) {
        this.service = service;
        this.route = route;
        this.router = router;

        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.service
                    .buscaPorId(id)
                    .subscribe(contato => this.contato = contato, () => this.mensagem = "Não foi possível obter o contato solicitado.");
            }
        });

        this.meuForm = fb.group({
            valor: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
            tipo: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
        });
    }

    manter(event) {
        event.preventDefault();
        this.service.manter(this.contato)
            .subscribe(res => {
                this.mensagem = res.mensagem;
                if (res.inclusao) {
                    this.contato = new ContatoComponent();
                };
            }, erro => () => this.mensagem = "Não foi possível efetuar a ação.");
    }

}