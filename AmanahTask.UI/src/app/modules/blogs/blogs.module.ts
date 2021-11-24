import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlogsComponent } from './blogs.component';
import { BlogComponent } from './blog/blog.component';
import { BlogsRoutingModule } from './blogs-routing.module';
import { SharedModule } from '../shared/shared.module';
import { BlogService } from './services/blog.service';



@NgModule({
  declarations: [
     BlogsComponent,
    BlogComponent
  ],
  imports: [
    CommonModule,
    BlogsRoutingModule,
    SharedModule
  ],
  providers:[BlogService]
})
export class BlogsModule { }
