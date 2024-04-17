import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';
import { Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatButton } from '@angular/material/button';


@Component({
  selector: 'app-chart',
  standalone: true,
  imports: [CanvasJSAngularChartsModule, MatButton],
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.css'
})
export class ChartComponent implements OnInit
{
  @Input() 
  private labels:string[] =[];
  private id2:any = this.router.snapshot.params['id'];
  private datasetInside:any=[];
  private datasetOutside:any=[];
  public chartOptions: any;
  constructor(private http: HttpClient, private router:ActivatedRoute, private route:Router)
 {
  this.getResponse();
  this.getChart();
 }

 ngOnInit(): void { 
  this.getChart();
 }

 getResponse()
 {
  this.http.get(`https://localhost:7284/Temperature?id=${parseInt(this.id2)}`).subscribe((res:any)=>
    { 
      res.forEach(element => {
        this.labels.push(new Date(element.date).toLocaleString());
        this.datasetInside.push({x: new Date(element.date), y:element.insideTemperature})
        this.datasetOutside.push({x: new Date(element.date), y:element.outsideTemperature}) 
    })
    })    
 }
 back()
 {
  this.route.navigate(['/list']);
 }
 getChart()
 {
  setTimeout(() => {
    this.chartOptions = {
      title: {
        text: "Temperatura Fermentacji"
      },
      axisY: {
        title: "Temperatura",
        suffix: "°C"
      },
      axisX: {
        title: "Data",
        valueFormatString: "D.MM HH:mm"
      },
      toolTip: {
        shared: true,
      },
      legend: {
        cursor: "pointer",
        itemclick: function(e: any){
          if (typeof(e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
            e.dataSeries.visible = false;
          } else{
            e.dataSeries.visible = true;
          }
          e.chart.render();
        }
      },
      data: [{
        type: "line",
        name:'Temperatura Otoczenia',
        showInLegend:true,
        labels:this.labels,
        dataPoints:this.datasetOutside
      },{
        type: "line",
        name:'Temperatura Fermentacji',
        showInLegend:true,
        labels:this.labels,
        dataPoints:this.datasetInside
      }]                
    };
   }, 1000);
  
 }
}
