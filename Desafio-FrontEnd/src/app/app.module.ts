import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


// Components
import { HomePagePage } from './pages/home-page/home-page.page';
import { MarcasPagePage } from './pages/marcas-page/marcas-page.page';
import { ProprietariosPagePage } from './pages/proprietarios-page/proprietarios-page.page';
import { VeiculosPagePage } from './pages/veiculos-page/veiculos-page.page';

// PrimeNg Modules
import { AccordionModule } from 'primeng/accordion';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
@NgModule({
  declarations: [
    AppComponent,
    HomePagePage,
    MarcasPagePage,
    ProprietariosPagePage,
    VeiculosPagePage,
    NavbarComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AccordionModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
