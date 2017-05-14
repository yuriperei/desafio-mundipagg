import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LocalizacaoService } from '../../services/localizacao.service';
import { LocalizacaoComponent } from '../localizacao/localizacao.component';

@Component({
    selector: 'localizacaoFormulario',
    templateUrl: './localizacao-formulario.component.html'
})

export class LocalizacaoFormularioComponent{

    localizacao: LocalizacaoComponent = new LocalizacaoComponent();
    meuForm: FormGroup;
    service: LocalizacaoService;
    route: ActivatedRoute;
    router: Router;
    mensagem: string = "";

    constructor(service: LocalizacaoService, fb: FormBuilder, route: ActivatedRoute, router: Router) {
        this.service = service;
        this.route = route;
        this.router = router;

        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.service
                    .buscaPorId(id)
                    .subscribe(localizacao => this.localizacao = localizacao, erro => console.log(erro));
            }
        });

        this.meuForm = fb.group({
            nome: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
        });
    }

    manter(event) {
        event.preventDefault();

        this.service.manter(this.localizacao)
            .subscribe(res => {
                this.mensagem = res.mensagem;
                
                if (res.inclusao) {
                    this.localizacao = new LocalizacaoComponent();
                };
            }, erro => console.log(erro));
    }

}