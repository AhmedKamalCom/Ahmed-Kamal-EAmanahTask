import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IFilterBlog, BlogService } from './services/blog.service';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmDialogModel, ConfirmDialogComponent } from '../shared/warning/confirm-dialog.component';
@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.scss']
})
export class BlogsComponent implements OnInit {
  params: IFilterBlog = { name: '', orderBy: 'CreatedDate', isAscending: false, pageIndex: 1, pageSize: 10 }
  loading: boolean
  Data: any
  displayedColumns: string[] = ['Title', 'control'];
  dataSource = new MatTableDataSource<any>([]);

  constructor(
    public router: Router,
    private BlogService: BlogService,
    private _snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.loading = true;
    this.BlogService.Search(this.params).subscribe(res => {
      if (!res.Success) {
        this._snackBar.open(res.Message, "", { duration: 3000, panelClass: (["snack-error"]) });
        return;
      }
      this.loading = false;
      this.Data = res.Data;
      this.dataSource = new MatTableDataSource(res.Data?.Result);
    })
  }

  pageChanged(event: any): void {
    this.params.pageSize = event.pageSize
    this.params.pageIndex = event.pageIndex + 1;
    this.getData();
  }

  deleteRow(ID): void {
    const dialogData = new ConfirmDialogModel('Delete confirmation', 'Are you sure you want to delete ?');
    const dialogRef = this.dialog.open(ConfirmDialogComponent, { position: { top: '5%' }, maxWidth: "400px", data: dialogData });
    dialogRef.afterClosed().subscribe(ok => {
      if (!ok) return;
      this.BlogService.Delete(ID).subscribe(res => {
        if (!res.Success) {
          this._snackBar.open(res.Message, "", { duration: 3000, panelClass: (["snack-error"]) });
          return;
        }
        this._snackBar.open(res.Message, "", { duration: 3000, panelClass: (["snack-success"]) });
        this.getData()
      })
    });
  }

}
