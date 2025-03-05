import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { MainScheduleComponent } from './main-schedule/main-schedule.component';
import { ScheduleCreateEditComponent } from './schedule-create-edit/schedule-create-edit.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'login', component: LoginComponent},
    { path: 'profile', component: ProfileComponent},
    { path: 'schedule', component: MainScheduleComponent},
    { path: 'schedule-create-edit', component: ScheduleCreateEditComponent}
];

export const routing = RouterModule.forRoot(routes);
