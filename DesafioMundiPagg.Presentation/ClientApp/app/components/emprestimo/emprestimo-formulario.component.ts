import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmprestimoService } from '../../services/emprestimo.service';
import { ItemService } from '../../services/item.service';
import { ItemComponent } from '../item/item.component';
import { PessoaComponent } from '../pessoa/pessoa.component';
import { PessoaService } from '../../services/pessoa.service';
import { EmprestimoComponent } from '../emprestimo/emprestimo.component';
import { IMyOptions, IMyDateModel, IMyInputFieldChanged, IMyCalendarViewChanged, IMyInputFocusBlur, IMyMarkedDate, IMyDate } from 'mydatepicker';

@Component({
    selector: 'emprestimoFormulario',
    templateUrl: './emprestimo-formulario.component.html'
})

export class EmprestimoFormularioComponent {

    meuForm: FormGroup;

    emprestimo: EmprestimoComponent = new EmprestimoComponent();
    itens: Array<ItemComponent> = [];
    pessoas: Array<PessoaComponent> = [];

    private mensagem: string = "";
    private placeholder: string = 'Selecione a data';

    constructor(private service: EmprestimoService,
        private itemService: ItemService,
        private pessoaService: PessoaService,
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router) {

        this.service = service;
        this.route = route;
        this.router = router;
        this.itemService = itemService;
        this.pessoaService = pessoaService;

        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.service
                    .buscaPorId(id)
                    .subscribe(emprestimo => this.emprestimo = emprestimo, erro => console.log(erro));
                this.itemService.lista().subscribe(itens => {
                    this.itens = itens.filter(array => array.isEmprestado == true);
                }, erro => console.log(erro));
            } else {

                this.itemService.lista().subscribe(itens => {
                    this.itens = itens.filter(array => array.isEmprestado == false);
                }, erro => console.log(erro));
            }

            this.pessoaService.lista().subscribe(pessoas => this.pessoas = pessoas, erro => console.log(erro));
        });



        this.meuForm = fb.group({
            myDate: [null, Validators.compose([Validators.required])],
            itens: [''],
            pessoas: ['']
        });
    }

    manter(event) {
        event.preventDefault();
        this.emprestimo.item.isEmprestado = true;

        this.service.manter(this.emprestimo)
            .subscribe(res => {
                this.mensagem = res.mensagem;
                this.emprestimo.item.emprestimoId = res.id;
                
                this.alterarStatusEmprestimo(this.emprestimo.item, true);

                if (res.inclusao) {
                    this.emprestimo = new EmprestimoComponent();
                };


            }, erro => console.log(erro));
    }

    alterarStatusEmprestimo(item: ItemComponent, status: boolean) {
        item.isEmprestado = status;
        if (!status) {
            item.emprestimoId = "";
            //Atualiza o item que está contido em emprestimo (Livro ficando disponível)
            this.emprestimo.item = item;
            this.service.manter(this.emprestimo).subscribe(res => this.mensagem = res.mensagem, erro => console.log(erro));
        }
        //Atualiza o item geral
        this.itemService.alterarStatusEmprestimo(item).subscribe(res => console.log(res), erro => console.log(erro));
    }

    private myDatePickerOptions: IMyOptions = {
        todayBtnTxt: 'Hoje',
        dateFormat: 'dd.mm.yyyy',
        firstDayOfWeek: 'mo',
        sunHighlight: true,
        markCurrentDay: true,
        height: '34px',
        width: '210px',
        alignSelectorRight: false,
        openSelectorTopOfInput: false,
        indicateInvalidDate: true,
        monthSelector: true,
        yearSelector: true,
        minYear: 1900,
        maxYear: 2200,
        componentDisabled: false,
        showClearDateBtn: true,
        showDecreaseDateBtn: false,
        showIncreaseDateBtn: false,
        showSelectorArrow: true,
        showInputField: true,
        openSelectorOnInputClick: true,
        disableHeaderButtons: true,
        showWeekNumbers: false,
        markDates: [],
        satHighlight: false,
        highlightDates: [],
        markWeekends: <IMyMarkedDate>{},
        monthLabels: {
            1: 'Janeiro',
            2: 'Fevereiro',
            3: 'Março',
            4: 'Abril',
            5: 'Maio',
            6: 'Junho',
            7: 'Julho',
            8: 'Agosto',
            9: 'Setembro',
            10: 'Outubro',
            11: 'Novembro',
            12: 'Dezembro'
        }
    };

    onDateEmprestimoChanged(event: IMyDateModel) {
        if (event.formatted !== '') {
            this.emprestimo.dataEmprestimo = event.formatted;
        }
    }

    onDateDevolucaoChanged(event: IMyDateModel) {
        if (event.formatted !== '') {
            this.emprestimo.dataDevolucao = event.formatted;
        }
    }

}