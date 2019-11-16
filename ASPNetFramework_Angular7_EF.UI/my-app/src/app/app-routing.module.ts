import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PhotoboothComponent } from './components/photobooth/photobooth.component';


const routes: Routes = [
  { 
    path: 'home', 
    component: PhotoboothComponent,
    pathMatch: 'full'
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  { 
    path: '**', 
    redirectTo: '/',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
