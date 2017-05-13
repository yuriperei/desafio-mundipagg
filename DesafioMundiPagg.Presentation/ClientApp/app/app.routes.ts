import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ItemFormularioComponent } from './components/item/item-formulario.component';

const appRoutes: Routes = [

    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'cadastrar/item', component: ItemFormularioComponent },
    { path: 'alterar/item/:id', component: ItemFormularioComponent },
    { path: '**', redirectTo: 'home' }

];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}