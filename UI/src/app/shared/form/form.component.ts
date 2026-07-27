import { Component, Inject } from '@angular/core';
import { FormBuilder, Validators,FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MaterialImports } from '../../material';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ApiService } from '../../service/api.service';
@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ReactiveFormsModule,...MaterialImports],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss'
})
export class FormComponent {

  constructor(private fb:FormBuilder, private apiService: ApiService, private dialogRef: MatDialogRef<FormComponent>,@Inject(MAT_DIALOG_DATA) public data: any) { }
  questionForm:FormGroup=this.fb.group({
    questions:[null,Validators.required],
    answers:[null,Validators.required],
    topicId:[null,Validators.required]
  })
 
  ngOnInit(): void {
    this.questionForm.patchValue({
      topicId:this.data.topic
    });

    if(this.data.isEdit){
      this.questionForm.patchValue({
        questions:this.data.questions,
        answers:this.data.answers,
        topicId:this.data.topicId
      });
    }
  }

  submitForm(){
    if(this.questionForm.valid){
      if(!this.data.isEdit){
        this.apiService.postQuestion(this.questionForm.getRawValue()).subscribe((data:any)=>{
          console.log('Question added:', data);
        })
      }
      else{
        let editData = {
          id: this.data.id,
          questions: this.questionForm.get('questions')?.value,  
          answers: this.questionForm.get('answers')?.value,
          topicId: this.questionForm.get('topicId')?.value
        };
        this.apiService.editQuestion(editData).subscribe((data:any)=>{
          console.log('Question updated:', data);
        });
      }

      this.dialogRef.close(true);
  }
  else{
    this.dialogRef.close(false);
  }
}
}
