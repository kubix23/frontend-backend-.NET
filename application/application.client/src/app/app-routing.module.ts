import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactListComponent } from "./contact/view/contact-list/contact-list.component"
import { ContactDetailsComponent } from './contact/view/contact-details/contact-details.component';
import { ContactFormComponent } from './contact/view/contact-form/contact-form.component';
import { UserLoginComponent } from './user/view/user-login/user-login.component';
import { UserRegisterComponent } from './user/view/user-register/user-register.component';

const routes: Routes = [
  { component: ContactListComponent, path: "contact" },
  { component: ContactDetailsComponent, path: "contact/:id/details" },
  { component: ContactFormComponent, path: "contact/new" },
  { component: ContactFormComponent, path: "contact/:id/edit" },
  { component: UserLoginComponent, path: "login" },
  { component: UserRegisterComponent, path: "registration" },
  { path: "", redirectTo: "contact", pathMatch: 'full' },
  { path: "**", redirectTo: "contact" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
