import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
 apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getTopics(){
    return this.http.get(`${this.apiUrl}/Topic`);
  }

  postTopic(topic: any){
    return this.http.post(`${this.apiUrl}/Topic`, topic);
  }

  getQuestions(){
    return this.http.get(`${this.apiUrl}/QuestionList`);
  }

  postQuestion(question: any){
    return this.http.post(`${this.apiUrl}/QuestionList`, question);
  }

  editQuestion(question: any){
    return this.http.put(`${this.apiUrl}/QuestionList`, question);
  }

  deleteQuestion(id: number){
    return this.http.delete(`${this.apiUrl}/QuestionList/${id}`);
  }

}
