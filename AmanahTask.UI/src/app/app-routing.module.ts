import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';



export const appRoutes: Routes = [
  
    
      { path: '', redirectTo: '/blogs', pathMatch: 'full' },
      
      {
        path: 'blogs', 
         loadChildren: () => import('./modules/blogs/blogs.module').then(m => m.BlogsModule),
      }
    
  
];
@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
