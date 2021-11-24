import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlogsComponent } from './blogs.component';
import { BlogComponent } from './blog/blog.component';



const routes: Routes = [
  {path: '', component: BlogsComponent} ,
  { path: ':id', component: BlogComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})  
export class BlogsRoutingModule { }
