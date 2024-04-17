import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatFormField } from '@angular/material/form-field';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import { FlexLayoutModule } from '@angular/flex-layout';
import { Input } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';


interface List {
  id: number;
  name: string;
}

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    RouterOutlet, MatFormField, MatSelectModule,FlexLayoutModule],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})

export class ListComponent {
  
  list: List[] = [];
  listId:number = 0;
  

  constructor(private http: HttpClient, private router:Router)
  {
    this.http.get('https://localhost:7284/Measure').subscribe((res:any)=>
      {
       res.forEach(element => {
        this.list.push(element);
       });
      })
  }

  change(id:number)
  {
    this.router.navigate(["/chart",id]);
  }
  

}
