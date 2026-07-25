import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { QuestionListComponent } from './pages/question-list/question-list.component';

export const routes: Routes = [
    { path: '', component: DashboardComponent },
    {path:'questionlist',component:QuestionListComponent},
];
