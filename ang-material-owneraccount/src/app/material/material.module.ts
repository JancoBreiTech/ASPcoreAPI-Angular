import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTabsModule,
         MatSidenavModule,
         MatToolbarModule,
         MatButtonModule,
         MatIconModule,
         MatListModule,  
         MatMenuModule,
         MatTableModule,
         MatSortModule,
         MatFormFieldModule,
         MatInputModule,
         MatPaginatorModule,
         MatProgressBarModule,
         
         MatProgressSpinnerModule} from '@angular/material';
  import { MatCheckboxModule } from '@angular/material/checkbox';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatTabsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatCheckboxModule,
    MatProgressSpinnerModule
  ],
  exports:[
    MatTabsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatCheckboxModule,
    MatProgressSpinnerModule
  ]
})
export class MaterialModule { }
