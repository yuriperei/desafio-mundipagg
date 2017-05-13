import { Http, Response, Headers } from '@angular/http';
import { ItemComponent } from '../components/item/item.component';
import { MensagemCadastro } from '../utils/mensagem-cadastro.class';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class ItemService {

    http: Http;
    headers: Headers;
    url: string = "http://localhost:49807/api/itens";

    constructor(http: Http) {

        this.http = http;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
    }

    manter(item: ItemComponent): Observable<MensagemCadastro> {
        if (item.itemId) {
            return this.http.put(this.url + "/" + item.itemId, JSON.stringify(item), { headers: this.headers })
                .map(() => new MensagemCadastro('Item alterado com sucesso', false));
        } else {
            return this.http
                .post(this.url, JSON.stringify(item), { headers: this.headers })
                .map(() => new MensagemCadastro('Item incluído com sucesso', true));
        }
    }

    lista(): Observable<ItemComponent[]> {
        return this.http
            .get(this.url)
            .map(res => res.json());
    }

    remove(item: ItemComponent) {
        return this.http.delete(this.url + '/' + item.itemId);
    }

    buscaPorId(id: string): Observable<ItemComponent> {
        return this.http
            .get(this.url + "/" + id)
            .map(res => res.json());
    }
}