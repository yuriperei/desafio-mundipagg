import { Http, Response, Headers } from '@angular/http';
import { PessoaComponent } from '../components/pessoa/pessoa.component';
import { MensagemCadastro } from '../utils/mensagem-cadastro.class';
import { Util } from '../utils/util.class';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class PessoaService {

    http: Http;
    headers: Headers;
    url: string = "http://localhost:49807/api/pessoas";

    constructor(http: Http) {

        this.http = http;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
    }

    manter(pessoa: PessoaComponent): Observable<MensagemCadastro> {
        if (pessoa.pessoaId) {
            return this.http.put(this.url + "/" + pessoa.pessoaId, JSON.stringify(pessoa), { headers: this.headers })
                .map(() => new MensagemCadastro('Pessoa alterada com sucesso', false, "")).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
        } else {
            return this.http
                .post(this.url, JSON.stringify(pessoa), { headers: this.headers })
                .map(resp => new MensagemCadastro('Pessoa incluída com sucesso', true, new Util().obtemIdDaReposta(resp.text()))).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
        }
    }

    lista(): Observable<PessoaComponent[]> {
        return this.http
            .get(this.url)
            .map(res => res.json()).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
    }

    remove(pessoa: PessoaComponent) {
        return this.http.delete(this.url + '/' + pessoa.pessoaId).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
    }

    buscaPorId(id: string): Observable<PessoaComponent> {
        return this.http
            .get(this.url + "/" + id)
            .map(res => res.json()).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
    }
}