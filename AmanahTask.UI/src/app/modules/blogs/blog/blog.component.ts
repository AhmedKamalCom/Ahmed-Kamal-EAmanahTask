import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { BlogService } from '../services/blog.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss'],
})
export class BlogComponent implements OnInit {

  form: FormGroup
  loading: boolean
  URLrouters: any[] = this.router.url.split('/');
  constructor(
    private formBuilder: FormBuilder,
    private blogService: BlogService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private activeRoute: ActivatedRoute,
    public location: Location
  ) { }

  get Id() {
    return this.activeRoute.snapshot.paramMap.get('id');
  }
  ngOnInit() {
    this.initFrom();
    if (+this.Id > 0) this.getDataByID();
  }

  getDataByID() {
    this.loading = true
    this.blogService.GetByID(+this.Id).subscribe(
      res => {
        this.loading = false
        if (res.Success)
          this.form.patchValue(res.Data);
      })
  }

  initFrom() {
    this.form = this.formBuilder.group({
      ID: [0],
      Title: [null, [Validators.required]],
      Body: [null],
    })
  }

  goBack() {
    this.URLrouters.splice(-1, 1)
    this.router.navigateByUrl(this.URLrouters.join('/'));
  }

  save() {
    if (!this.form.valid) {
      for (let control in this.form.controls) {
        this.form.get(control).markAsDirty();
        this.form.get(control).markAsTouched();
      }
      return;
    }
    this.loading = true
    if (this.form.value.ID == 0)
      this.blogService.Post(this.form.value).subscribe(res => this.handleResponse(res));

    else if (this.form.value.ID > 0)
      this.blogService.Put(this.form.value).subscribe(res => this.handleResponse(res));
  }

  private handleResponse(res: any) {
    if (!res.Success) {
      this.loading = false;
      this._snackBar.open(res.Message, "", { duration: 3000, panelClass: (["snack-error"]) });
      return;
    }
    this.loading = false;
    this._snackBar.open(res.Message, "", { duration: 3000, panelClass: (["snack-success"]) });
    this.goBack();
  }
}