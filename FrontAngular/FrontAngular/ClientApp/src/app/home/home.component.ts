import { Component, Inject,OnDestroy,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subscription, timer } from 'rxjs';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit  {

  subscription: Subscription;
  everyFiveSeconds: Observable<number> = timer(0, 5000);
  public currencies: Currencies[];
  public BaseUrlstring : string;
  httpClient : HttpClient;
  interval: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    http.get<Currencies[]>(baseUrl + 'Currencies').subscribe(result => {
      this.currencies = result;
    }, error => console.error(error));
    this.BaseUrlstring = baseUrl;
    this.httpClient = http;
    this.subscription = this.everyFiveSeconds.subscribe(() => {
      this.fethData(this.httpClient,this.BaseUrlstring);
    });
    this.interval = setInterval(() => {
      this.fethData(this.httpClient, this.BaseUrlstring);
    }, 5000);
  }

  ngOnInit(): void {
    this.subscription = this.everyFiveSeconds.subscribe(() => {
      this.fethData(this.httpClient, this.BaseUrlstring);
    });
    this.interval = setInterval(() => {
      this.fethData(this.httpClient, this.BaseUrlstring);
    }, 5000);
  }

    fethData(http: HttpClient, baseUrl: string) {
      http.get<Currencies[]>(baseUrl + 'Currencies').subscribe(result => {
        this.currencies = result;
      }, error => console.error(error));
  }
  
}

interface Currencies {
  id: bigint;
  name: string;
  value: number;
}
