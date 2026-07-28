import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MaterialImports } from '../../material';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { FormComponent } from '../../shared/form/form.component';
import { map } from 'rxjs';
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
  questions: any[] = [];
  topicId: number | null = null;

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.topicId = Number(params['topic']);
      this.refreshQuestions();
    });
  }

  private refreshQuestions() {
    if (this.topicId === null || Number.isNaN(this.topicId)) {
      this.questions = [];
      return;
    }

    this.apiService.getQuestions().pipe(
      map((questions: any[]) => questions.filter(q => Number(q.topic_id) === this.topicId))
    ).subscribe((data: any) => {
      this.questions = data;
    });
  }

  addQuestion() {
    this.dialog.open(FormComponent, {
      width: '70vw',
      data: {
        topic: this.topicId,
        isEdit: false,
      }
    }).afterClosed().subscribe((result: any) => {
      if (result?.success) {
        this.refreshQuestions();
      }
    });
  }

  editQuestion(id: number, question: string, answer?: string) {
    this.dialog.open(FormComponent, {
      width: '70vw',
      data: {
        topicId: this.topicId,
        isEdit: true,
        questions: question,
        answers: answer,
        id: id
      }
    }).afterClosed().subscribe((result: any) => {
      if (result?.success) {
        this.refreshQuestions();
      }
    });
  }

  deleteQuestion(id: number) {
    this.apiService.deleteQuestion(id).subscribe(() => {
      this.refreshQuestions();
    });
  }
}
