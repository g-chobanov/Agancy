import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GlobalConstants } from '../globalconstants';

export class ModelService<T> {

  protected hostUrl: string = GlobalConstants.apiURL;
  protected headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');

  constructor(
    protected http: HttpClient, 
    private allRoute: string, 
    private createRoute: string, 
    private deleteRoute: string,
    private updateRoute: string,
    ) { 
    this.hostUrl = this.hostUrl;
  }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.hostUrl + this.allRoute);
  }

  create(model: T) {
    console.log(model);
    return this.http.post(this.hostUrl + this.createRoute, JSON.stringify(model), {headers: this.headers});
  }

  update(model: T) {
    return this.http.put(this.hostUrl + this.updateRoute, JSON.stringify(model), {headers: this.headers});

  }
  delete(id: string) {
    return this.http.delete(this.hostUrl + this.deleteRoute + "?index=" + id);
  }

}
