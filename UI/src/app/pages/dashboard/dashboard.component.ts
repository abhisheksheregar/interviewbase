import { Component } from '@angular/core';
import { MaterialImports } from '../../material';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ApiService } from '../../service/api.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule,...MaterialImports],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
topics:any[]=[];
constructor(private router:Router,private apiService:ApiService) {
}

ngOnInit(): void {
  this.apiService.getTopics().subscribe((data:any)=>{
    this.topics=data;
  });
}

openQuestionList(topic:string){
  this.router.navigate(['/questionlist'],{queryParams:{topic}});
}

}
