import { NgModule } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MAT_PAGINATOR_DEFAULT_OPTIONS, MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSortModule } from '@angular/material/sort';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core'; 

@NgModule({
  providers: [
    {
      provide: MAT_PAGINATOR_DEFAULT_OPTIONS,
      useValue: {
        formFieldAppearance: 'fill',
      },
    },
  ],
  exports: [
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatSortModule,
    MatCardModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule
  ]
})
export class SharedMaterialModule { }
