import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';

import { Owner } from '../../_interface/owner.model';
import { RepositoryService } from './../../shared/repository.service'
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';


@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit, AfterViewInit {

  //order must be same as table
  displayedColumns :string[] = ['name','dateOfBirth','address','details','update','delete'];
  
  //data: Owner[] = [];
  public dataSource = new MatTableDataSource<Owner>();

  @ViewChild(MatSort, {static:false}) sort: MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator: MatPaginator;

  constructor(private repoService: RepositoryService) { }

  ngOnInit() {
    this.getAllOwners();
  }

  ngAfterViewInit(): void{
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  public getAllOwners = () => {
    this.repoService.getData('api/owner')
    .subscribe((res : any) => {
      this.dataSource.data = res as Owner[];
      //console.log(this.dataSource.data);
    })
  }

  public redirectToDetails = (id: string) => {
    
  }
 
  public redirectToUpdate = (id: string) => {
    
  }
 
  public redirectToDelete = (id: string) => {
    
  }

  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

}
