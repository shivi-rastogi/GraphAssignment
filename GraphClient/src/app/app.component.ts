import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { IGraph } from './graph';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  private interval:any;  
  title = 'GraphiClient';
  private graphUrl = "http://localhost:54554/api/graph";
  public message: string;
  public data : IGraph[];
  
  constructor(private appService: AppService){}
  
  ngOnInit() {    
    this.interval = setInterval(() => { 
      if(this.data)
      {
        this.appService.refreshData(this.data["0"].SessionID).
        then(res => {
          this.data = <any[]>res;
          console.log('res: ', this.data["0"].SessionID);
        }); 
      }
    }, 60000);

  }
  

  upload(files) {
    console.log("upload")
    if (files.length === 0)
      return;

      this.message = null;
      if(this.data)
        this.data = null;


    const formData = new FormData();

    for (let file of files)
    
      formData.append(file.name, file);      
    
      
      this.appService.UploadData(formData)
      .subscribe(data => this.data = data,error=> this.message=error);      
  }
}
