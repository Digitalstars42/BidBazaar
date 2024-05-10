import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {FormComponent} from './components/form/form.component';
import {BodyComponent} from "./components/body/body.component";
import {ChatComponent} from "./components/chat/chat.component";
import {FavoriteComponent} from "./components/favorite/favorite.component";
import {NotificationComponent} from "./components/notification/notification.component";

const routes: Routes = [
  {path: '',component: BodyComponent},
  {path: 'form',component: FormComponent }, // Маршрут для нової сторінки
  {path: 'chat', component: ChatComponent },
  {path: 'favorite', component: FavoriteComponent},
  {path: 'notification', component: NotificationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
