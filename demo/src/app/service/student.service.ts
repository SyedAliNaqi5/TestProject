import { Injectable } from '@angular/core';
import{HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http:HttpClient) { }

  apiUrl='https://localhost:7134/api/info/'

  add (data:any):Observable<any>{
    return this.http.post(this.apiUrl+'Add',data)
  }
  getAll ():Observable<any>{
    return this.http.get(this.apiUrl+'GetAll')
  }
  getbyid(id: any):Observable<any> {
    return this.http.get(this.apiUrl + 'GetById/' + id)
  }
  delete (id:number):Observable<any>{
    return this.http.delete(this.apiUrl+'Delete/'+id)
  }
  update (data: any) :Observable<any>{
    return this.http.put(this.apiUrl + 'Update', data)
  }
}
