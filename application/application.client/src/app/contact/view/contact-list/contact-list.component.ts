import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Contact } from '../../model/Contact';

@Component({
  selector: 'app-list',
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ListComponent implements OnInit {
  public contacts: Contact[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<Contact[]>('/api/Contacts').subscribe(
      (result) => {
        this.contacts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
