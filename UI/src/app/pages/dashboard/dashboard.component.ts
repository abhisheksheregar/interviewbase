import { Component } from '@angular/core';
import { MaterialImports } from '../../material';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule,...MaterialImports],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
topics:string[]=[
    'Angular',
    'Javascript',
    'Node.js',
    'Dotnet',
    'SQL'
]
constructor(private router:Router){

}
openQuestionList(topic:string){
  this.router.navigate(['/questionlist'],{queryParams:{topic:topic}});
}

}
