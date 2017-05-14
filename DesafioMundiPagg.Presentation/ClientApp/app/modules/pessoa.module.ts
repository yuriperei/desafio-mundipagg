import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DataTableModule } from "angular2-datatable";
import { HttpModule } from "@angular/http";

import { PessoaFiltroPipe } from '../pipes/pessoa-filtro.pipe';

import { PessoaService } from '../services/pessoa.service';

import { PessoaListagemComponent } from '../components/pessoa/pessoa-listagem.component';
import { PessoaFormularioComponent } from '../components/pessoa/pessoa-formulario.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule, ReactiveFormsModule,
        DataTableModule,
        HttpModule,
        RouterModule
    ],
    declarations: [PessoaListagemComponent, PessoaFormularioComponent, PessoaFiltroPipe],
    exports: [PessoaListagemComponent, PessoaFormularioComponent],
    providers: [PessoaService]
})

export class PessoaModule { }