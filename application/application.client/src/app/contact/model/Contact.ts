import { Data } from "@angular/router"

export interface Contact {
  id: number
  name: string
  surname: string
  email: string | null | undefined
  password: string
  category: number
  subcategory: number
  phone: string | null | undefined
  dateOfBirth: Data
}
