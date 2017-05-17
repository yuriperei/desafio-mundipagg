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

    mensagem: string = "";

    constructor(private service: LocalizacaoService, fb: FormBuilder, private route: ActivatedRoute, private router: Router) {
        this.service = service;
        this.route = route;
        this.router = router;

        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.service
                    .buscaPorId(id)
                    .subscribe(localizacao => this.localizacao = localizacao, () => this.mensagem = "Não foi possível obter a localização solicitada.");
            }
        });

        this.meuForm = fb.group({
            nome: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
            endereco: ['', Validators.compose([Validators.required, Validators.minLength(10)])],
            cidade: ['', Validators.compose([Validators.required])],
            estado: ['', Validators.compose([Validators.required])],
            pais: ['', Validators.compose([Validators.required])]
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
            }, () => this.mensagem = "Não foi possível efetuar a ação.");
    }

}