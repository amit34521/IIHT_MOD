import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  user : User = new User();
  constructor() { }

  ngOnInit() {
  }

}
