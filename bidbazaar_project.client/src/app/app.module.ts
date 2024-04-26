import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopComponent } from './components/top/top.component';
import { BodyComponent } from './components/body/body.component';
import { MenuLeftComponent } from './components/menu-left/menu-left.component';

@NgModule({
  declarations: [
    AppComponent,
    TopComponent,
    BodyComponent,
    MenuLeftComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

}
