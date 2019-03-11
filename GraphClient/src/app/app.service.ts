import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { IGraph } from './graph';
import { Observable, throwError } from '../../node_modules/rxjs';
import { catchError } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({    
  })
};

@Injectable({
  providedIn: 'root'
})
export class AppService {
  private graphUrl = "http://localhost:54554/api/graph";
  private graphData: IGraph[];  

  constructor(private http: HttpClient) {
    
  }

  refreshData(SessionId:string){
    const params = {
      "SessionId": SessionId    
    }    
    
    return this.http.get(this.graphUrl, { params }).toPromise().catch(this.handleError);
  }
    
  UploadData (formData:FormData): Observable<IGraph[]> {
    return this.http.post<IGraph[]>(this.graphUrl, formData, httpOptions)
     .pipe(
       catchError(this.handleError)
     );
   }

   private handleError(err: HttpErrorResponse) {    
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {      
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {     
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
