import { Component, OnInit } from '@angular/core';
import { CardsService } from './service/cards.service';
import { card } from './models/card.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title='Cards';
  message = '';
  registerSucess:boolean = false;
  cards:card[]= [];
  Card: card={
    id: 0,
    cardholderName: '',
    cardNumberr: '',
    cvc: 0,
    expiryMonth: 0,
    expiryYear: 0
  }


  
  constructor(private cardsServices:CardsService) {

    
  }
  ngOnInit(): void {
   console.log( this.getAllCards());
    
  }
getAllCards(){
  this.cardsServices.getAllCards()
  .subscribe(
    response =>{
      this.cards=response;
    }
  )

 
}
onsubmit (){

  if(this.Card.id == 0){
    this.cardsServices.Cardadd(this.Card)
    
.subscribe(
  response =>{
    
   this.getAllCards();
   this.Card={
    id: 0,
    cardholderName: '',
    cardNumberr: '',
    cvc: 0,
    expiryMonth: 0,
    expiryYear: 0
  };
  }
)

  } else{
    this.updatecard(this.Card)
  }

// this.cardsServices.Cardadd(this.Card)
// .subscribe(
//   response =>{
    
//    this.getAllCards();
  }





deletecard(id:number){
this.cardsServices.deleteCard(id)
.subscribe(
          response =>{
          this.getAllCards();


}
)
}
popoluteForm(card:card){
  this.Card = card;

}

updatecard(card:card){
this.cardsServices.updateCard(card)
.subscribe(
  response=>{
    this.getAllCards();
  })
}
}


