import { Http, Response, Headers } from '@angular/http';
import { ContatoComponent } from '../components/contato/contato.component';
import { MensagemCadastro } from '../utils/mensagem-cadastro.class';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class ContatoService {

    http: Http;
    headers: Headers;
    url: string = "http://localhost:49807/api/contatos";

    constructor(http: Http) {

        this.http = http;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
    }

    manter(contato: ContatoComponent): Observable<MensagemCadastro> {
        console.log(contato);
        if (contato.contatoId) {
            return this.http.put(this.url + "/" + contato.contatoId, JSON.stringify(contato), { headers: this.headers })
                .map(() => new MensagemCadastro('Contato alterado com sucesso', false));
        } else {
            return this.http
                .post(this.url, JSON.stringify(contato), { headers: this.headers })
                .map(() => new MensagemCadastro('Contato incluído com sucesso', true));
        }
    }

    lista(): Observable<ContatoComponent[]> {
        return this.http
            .get(this.url)
            .map(res => res.json());
    }

    remove(contato: ContatoComponent) {
        return this.http.delete(this.url + '/' + contato.contatoId);
    }

    buscaPorId(id: string): Observable<ContatoComponent> {
        return this.http
            .get(this.url + "/" + id)
            .map(res => res.json());
    }
}