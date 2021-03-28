import { DataSource } from '@angular/cdk/collections';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';
import { PontoService } from '../ponto.service';
import { PontoColaborador } from '../models/PontoColaborador';

// TODO: Replace this with your own data model type
export interface ListarpontoItem {
  nome: string;
  dia: number;
  horasTrabalhadas: string;
}

// TODO: replace this with real data from your application
const EXAMPLE_DATA: ListarpontoItem[] = [
  {nome: 'Hydrogen', dia:5, horasTrabalhadas: '08:25:00'},
  {nome: 'Xupen', dia:5, horasTrabalhadas: '08:25:00'},
  {nome: 'Vraugen', dia:5, horasTrabalhadas: '08:25:00'},
  {nome: 'ShowMe', dia:5, horasTrabalhadas: '08:25:00'},
];


/**
 * Data source for the Listarponto view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export class ListarpontoDataSource extends DataSource<ListarpontoItem> {
  data: ListarpontoItem[];
  paginator: MatPaginator | undefined;
  sort: MatSort | undefined;
  data2: PontoColaborador[] | undefined;

  constructor(data:ListarpontoItem[]) {    
    super();
    this.data = data;
  }
  
  connect(): Observable<ListarpontoItem[]> {
    if (this.paginator && this.sort) {
      // Combine everything that affects the rendered data into one update
      // stream for the data-table to consume.
      return merge(observableOf(this.data), this.paginator.page, this.sort.sortChange)
        .pipe(map(() => {
          return this.getPagedData(this.getSortedData([...this.data ]));
        }));
    } else {
      throw Error('Please set the paginator and sort on the data source before connecting.');
    }
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect(): void {}

  /**
   * Paginate the data (client-side). If you're using server-side pagination,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getPagedData(data: ListarpontoItem[]): ListarpontoItem[] {
    if (this.paginator) {
      const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
      return data.splice(startIndex, this.paginator.pageSize);
    } else {
      return data;
    }
  }

  /**
   * Sort the data (client-side). If you're using server-side sorting,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getSortedData(data: ListarpontoItem[]): ListarpontoItem[] {
    if (!this.sort || !this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort?.direction === 'asc';
      switch (this.sort?.active) {
        case 'nome': return compare(a.nome, b.nome, isAsc);
        case 'dia': return compare(+a.dia, +b.dia, isAsc);
        case 'horasTrabalhadas': return compare(+a.horasTrabalhadas, +b.horasTrabalhadas, isAsc);
        default: return 0;
      }
    });
  }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a: string | number, b: string | number, isAsc: boolean): number {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
