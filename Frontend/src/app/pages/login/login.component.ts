import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, Validators, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import {MatToolbarModule} from '@angular/material/toolbar';




@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatToolbarModule, FlexLayoutModule, MatCardModule, FormsModule, HttpClientModule, MatInputModule, MatButtonModule, MatFormFieldModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
 loginObj:Login;
 title='Logowanie';
 error:boolean;
 constructor(private http: HttpClient, private router: Router)
 {
  this.loginObj = new Login();
  this.error = false;
 }
 ngOnInit(): void {
 }
onLogin()
{
  this.http.post('https://localhost:7284/Login', this.loginObj).subscribe((res:any)=>
    {
      if(res.token)
        {
          localStorage.setItem('token', res.token);
          this.router.navigateByUrl('/dashboard');
        }
        else
        {
          this.error=true;
        }
    })
}
}

export class Login
{
  userName:string;
  password:string;
  constructor()
  {
    this.userName = '';
    this.password = '';
  }
}
