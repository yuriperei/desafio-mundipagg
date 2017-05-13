import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: "itemFiltro"
})
export class ItemFiltroPipe implements PipeTransform {

    transform(array: any[], query: string): any {
        if (query) {
            return array.filter(array =>
                array.titulo.toLowerCase().includes(query.toLowerCase()) ||
                array.tipoItem.toLowerCase().includes(query.toLowerCase()) ||
                (array.isEmprestado == true && "sim".includes(query.toLowerCase()) ||
                    array.isEmprestado == false &&
                    ("não".includes(query.toLowerCase()) || "não".includes(query.toLowerCase()))
                )
            );
        }
        return array;
    }

}