import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTabsModule,
         MatSidenavModule,
         MatToolbarModule,
         MatButtonModule,
         MatIconModule,
         MatListModule,  
         MatMenuModule,
         MatTableModule} from '@angular/material';


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
    MatTableModule
  ],
  exports:[
    MatTabsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatTableModule
  ]
})
export class MaterialModule { }
