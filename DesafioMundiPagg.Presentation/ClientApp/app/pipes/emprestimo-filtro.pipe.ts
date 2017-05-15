import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: "emprestimoFiltro"
})
export class EmprestimoFiltroPipe implements PipeTransform {

    transform(array: any[], query: string): any {
        if (query) {
            return array.filter(array =>
                array.dataEmprestimo.toLowerCase().includes(query.toLowerCase()) ||
                array.dataDevolucao.toLowerCase().includes(query.toLowerCase()) ||
                array.item.titulo.toLowerCase().includes(query.toLowerCase()) ||
                array.item.tipoItem.toLowerCase().includes(query.toLowerCase()) ||
                array.pessoa.nome.toLowerCase().includes(query.toLowerCase())
            );
        }
        return array;
    }

}