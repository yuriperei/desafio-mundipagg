import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DataTableModule } from "angular2-datatable";
import { HttpModule } from "@angular/http";

import { LocalizacaoFiltroPipe } from '../pipes/localizacao-filtro.pipe';

import { LocalizacaoService } from '../services/localizacao.service';

import { LocalizacaoListagemComponent } from '../components/localizacao/localizacao-listagem.component';
import { LocalizacaoFormularioComponent } from '../components/localizacao/localizacao-formulario.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule, ReactiveFormsModule,
        DataTableModule,
        HttpModule,
        RouterModule
    ],
    declarations: [LocalizacaoListagemComponent, LocalizacaoFormularioComponent, LocalizacaoFiltroPipe],
    exports: [LocalizacaoListagemComponent, LocalizacaoFormularioComponent],
    providers: [LocalizacaoService]
})

export class LocalizacaoModule { }