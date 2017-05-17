import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: "localizacaoFiltro"
})
export class LocalizacaoFiltroPipe implements PipeTransform {

    transform(array: any[], query: string): any {
        if (query) {
            return array.filter(array =>
                array.nome.toLowerCase().includes(query.toLowerCase()) ||
                array.endereco.toLowerCase().includes(query.toLowerCase()) ||
                array.cidade.toLowerCase().includes(query.toLowerCase()) ||
                array.estado.toLowerCase().includes(query.toLowerCase()) ||
                array.pais.toLowerCase().includes(query.toLowerCase()) 
            );
        }
        return array;
    }

}