import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopComponent } from './components/top/top.component';
import { BodyComponent } from './components/body/body.component';
import { MenuLeftComponent } from './components/menu-left/menu-left.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { NewAuctionsComponent } from './components/new-auctions/new-auctions.component';
import { FormComponent } from './components/form/form.component';
import { InformUserComponent } from './components/inform-user/inform-user.component';
import { ChatComponent } from './components/chat/chat.component';
import { NotificationComponent } from './components/notification/notification.component';
import { FavoriteComponent } from './components/favorite/favorite.component';


@NgModule({
  declarations: [
    AppComponent,
    TopComponent,
    BodyComponent,
    MenuLeftComponent,
    CategoriesComponent,
    NewAuctionsComponent,
    FormComponent,
    InformUserComponent,
    ChatComponent,
    NotificationComponent,
    FavoriteComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

}
