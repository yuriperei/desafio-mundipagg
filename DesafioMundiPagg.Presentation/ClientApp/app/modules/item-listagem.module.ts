import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from "@angular/forms";
import { DataTableModule } from "angular2-datatable";
import { HttpModule } from "@angular/http";

import { ItemFiltroPipe } from '../pipes/item-filtro.pipe';

import { ItemService } from '../services/item.service';
import { ItemListagemComponent } from '../components/item/item-listagem.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        DataTableModule, 
        HttpModule,
        RouterModule,
    ],
    declarations: [ItemListagemComponent, ItemFiltroPipe],
    exports: [ItemListagemComponent],
    providers: [ItemService]
})

export class ItemListagemModule { }