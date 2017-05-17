import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DataTableModule } from "angular2-datatable";
import { HttpModule } from "@angular/http";

import { ItemFiltroPipe } from '../pipes/item-filtro.pipe';

import { ItemService } from '../services/item.service';

import { ItemListagemComponent } from '../components/item/item-listagem.component';
import { ItemFormularioComponent } from '../components/item/item-formulario.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule, ReactiveFormsModule,
        DataTableModule, 
        HttpModule,
        RouterModule
    ],
    declarations: [ItemListagemComponent, ItemFormularioComponent, ItemFiltroPipe],
    exports: [ItemListagemComponent, ItemFormularioComponent],
    providers: [ItemService]
})

export class ItemModule { }