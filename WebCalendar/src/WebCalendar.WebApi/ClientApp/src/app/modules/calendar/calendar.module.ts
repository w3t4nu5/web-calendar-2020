import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CalendarRoutingModule} from "./calendar-routing.module";
import {CalendarComponent} from "./pages/calendar/calendar.component";
import {FullCalendarModule} from "@fullcalendar/angular";
import {NotificationComponent} from "./components/notification/notification.component";
import { MainComponent } from './pages/main/main.component';
import { SettingsComponent } from './pages/settings/settings.component';



@NgModule({
    declarations: [
        CalendarComponent,
        NotificationComponent,
        MainComponent,
        SettingsComponent
    ],
  imports: [
    CommonModule,
    CalendarRoutingModule,
    FullCalendarModule
  ]
})
export class CalendarModule { }
