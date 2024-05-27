import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../service/user.service';
import { User } from '../../model/User';
import { Location } from '@angular/common';
import { HttpStatusCode } from '@angular/common/http';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.css'
})
export class UserLoginComponent implements OnInit{
  user!: User
  error: String | undefined

  constructor(
    private service: UserService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.user = { login:"", password:"" }
  }

  async onSubmit(): Promise<void> {
    var get_user = await this.service.getUser(this.user.login).toPromise()
    const msgUint8 = new TextEncoder().encode(this.user.password) // encode as (utf-8) Uint8Array

    var hashBuffer = await window.crypto.subtle.digest("SHA-512", msgUint8) // hash the message
    const hashArray = Array.from(new Uint8Array(hashBuffer)) // convert buffer to byte array
    const hashHex = hashArray
      .map((b) => b.toString(16).padStart(2, "0"))
      .join(""); // convert bytes to hex string

    if (hashHex == get_user!.password && this.user.login == get_user!.login) {
      this.error = "log in"
    }
  }
}
