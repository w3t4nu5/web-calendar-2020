import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from "../../../core/service/authentication.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {

  constructor(
    private _authService: AuthenticationService,
    private _router: Router,
  ) { }

  ngOnInit(): void {
  }

  logout(){
    this._authService.logout();
    this._router.navigate(['/login']);
  }

}
