import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PessoaService } from '../../services/pessoa.service';
import { PessoaComponent } from '../pessoa/pessoa.component';

@Component({
    selector: 'pessoaFormulario',
    templateUrl: './pessoa-formulario.component.html'
})

export class PessoaFormularioComponent {

    pessoa: PessoaComponent = new PessoaComponent();
    meuForm: FormGroup;
    service: PessoaService;
    route: ActivatedRoute;
    router: Router;
    mensagem: string = "";

    constructor(service: PessoaService, fb: FormBuilder, route: ActivatedRoute, router: Router) {
        this.service = service;
        this.route = route;
        this.router = router;

        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.service
                    .buscaPorId(id)
                    .subscribe(pessoa => this.pessoa = pessoa, erro => console.log(erro));
            }
        });

        this.meuForm = fb.group({
            nome: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
        });
    }

    manter(event) {
        event.preventDefault();

        this.service.manter(this.pessoa)
            .subscribe(res => {
                this.mensagem = res.mensagem;

                if (res.inclusao) {
                    this.pessoa = new PessoaComponent();
                };
            }, erro => console.log(erro));
    }

}