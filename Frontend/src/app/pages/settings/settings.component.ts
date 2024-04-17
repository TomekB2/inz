import { Component } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatToolbar } from '@angular/material/toolbar';
import { MatLabel } from '@angular/material/form-field';
import { MatFormField } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

export class Settings
{
  value1:string;
  value2:string;
  constructor(private ip:string, private time:string)
  {
    this.value1=this.ip;
    this.value2=this.time;
  }
}

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [FlexLayoutModule, MatLabel, MatToolbar, MatFormField,ReactiveFormsModule, MatInputModule, MatButton, CommonModule, FormsModule],
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {

  public settings:Settings;
  public ip:any;
  public time:any

  constructor(private http:HttpClient) {
    this.http.get('https://localhost:7284/Settings').subscribe((res:any)=>
      {
        this.ip = res[0].value;
        this.time = res[1].value;
      });
      this.settings = new Settings(this.ip,this.time);
    }
 onClick()
{
  this.http.post('https://localhost:7284/Settings', this.settings, { observe: 'response' }).subscribe((res:any)=>
    {
        
    })
}
}

