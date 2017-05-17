export class Util {

    obtemIdDaReposta(body) {
        let re = /\"/gi;
        var resposta = body.replace(re, "");
        resposta = resposta.split(":");
        resposta = resposta[1].split(",");
        return resposta[0];
    }

}