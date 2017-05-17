import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: "contatoFiltro"
})
export class ContatoFiltroPipe implements PipeTransform {

    transform(array: any[], query: string): any {
        if (query) {
            return array.filter(array =>
                array.valor.toLowerCase().includes(query.toLowerCase()) ||
                array.tipo.toLowerCase().includes(query.toLowerCase())
            );
        }
        return array;
    }

}