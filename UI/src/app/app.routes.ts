import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { QuestionListComponent } from './pages/question-list/question-list.component';
import { authGuard } from './auth/auth.guard';

export const routes: Routes = [
    { path: '', component: DashboardComponent,canActivate: [authGuard] },
    { path:'questionlist', component: QuestionListComponent,canActivate: [authGuard] },
];
