export class MensagemCadastro {

    constructor(private _mensagem: string, private _inclusao: boolean, private _id: string) {
        this._mensagem = _mensagem;
        this._inclusao = _inclusao;
        this._id = _id;
    }

    get id(): string {
        return this._id;
    }

    get mensagem(): string {
        return this._mensagem;
    }

    get inclusao(): boolean {
        return this._inclusao;
    }
}