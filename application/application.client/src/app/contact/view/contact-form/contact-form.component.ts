import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContactService } from '../../service/contact.service';
import { Contact } from '../../model/Contact';
import { Location } from '@angular/common';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrl: './contact-form.component.css'
})
export class ContactFormComponent implements OnInit{

  contact: Contact | undefined

  constructor(
    private service: ContactService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params["id"]) {
        this.service.getContact(params["id"]).subscribe(contact => {
          this.contact = contact
        })
      } else {
        this.contact = {
          id: 0,
          name: "",
          surname: "",
          email: "",
          password: "",
          category: "",
          subcategory: "",
          phone: "",
          dateOfBirth: new Date()
        }
      }
    })
  }

  onSubmit(): void {
    this.service.putContact(this.contact?.id ?? 0, this.contact!)
      .subscribe(() => this.location.back());
  }
}
