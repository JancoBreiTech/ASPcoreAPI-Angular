import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTabsModule,
         MatSidenavModule,
         MatToolbarModule,
         MatButtonModule,
         MatIconModule,
         MatListModule,  
         MatMenuModule} from '@angular/material';



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
    MatMenuModule
  ],
  exports:[
    MatTabsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatMenuModule
  ]
})
export class MaterialModule { }
