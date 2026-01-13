import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ChessapiserviceService {
baseUrl:string="https://localhost:7159/api/Game/InitalizeGameSecond"

initalizeGameold:string = "https://localhost:7159/api/Game/InitalizeGame"
  
rooUrl:string = "https://localhost:7159/api/Game/"

constructor(public http: HttpClient) { }


public getData(): Observable<string> {
return this.http.get<any>(this.initalizeGameold);
// return this.http.get<any>(this.baseUrl).subscribe(data => {console.log("dataFromService",data);
//     return data} );
  //return items;
}

public canMove(body:any): Observable<string> {
return this.http.post<any>(this.rooUrl+'CanMove',body);
// return this.http.get<any>(this.baseUrl).subscribe(data => {console.log("dataFromService",data);
//     return data} );
  //return items;
}

}
