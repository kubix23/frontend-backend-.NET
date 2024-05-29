import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContactService } from '../../service/contact.service';
import { Contact } from '../../model/Contact';
import { Location } from '@angular/common';
import { CategoryService } from '../../service/category.service';
import { Category } from '../../model/Category';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrl: './contact-form.component.css'
})
export class ContactFormComponent implements OnInit{

  contact: Contact
  categories: Category[]
  subcategories: Category[] | undefined
  subcategory: Category
  type: number | undefined

  constructor(
    private service: ContactService,
    private serviceCategory: CategoryService,
    private route: ActivatedRoute,
    private location: Location
  ) {
    this.contact = {
      id: 0,
      name: "",
      surname: "",
      email: "",
      password: "",
      category: 0,
      subcategory: 0,
      phone: "",
      dateOfBirth: new Date()
    }
    this.categories = []
    this.subcategory = { id: 0, name: "", parentCategoryId: 0 }
  }

  ngOnInit(): void {
    this.serviceCategory.getCategories().subscribe(category => this.categories = category)
    this.route.params.subscribe(params => {
      if (params["id"]) {
        this.service.getContact(params["id"]).subscribe(contact => this.contact = contact)
      }
    })
  }

  onSubmit(): void {
    var test = 0
    if (this.type === 3) {
      this.serviceCategory.putCategory(this.subcategory.id,
        {
          id: this.subcategory.id,
          name: this.subcategory?.name!,
          parentCategoryId: this.contact.category
        }).subscribe(ctx => {
          this.contact.subcategory = ctx.id
          this.service.putContact(this.contact?.id, this.contact!)
            .subscribe(() => this.location.go("/"))
        })
    } else {
      this.contact.subcategory = this.subcategory.id
      this.service.putContact(this.contact?.id, this.contact!)
        .subscribe(() => this.location.go("/"))
    }
  }

  onChangeCategory(event: Event): void {
    const target = event.target as HTMLSelectElement
    this.type = Number(target.value)
    if (!this.subcategories) {
      this.serviceCategory.getSubcategories(this.type).subscribe(ctx => this.subcategories = ctx)
    }
    this.subcategory = { id: 0, name: "", parentCategoryId: 0}
  }
}
