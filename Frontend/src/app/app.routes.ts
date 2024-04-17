import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { MainNavComponent } from './pages/main-nav/main-nav.component';
import { ChartComponent } from './pages/chart/chart.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { SettingsComponent } from './pages/settings/settings.component';
import { StopfermentComponent } from './pages/stopferment/stopferment.component';
import { ListComponent } from './pages/list/list.component';

export const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch:'full' },
    { path: 'login', component: LoginComponent },
    { path: '', component: MainNavComponent, children:[
        { path: 'dashboard', component: DashboardComponent },
        { path: 'settings', component: SettingsComponent },
        { path: 'stopferment', component: StopfermentComponent },
        { path: 'list', component: ListComponent },
        {path: 'chart/:id', component: ChartComponent}
    ] },
    ];
