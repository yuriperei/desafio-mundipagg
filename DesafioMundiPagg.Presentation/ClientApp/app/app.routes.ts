import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemListagemComponent } from './components/item/item-listagem.component';
import { ItemFormularioComponent } from './components/item/item-formulario.component';

const appRoutes: Routes = [

    { path: '', redirectTo: 'itens', pathMatch: 'full' },
    { path: 'itens', component: ItemListagemComponent },
    { path: 'cadastrar/item', component: ItemFormularioComponent },
    { path: 'alterar/item/:id', component: ItemFormularioComponent },
    { path: '**', redirectTo: 'itens' }

];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}