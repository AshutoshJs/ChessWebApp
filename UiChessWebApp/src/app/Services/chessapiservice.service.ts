import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ChessapiserviceService {
baseUrl:string="https://localhost:7159/api/Game/InitalizeGame"
  

constructor(public http: HttpClient) { }


public getData(): Observable<string> {
var items;
return this.http.get<any>(this.baseUrl);
// return this.http.get<any>(this.baseUrl).subscribe(data => {console.log("dataFromService",data);
//     return data} );
  //return items;
}

}
