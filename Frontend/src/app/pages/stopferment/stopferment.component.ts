import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule, DatePipe, formatDate } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatToolbar } from '@angular/material/toolbar';
import { HttpClient } from '@angular/common/http';
import { registerLocaleData } from '@angular/common';
import localePL from '@angular/common/locales/pl';
registerLocaleData(localePL);


@Component({
  selector: 'app-stopferment',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule,CommonModule,FlexLayoutModule,MatToolbar],
  templateUrl: './stopferment.component.html',
  styleUrl: './stopferment.component.css'
})
export class StopfermentComponent {

  public valid:any;
  public time:any;

  constructor(private http:HttpClient, public dialog: MatDialog, private route:Router)
  {
    this.getTime();  
  }

  openDialog() {
    const dialogRef = this.dialog.open(Dialog);

    dialogRef.afterClosed().subscribe(result => {
      if(result)
        {
          this.http.post(`https://localhost:7284/StopFermentation`,'', { observe: 'response' }).subscribe(response => {
            if(response.status == 204)
              {
                
              }
            });
        }        
      });
  }

  getTime()
  {
    this.http.get(`https://localhost:7284/StopFermentation`).subscribe((res:any)=>
      { 
        if(res.activeDate)
          {
            this.time = formatDate(res.activeDate, 'short', 'pl');
            this.valid=true;
          }
          else
          {
            this.valid=false;
          }
      })        
  }

  back()
  {
   this.route.navigate(['/dashboard']);
  }
}
@Component({
  selector: 'dialog',
  templateUrl: 'dialog.html',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
})
export class Dialog {
  constructor(private dialog:MatDialog)
  {

  }
  openDialog() {
    const dialogRef = this.dialog.open(DialogConfirm);

    dialogRef.afterClosed().subscribe(result => {
      window.location.reload()
    });
};
}

@Component({
  selector: 'dialog-confirm',
  templateUrl: 'dialog-confirm.html',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
})
export class DialogConfirm {}

