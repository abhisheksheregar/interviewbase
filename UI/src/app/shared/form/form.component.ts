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
      topicId: Number(this.data?.topic) || null
    });

    if(this.data.isEdit){
      this.questionForm.patchValue({
        questions:this.data.questions,
        answers:this.data.answers,
        topicId: Number(this.data?.topicId) || Number(this.data?.topic) || null
      });
    }
  }

  submitForm(){
    if(this.questionForm.valid){
      const formValue = this.questionForm.getRawValue();
      const payload = {
        questions: formValue.questions,
        answers: formValue.answers,
        topicId: Number(formValue.topicId)
      };

      if(!this.data.isEdit){
        this.apiService.postQuestion(payload).subscribe({
          next: () => this.dialogRef.close({ success: true }),
          error: () => this.dialogRef.close({ success: false })
        });
      }
      else{
        let editData = {
          id: this.data.id,
          questions: formValue.questions,
          answers: formValue.answers,
          topicId: Number(formValue.topicId)
        };
        this.apiService.editQuestion(editData).subscribe({
          next: () => this.dialogRef.close({ success: true }),
          error: () => this.dialogRef.close({ success: false })
        });
      }
    }
    else{
      this.dialogRef.close({ success: false });
    }
  }
}
