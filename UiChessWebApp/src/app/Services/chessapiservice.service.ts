import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ChessapiserviceService {
baseUrl:string="https://localhost:7159/api/Game/InitalizeGameSecond"
  

constructor(public http: HttpClient) { }


public getData(): Observable<string> {
return this.http.get<any>(this.baseUrl);
// return this.http.get<any>(this.baseUrl).subscribe(data => {console.log("dataFromService",data);
//     return data} );
  //return items;
}

}
