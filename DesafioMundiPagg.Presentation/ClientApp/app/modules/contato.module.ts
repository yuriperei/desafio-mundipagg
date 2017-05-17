import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DataTableModule } from "angular2-datatable";
import { HttpModule } from "@angular/http";

import { ContatoFiltroPipe } from '../pipes/contato-filtro.pipe';

import { ContatoService } from '../services/contato.service';

import { ContatoListagemComponent } from '../components/contato/contato-listagem.component';
import { ContatoFormularioComponent } from '../components/contato/contato-formulario.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule, ReactiveFormsModule,
        DataTableModule, 
        HttpModule,
        RouterModule
    ],
    declarations: [ContatoListagemComponent, ContatoFormularioComponent, ContatoFiltroPipe],
    exports: [ContatoListagemComponent, ContatoFormularioComponent],
    providers: [ContatoService]
})

export class ContatoModule { }