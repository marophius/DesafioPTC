import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePagePage } from './pages/home-page/home-page.page';
import { MarcasPagePage } from './pages/marcas-page/marcas-page.page';
import { ProprietariosPagePage } from './pages/proprietarios-page/proprietarios-page.page';
import { VeiculosPagePage } from './pages/veiculos-page/veiculos-page.page';

const routes: Routes = [
  {path: '',        component: HomePagePage,   pathMatch: 'full'},
  {path: 'home', component: HomePagePage},
  {path: 'marcas', component: MarcasPagePage},
  {path: 'proprietarios', component: ProprietariosPagePage},
  {path: 'veiculos', component: VeiculosPagePage}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
