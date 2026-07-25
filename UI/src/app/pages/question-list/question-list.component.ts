import { Component, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MaterialImports } from '../../material';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { FormComponent } from '../../shared/form/form.component';

@Component({
  selector: 'app-question-list',
  standalone: true,
  imports: [CommonModule, ...MaterialImports],
  templateUrl: './question-list.component.html',
  styleUrl: './question-list.component.scss'
})
export class QuestionListComponent {

  constructor(private route: ActivatedRoute, private dialog: MatDialog) { }
  questions: any[] = [
    { id: 1, question: 'What is Angular?', answer: 'Angular is a platform and framework for building single-page client applications using HTML, CSS and TypeScript.', topic: 'Angular' },
    { id: 2, question: 'What is JavaScript?', answer: 'JavaScript is a programming language that is commonly used in web development.', topic: 'Angular' },
    { id: 3, question: 'What is Node.js?', answer: 'Node.js is an open-source, cross-platform, back-end JavaScript runtime environment that runs on the V8 engine and executes JavaScript code outside a web browser.', topic: 'Node.js' },
    { id: 4, question: 'What is Dotnet?', answer: '.NET is a free, cross-platform, open source developer platform for building many different types of applications.', topic: 'Dotnet' },
    { id: 5, question: 'What is SQL?', answer: 'SQL is a standard language for storing, manipulating and retrieving data in databases.', topic: 'SQL' }
  ]
  topic: string = '';

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.topic = params['topic'];
      this.questions = this.questions.filter(q => q.topic.toLowerCase() === this.topic.toLowerCase());
    })
  }


  addQuestion(question?: string, answer?: string) {
    this.dialog.open(FormComponent, {
      width: '70vw',
      data: {
        topic: this.topic,
        isEdit: false,
      }
    }).afterClosed().subscribe(result => {
      alert(result);
      if (result) {
        this.questions.push({ id: this.questions.length + 1, question, answer, topic: this.topic });
      }
    })

  }

  editQuestion(id: number, question: string, answer?: string) {
    this.dialog.open(FormComponent, {
      width: '70vw',
      data: {
        topic: this.topic,
        isEdit: true,
        question: question,
        answer: answer
      }
    }).afterClosed().subscribe(result => {
      alert(result);
      if (result) {
        this.questions.push({ id: this.questions.length + 1, question, answer, topic: this.topic });
      }
    })

  }

  deleteQuestion(id: number) {
  }
}
