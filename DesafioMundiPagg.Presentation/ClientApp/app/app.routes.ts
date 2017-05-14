import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemListagemComponent } from './components/item/item-listagem.component';
import { ItemFormularioComponent } from './components/item/item-formulario.component';
import { PessoaFormularioComponent } from './components/pessoa/pessoa-formulario.component';
import { PessoaListagemComponent } from './components/pessoa/pessoa-listagem.component';

const appRoutes: Routes = [

    { path: '', redirectTo: 'itens', pathMatch: 'full' },

    { path: 'itens', component: ItemListagemComponent },
    { path: 'cadastrar/item', component: ItemFormularioComponent },
    { path: 'alterar/item/:id', component: ItemFormularioComponent },

    { path: 'pessoas', component: PessoaListagemComponent },
    { path: 'cadastrar/pessoa', component: PessoaFormularioComponent },
    { path: 'alterar/pessoa/:id', component: PessoaFormularioComponent },
    
    { path: '**', redirectTo: 'itens' }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}