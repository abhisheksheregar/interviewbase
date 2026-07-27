import { Component, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MaterialImports } from '../../material';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { FormComponent } from '../../shared/form/form.component';
import { filter, map } from 'rxjs';
import { ApiService } from '../../service/api.service';

@Component({
  selector: 'app-question-list',
  standalone: true,
  imports: [CommonModule, ...MaterialImports],
  templateUrl: './question-list.component.html',
  styleUrl: './question-list.component.scss'
})
export class QuestionListComponent {

  constructor(private route: ActivatedRoute, private dialog: MatDialog, private apiService: ApiService) { }
  questions: any[] = []
  topic: string = '';

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.topic = params['topic'];
      console.log('Selected topic:', this.topic);
      this.apiService.getQuestions().pipe(
        map((questions: any[]) =>
          questions.filter(q => q.topic_id == this.topic)
        )
      )
        .subscribe((data: any) => {
          this.questions = data;
        });
    })
  }


  addQuestion() {
    this.dialog.open(FormComponent, {
      width: '70vw',
      data: {
        topic: this.topic,
        isEdit: false,
      }
    }).afterClosed().subscribe(result => {
      this.apiService.getQuestions().pipe(
        map((questions: any[]) =>
          questions.filter(q => q.topic_id == this.topic)
        )
      )
        .subscribe((data: any) => {
          this.questions = data;
        });
    })

  }

  editQuestion(id: number, question: string, answer?: string) {
    this.dialog.open(FormComponent, {
      width: '70vw',
      data: {
        topicId: this.topic,
        isEdit: true,
        questions: question,
        answers: answer,
        id:id
      }
    }).afterClosed().subscribe(result => {
      alert(result);
      this.apiService.getQuestions().pipe(
        map((questions: any[]) =>
          questions.filter(q => q.topic_id == this.topic)
        )
      )
        .subscribe((data: any) => {
          this.questions = data;
        });
    })

  }

  deleteQuestion(id: number) {
    this.apiService.deleteQuestion(id).subscribe((data: any) => {
      console.log('Question deleted:', data);
      this.apiService.getQuestions().pipe(
        map((questions: any[]) =>
          questions.filter(q => q.topic_id == this.topic)
        )
      )
        .subscribe((data: any) => {
          this.questions = data;
        });
    })
  }
}
