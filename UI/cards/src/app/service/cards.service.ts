import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { card } from '../models/card.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CardsService {

  baseUrl='https://localhost:7249/api/Cards';
  
  constructor(private http:HttpClient) { }

  getAllCards(): Observable<card[]>
  {
   return this.http.get<card[]>(this.baseUrl)
  }

  Cardadd(card:card):Observable<card>
  {
    // card.id= null;
return this.http.post<card>(this.baseUrl,card)
  }


  deleteCard(id:number) : Observable<card>{
   return this.http.delete<card>(this.baseUrl + '/'+'id?'+ 'id=' + id)

  }

  
updateCard(card:card) : Observable<card>{
  
    // return this.http.put<card>(this.baseUrl + '/'+'id?'+ 'id=' + id);
    return this.http.put<card>(this.baseUrl ,card);


 
   }
}
