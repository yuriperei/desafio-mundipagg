import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DataTableModule } from "angular2-datatable";
import { HttpModule } from "@angular/http";

import { EmprestimoFiltroPipe } from '../pipes/emprestimo-filtro.pipe';

import { EmprestimoService } from '../services/emprestimo.service';

import { EmprestimoListagemComponent } from '../components/emprestimo/emprestimo-listagem.component';
import { EmprestimoFormularioComponent } from '../components/emprestimo/emprestimo-formulario.component';

import { MyDatePickerModule } from 'mydatepicker';

@NgModule({
    imports: [
        CommonModule,
        FormsModule, ReactiveFormsModule,
        DataTableModule, 
        HttpModule,
        RouterModule,
        MyDatePickerModule 
    ],
    declarations: [EmprestimoListagemComponent, EmprestimoFormularioComponent, EmprestimoFiltroPipe],
    exports: [EmprestimoListagemComponent, EmprestimoFormularioComponent ],
    providers: [EmprestimoService]
})

export class EmprestimoModule { }