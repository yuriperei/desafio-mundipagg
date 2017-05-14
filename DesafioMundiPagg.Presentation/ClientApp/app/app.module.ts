import { NgModule } from '@angular/core';
import { UniversalModule } from 'angular2-universal';
import { ItemModule } from './modules/item.module';
import { PessoaModule } from './modules/pessoa.module';
import { LocalizacaoModule } from './modules/localizacao.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';

import { AppRoutingModule } from './app.routes';

import 'rxjs/add/operator/map';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent
    ],
    imports: [
        AppRoutingModule,
        ItemModule,
        PessoaModule,
        LocalizacaoModule,
        FormsModule, ReactiveFormsModule,
        UniversalModule // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
    ]
})
export class AppModule {
}
