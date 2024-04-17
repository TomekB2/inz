import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCard } from '@angular/material/card';
import { MatLabel } from '@angular/material/form-field';
import { MatToolbar } from '@angular/material/toolbar';

interface List {
  id: number;
  name: string;
  value:string;
}

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [MatCard, MatLabel,MatToolbar,CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})

export class DashboardComponent {

  private ip:any;
  public message:any;

  constructor(private http: HttpClient) {
    this.getRaspStatus();
  }

  getRaspStatus()
  {
    this.http.get(`https://localhost:7284/Settings`).subscribe((res:any)=>
      { 
        this.http.get(`http://${res[0].value}/api/HealthCheck`, { observe: 'response' }).subscribe(response => {
      if(response.status == 204)
        {
          this.message = true;
        }
      })  
  });
  }
}

