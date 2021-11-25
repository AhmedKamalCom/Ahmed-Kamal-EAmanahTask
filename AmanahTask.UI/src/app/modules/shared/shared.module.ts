import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmDialogComponent } from './warning/confirm-dialog.component';
import { AngularMaterialModule } from './angular-material.module';

@NgModule({
  declarations: [ConfirmDialogComponent],
  imports: [CommonModule,AngularMaterialModule],
  entryComponents: [ConfirmDialogComponent],
  exports:[ConfirmDialogComponent,AngularMaterialModule]

})
export class SharedModule { }
