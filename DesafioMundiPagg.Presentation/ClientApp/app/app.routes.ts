import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemListagemComponent } from './components/item/item-listagem.component';
import { ItemFormularioComponent } from './components/item/item-formulario.component';
import { PessoaFormularioComponent } from './components/pessoa/pessoa-formulario.component';
import { PessoaListagemComponent } from './components/pessoa/pessoa-listagem.component';
import { LocalizacaoListagemComponent } from './components/localizacao/localizacao-listagem.component';
import { LocalizacaoFormularioComponent } from './components/localizacao/localizacao-formulario.component';
import { ContatoFormularioComponent } from './components/contato/contato-formulario.component';
import { ContatoListagemComponent } from './components/contato/contato-listagem.component';
import { EmprestimoFormularioComponent } from './components/emprestimo/emprestimo-formulario.component';
import { EmprestimoListagemComponent } from './components/emprestimo/emprestimo-listagem.component';

const appRoutes: Routes = [

    { path: '', redirectTo: 'itens', pathMatch: 'full' },

    { path: 'itens', component: ItemListagemComponent },
    { path: 'cadastrar/item', component: ItemFormularioComponent },
    { path: 'alterar/item/:id', component: ItemFormularioComponent },

    { path: 'pessoas', component: PessoaListagemComponent },
    { path: 'cadastrar/pessoa', component: PessoaFormularioComponent },
    { path: 'alterar/pessoa/:id', component: PessoaFormularioComponent },

    { path: 'localizacoes', component: LocalizacaoListagemComponent },
    { path: 'cadastrar/localizacao', component: LocalizacaoFormularioComponent },
    { path: 'alterar/localizacao/:id', component: LocalizacaoFormularioComponent },

    { path: 'contatos', component: ContatoListagemComponent },
    { path: 'cadastrar/contato', component: ContatoFormularioComponent },
    { path: 'alterar/contato/:id', component: ContatoFormularioComponent },

    { path: 'emprestimos', component: EmprestimoListagemComponent },
    { path: 'cadastrar/emprestimo', component: EmprestimoFormularioComponent },
    { path: 'alterar/emprestimo/:id', component: EmprestimoFormularioComponent },

    { path: '**', redirectTo: 'itens' }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }