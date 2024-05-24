import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../service/contact.service';
import { ActivatedRoute } from '@angular/router';
import { Contact } from '../../model/Contact';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrl: './contact-details.component.css'
})
export class ContactDetailsComponent implements OnInit {
  contact: Contact | undefined;
  constructor(private route: ActivatedRoute, private service: ContactService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.service.getContact(params["id"]).subscribe(contact => {
        this.contact = contact
      })
    })
  }
}
