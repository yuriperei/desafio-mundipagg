import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: "pessoaFiltro"
})
export class PessoaFiltroPipe implements PipeTransform {

    transform(array: any[], query: string): any {
        if (query) {
            return array.filter(array =>
                array.nome.toLowerCase().includes(query.toLowerCase())
            );
        }
        return array;
    }

}