import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// Components
import { HomePagePage } from './pages/home-page/home-page.page';
import { MarcasPagePage } from './pages/marcas-page/marcas-page.page';
import { ProprietariosPagePage } from './pages/proprietarios-page/proprietarios-page.page';
import { VeiculosPagePage } from './pages/veiculos-page/veiculos-page.page';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { MarcaFormComponent } from './components/marca-form/marca-form.component';
// Mdbootstrap
import { MdbCollapseModule } from 'mdb-angular-ui-kit/collapse';
import { MdbModalModule } from 'mdb-angular-ui-kit/modal';
import { MdbFormsModule } from 'mdb-angular-ui-kit/forms'
// PrimeNg Modules
import { AccordionModule } from 'primeng/accordion';
import { TableModule } from 'primeng/table';
import { InputSwitchModule } from 'primeng/inputswitch';
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';
import { InputTextModule } from 'primeng/inputtext';
import { CascadeSelectModule } from 'primeng/cascadeselect';
import { ProprietarioFormComponent } from './components/proprietario-form/proprietario-form.component';
import { NgBrazil } from 'ng-brazil';
import { TextMaskModule } from 'angular2-text-mask';



@NgModule({
  declarations: [
    AppComponent,
    HomePagePage,
    MarcasPagePage,
    ProprietariosPagePage,
    VeiculosPagePage,
    NavbarComponent,
    FooterComponent,
    MarcaFormComponent,
    ProprietarioFormComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AccordionModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MdbCollapseModule,
    TableModule,
    InputSwitchModule,
    ButtonModule,
    TooltipModule,
    MdbModalModule,
    MdbFormsModule,
    InputTextModule,
    CascadeSelectModule,
    NgBrazil,
    TextMaskModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
