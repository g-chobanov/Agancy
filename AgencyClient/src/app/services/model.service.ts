import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export class ModelService<T> {

  private hostUrl: string = "https://localhost:7256"
  private url!: string;
  private headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');

  constructor(
    private http: HttpClient, 
    private allRoute: string, 
    private createRoute: string, 
    private deleteRoute: string,
    private updateRoute: string,
    ) { 
    this.url = this.hostUrl;
  }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.url + this.allRoute);
  }

  create(model: T) {
    return this.http.post(this.url + this.createRoute, JSON.stringify(model), {headers: this.headers});
  }

  update(model: T) {
    return this.http.put(this.url + this.updateRoute, JSON.stringify(model), {headers: this.headers});

  }
  delete(id: string) {
    return this.http.delete(this.url + this.deleteRoute + "?index=" + id);
  }

}
