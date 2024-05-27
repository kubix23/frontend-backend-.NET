import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../service/user.service';
import { User } from '../../model/User';
import { Location } from '@angular/common';
import { HttpStatusCode } from '@angular/common/http';


@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrl: './user-register.component.css'
})
export class UserRegisterComponent implements OnInit {
  user!: User
  msg: String | undefined

  constructor(
    private service: UserService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.user = { login: "", password: "" }
  }

  async onSubmit(): Promise<void> {
    let user = { login: this.user.login, password: "" }
    this.user.password = ""
    const msgUint8 = new TextEncoder().encode(user.password) // encode as (utf-8) Uint8Array
    var hashBuffer  = await window.crypto.subtle.digest("SHA-512", msgUint8) // hash the message
    const hashArray = Array.from(new Uint8Array(hashBuffer)) // convert buffer to byte array
    const hashHex = hashArray
      .map((b) => b.toString(16).padStart(2, "0"))
      .join(""); // convert bytes to hex string
    user.password = hashHex
    this.service.patchUser(user.login, user)
      .subscribe(
        () => { this.msg = "Add new user"; setTimeout(() => this.location.back(), 1000) },
        error => error.status == HttpStatusCode.Conflict ? this.msg = "Incorrect login" : this.msg = "Unknown"
      )
  }
}
