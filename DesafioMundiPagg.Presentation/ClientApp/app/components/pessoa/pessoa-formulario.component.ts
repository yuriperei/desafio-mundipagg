import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PessoaService } from '../../services/pessoa.service';
import { LocalizacaoService } from '../../services/localizacao.service';
import { ContatoService } from '../../services/contato.service';
import { PessoaComponent } from '../pessoa/pessoa.component';
import { LocalizacaoComponent } from '../localizacao/localizacao.component';
import { ContatoComponent } from '../contato/contato.component';

@Component({
    selector: 'pessoaFormulario',
    templateUrl: './pessoa-formulario.component.html'
})

export class PessoaFormularioComponent {

    pessoa: PessoaComponent = new PessoaComponent();
    localizacoes: Array<LocalizacaoComponent> = [];
    contatos: Array<ContatoComponent> = [];
    meuForm: FormGroup;

    mensagem: string = "";

    constructor(private service: PessoaService, private localizacaoService: LocalizacaoService, private contatoService: ContatoService, fb: FormBuilder, private route: ActivatedRoute, private router: Router) {
        this.service = service;
        this.route = route;
        this.router = router;
        this.localizacaoService = localizacaoService;
        this.contatoService = contatoService;

        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.service
                    .buscaPorId(id)
                    .subscribe(pessoa => this.pessoa = pessoa, () => this.mensagem = "Não foi possível obter a pessoa solicitada.");
            }
        });

        this.localizacaoService.lista().subscribe(localizacoes => this.localizacoes = localizacoes, () => this.mensagem = "Não foi possível listar as Localizações.");
        this.contatoService.lista().subscribe(contatos => this.contatos = contatos, () => this.mensagem = "Não foi possível listar os Contatos.");

        this.meuForm = fb.group({
            nome: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
            localizacoes: ['', Validators.compose([Validators.required])],
            contatos: ['']
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
            }, () => this.mensagem = "Não foi possível efetuar a ação.");
    }

}