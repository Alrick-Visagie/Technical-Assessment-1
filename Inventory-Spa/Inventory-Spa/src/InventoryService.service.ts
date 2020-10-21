import { environment } from './environments/environment';
import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Observable, Subject, throwError} from 'rxjs';
import { map } from 'rxjs/operators';
import { Inventory } from './InventoryModel';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class InventoryServiceService {

  apiurl = environment.apiUrl;
constructor(private http: HttpClient) { }

getCarInventoryList(): Observable <Inventory[]> {
  return this.http.get<Inventory[]>(this.apiurl + 'api/CarInventory');
}

getInventoryByID(id: string): Observable <Inventory> {
  return this.http.get<Inventory>(this.apiurl + 'api/CarInventory' + '/' + id);
}

AddNewInventory(inventory: Inventory): Observable<Inventory> {
  return this.http.post<Inventory>(this.apiurl + 'api/CarInventory', inventory);
}


}
