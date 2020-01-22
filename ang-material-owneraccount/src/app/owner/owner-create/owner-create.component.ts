import { RepositoryService } from './../../shared/repository.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { OwnerForCreation } from '../../_interface/ownerForCreation.model';

import {MatDialog} from '@angular/material';
import { SuccessDialogComponent } from 'src/app/shared/dialogs/success-dialog/success-dialog.component';
import {ErrorHandlerService} from '../../shared/error-handler.service';

@Component({
  selector: 'app-owner-create',
  templateUrl: './owner-create.component.html',
  styleUrls: ['./owner-create.component.css']
})
export class OwnerCreateComponent implements OnInit {

  public ownerForm: FormGroup;
  private dialogConfig;

  constructor(private errorHandler: ErrorHandlerService, private location: Location, private repository: RepositoryService,private dialog: MatDialog) { }

  ngOnInit() {
    this.ownerForm = new FormGroup({
      name: new FormControl('',[Validators.required, Validators.maxLength(60)]),
      dateOfBirth: new FormControl(new Date()),
      address: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });

    this.dialogConfig = {
      height: '200px',
      width: '400px',
      disableClose: true,
      data:{}
    }
  }

  

  public hasError = (controlName: string, errorName: string) =>{
    return this.ownerForm.controls[controlName].hasError(errorName);
  }

  public onCancel = () =>{
    this.location.back();
  }

  public createOwner = (ownerFormValue) =>{
    if (this.ownerForm.valid){
      this.executeOwnerCreation(ownerFormValue);
    }
  }

  private executeOwnerCreation = (ownerFormValue) =>{
    let owner: OwnerForCreation = {
      name: ownerFormValue.name,
      dateOfBirth: ownerFormValue.dateOfBirth,
      address: ownerFormValue.address
    }

    let apiUrl = 'api/owner';
    this.repository.create(apiUrl, owner)
      .subscribe(res =>{
        let dialogRef = this.dialog.open(SuccessDialogComponent, this.dialogConfig);
        console.log(res);
        dialogRef.afterClosed()
          .subscribe(res => {
            this.location.back();
          })        
      },
      (error) =>{
        this.errorHandler.dialogConfig = { ...this.dialogConfig};
        this.errorHandler.hendleError(error);
      })
  }

}
