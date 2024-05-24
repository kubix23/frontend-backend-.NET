import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Contact } from '../../model/Contact';
import { ContactService } from '../../service/contact.service';

@Component({
  selector: 'app-list',
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent implements OnInit {
  public contacts: Contact[] = [];

  constructor(private service: ContactService) { }

  ngOnInit() {
    this.service.getContacts().subscribe(
      (result) => {
        this.contacts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onDelete(contact: Contact) {
    this.service.deleteContact(contact.id).subscribe(() => {
      this.contacts.splice(this.contacts.indexOf(contact), 1)
    })
  }
}
