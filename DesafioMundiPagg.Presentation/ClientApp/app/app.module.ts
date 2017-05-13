import { NgModule } from '@angular/core';
import { UniversalModule } from 'angular2-universal';
import { ItemListagemModule } from './modules/item-listagem.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ItemFormularioComponent } from './components/item/item-formulario.component';

import { AppRoutingModule } from './app.routes';

import 'rxjs/add/operator/map';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ItemFormularioComponent
    ],
    imports: [
        AppRoutingModule,
        ItemListagemModule,
        FormsModule, ReactiveFormsModule,
        UniversalModule // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
    ]
})
export class AppModule {
}
