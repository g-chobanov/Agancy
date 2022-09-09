import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, Observable } from 'rxjs';
import { ErrorHandlingService } from '../common/error-handling-service';
import { GlobalConstants } from '../common/globalconstants';

export class ModelService<T> extends ErrorHandlingService{

  protected hostUrl: string = GlobalConstants.apiURL;
  protected headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');

  constructor(
    protected http: HttpClient, 
    private allRoute: string, 
    private createRoute: string, 
    private deleteRoute: string,
    private updateRoute: string,
    ) { 
    super();
    this.hostUrl = this.hostUrl;
  }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.hostUrl + this.allRoute)
    .pipe( 
      catchError((error) => {
        return this.handleError(error.error);
      }));
  }

  create(model: T) {
    return this.http.post(this.hostUrl + this.createRoute, JSON.stringify(model), {headers: this.headers})
      .pipe( 
        catchError((error) => {
          return this.handleError(error.error);
        }));
    
  }

  update(model: T) {
    return this.http.put(this.hostUrl + this.updateRoute, JSON.stringify(model), {headers: this.headers})
    .pipe( 
      catchError((error) => {
        return this.handleError(error.error);
      }));

  }
  delete(id: string) {
    return this.http.delete(this.hostUrl + this.deleteRoute + "?index=" + id)
    .pipe( 
      catchError((error) => {
        return this.handleError(error.error);
      }));
  }

}
