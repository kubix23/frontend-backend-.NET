import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactListComponent } from "./contact/view/contact-list/contact-list.component"
import { ContactDetailsComponent } from './contact/view/contact-details/contact-details.component';

const routes: Routes = [
  { component: ContactListComponent, path: "contact" },
  { component: ContactDetailsComponent, path: "contact/:id/details" },
  { path: "", redirectTo: "contact", pathMatch: 'full' },
  { path: "**", redirectTo: "contact" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
