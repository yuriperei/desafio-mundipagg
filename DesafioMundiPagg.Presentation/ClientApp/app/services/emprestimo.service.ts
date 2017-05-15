import { Http, Response, Headers } from '@angular/http';
import { EmprestimoComponent } from '../components/emprestimo/emprestimo.component';
import { ItemComponent } from '../components/item/item.component';
import { MensagemCadastro } from '../utils/mensagem-cadastro.class';
import { Util } from '../utils/util.class';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class EmprestimoService {

    http: Http;
    headers: Headers;
    url: string = "http://localhost:49807/api/emprestimos";

    constructor(http: Http) {

        this.http = http;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
    }

    manter(emprestimo: EmprestimoComponent): Observable<MensagemCadastro> {
        if (emprestimo.emprestimoId) {
            return this.http.put(this.url + "/" + emprestimo.emprestimoId, JSON.stringify(emprestimo), { headers: this.headers })
                .map(() => new MensagemCadastro('Emprestimo alterado com sucesso', false, "")).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
        } else {
            return this.http
                .post(this.url, JSON.stringify(emprestimo), { headers: this.headers })
                .map(resp => new MensagemCadastro('Emprestimo incluído com sucesso', true, new Util().obtemIdDaReposta(resp.text()))).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
        }
    }

    lista(): Observable<EmprestimoComponent[]> {
        return this.http
            .get(this.url)
            .map(res => res.json()).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
    }

    remove(emprestimo: EmprestimoComponent) {
        return this.http.delete(this.url + '/' + emprestimo.emprestimoId).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
    }

    buscaPorId(id: string): Observable<EmprestimoComponent> {
        return this.http
            .get(this.url + "/" + id)
            .map(res => res.json()).catch((error: any) => Observable.throw(error.json().error || 'Erro no servidor'));
    }
}