import { Component, Inject } from '@angular/core';
import { FormBuilder, Validators,FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MaterialImports } from '../../material';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ReactiveFormsModule,...MaterialImports],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss'
})
export class FormComponent {

  constructor(private fb:FormBuilder, private dialogRef: MatDialogRef<FormComponent>,@Inject(MAT_DIALOG_DATA) public data: any) { }
  questionForm:FormGroup=this.fb.group({
    question:[null,Validators.required],
    answer:[null,Validators.required],
    topic:[null,Validators.required]
  })
 
  ngOnInit(): void {
    this.questionForm.patchValue({
      topic:this.data.topic
    });

    if(this.data.isEdit){
      this.questionForm.patchValue({
        question:this.data.question,
        answer:this.data.answer,
      });
    }
  }

  submitForm(){
    if(this.questionForm.valid){

      this.dialogRef.close(true);
  }
  else{
    this.dialogRef.close(false);
  }
}
}
