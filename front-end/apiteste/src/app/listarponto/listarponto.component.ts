import { AfterViewInit, ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { PontoService } from '../ponto.service';
import { ListarpontoDataSource, ListarpontoItem } from './listarponto-datasource';

@Component({
  selector: 'app-listarponto',
  templateUrl: './listarponto.component.html',
  styleUrls: ['./listarponto.component.css']
})
export class ListarpontoComponent {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<ListarpontoItem>;
  dataSource: ListarpontoDataSource = new ListarpontoDataSource([]);

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['nome', 'dia', 'horasTrabalhadas'];

  constructor(
    private service: PontoService,
    private changeDetectorRefs: ChangeDetectorRef
  ) { 
    this.loadData();
  }

  loadData(): void {
    var itens: ListarpontoItem[] = []
    this.service.listarPontos().subscribe(x => {
      x.forEach(element => {
        let item: ListarpontoItem = {nome:element.nomeColaborador, dia: element.dia, horasTrabalhadas: element.horasTrabalhadas}
        itens.push(item);
      });
      console.log(itens);
      this.dataSource.data = [...itens];
      // this.refresh();
      console.log(this.dataSource);
      this.dataSource.sort;
    });
  }
  ngOnInit(): void {
    var itens: ListarpontoItem[] = []
    this.service.listarPontos().subscribe(x => {
      x.forEach(element => {
        let item: ListarpontoItem = {nome:element.nomeColaborador, dia: element.dia, horasTrabalhadas: element.horasTrabalhadas}
        itens.push(item);
      });
      console.log(itens);
      this.dataSource = new ListarpontoDataSource([...itens]);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.table.dataSource = this.dataSource;
    });
    
  }
}
