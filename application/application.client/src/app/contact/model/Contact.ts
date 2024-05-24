export interface Contact {
  id: number
  name: string
  surname: string
  email: string | null | undefined
  password: string
  category: string
  subcategory: string
  phone: string | null | undefined
}
