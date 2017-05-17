import { Http, Response, Headers } from '@angular/http';
import { LocalizacaoComponent } from '../components/localizacao/localizacao.component';
import { MensagemCadastro } from '../utils/mensagem-cadastro.class';
import { Util } from '../utils/util.class';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class LocalizacaoService {

    http: Http;
    headers: Headers;
    url: string = "http://localhost:49807/api/localizacoes";

    constructor(http: Http) {

        this.http = http;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
    }

    manter(localizacao: LocalizacaoComponent): Observable<MensagemCadastro> {
        if (localizacao.localizacaoId) {
            return this.http.put(this.url + "/" + localizacao.localizacaoId, JSON.stringify(localizacao), { headers: this.headers })
                .map(() => new MensagemCadastro('Localização alterada com sucesso', false, "")).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
        } else {
            return this.http
                .post(this.url, JSON.stringify(localizacao), { headers: this.headers })
                .map(resp => new MensagemCadastro('Localização incluída com sucesso', true, new Util().obtemIdDaReposta(resp.text()))).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
        }
    }

    lista(): Observable<LocalizacaoComponent[]> {
        return this.http
            .get(this.url)
            .map(res => res.json()).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
    }

    remove(localizacao: LocalizacaoComponent) {
        return this.http.delete(this.url + '/' + localizacao.localizacaoId).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
    }

    buscaPorId(id: string): Observable<LocalizacaoComponent> {
        return this.http
            .get(this.url + "/" + id)
            .map(res => res.json()).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
    }
}