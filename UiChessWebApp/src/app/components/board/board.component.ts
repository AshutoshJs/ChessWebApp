import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChessapiserviceService } from '../../Services/chessapiservice.service';
import { Piece} from '../../Helper/classes/Piece'
@Component({
  selector: 'app-board',
  imports: [],
  templateUrl: './board.component.html',
  styleUrl: './board.component.scss'
})
export class BoardComponent {

chessService:ChessapiserviceService;
startingPiecesDetails:Piece[] = [];
piecesDetails:any;


constructor(chessService:ChessapiserviceService) {
  this.chessService = chessService;
  this.chessService.getData();
}


ngOnInit() {
    this.initializeBoard();
  }


initializeBoard(){
    //  this.chessService.getData().subscribe(data=>{
    //   console.log("data",data)
    //   this.piecesDetails= data
    // })
     this.chessService.getData().subscribe({
      next:(res:any)=>{
        
        this.piecesDetails= res.pieces;
        console.log("--->",this.piecesDetails)
      }
     })
  }

  // the html code fpr pieces can be from database (just to add database entity framework) or make enum with value and decode it thhrough backedn api call not from FE hardcode 
}
