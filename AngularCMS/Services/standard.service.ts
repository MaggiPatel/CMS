import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Standard } from 'Model/standard';
import { Observable } from 'rxjs';  

@Injectable({
  providedIn: 'root'
})
export class StandardService {
  url = 'http://localhost:52351/Api/CmsAPI';
  constructor(private http : HttpClient) { }

  getAllStandards(): Observable<Standard[]> {
    return this.http.get<Standard[]>(this.url + '/GetAllStandards');  
  }  

  getStandardById(standardId: string): Observable<Standard> {  
    return this.http.get<Standard>(this.url + '/GetStandard/' + standardId);  
  }  
}
