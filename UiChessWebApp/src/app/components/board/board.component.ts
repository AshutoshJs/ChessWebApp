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
  // the html code fpr pieces can be from database (just to add database entity framework) 
  // or make enum with value and decode it thhrough backedn api call not from FE hardcode 
chessService:ChessapiserviceService;
startingPiecesDetails:Piece[] = [];
piecesDetails:any;
isActive:boolean=true;

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
        this.piecesDetails= res.spots;
        console.log("--->",res.spots)
        this.bindPiceWithHtmlDiv(this.piecesDetails);
      }
     })
  }

  bindPiceWithHtmlDiv(pieceData:any)
  {
     console.log("pieceData",pieceData)
    for(let i=0;i<pieceData.length;i++){
      //console.log("pieceData",pieceData[i])
      for(let j=0;j<pieceData.length;j++){
      let id = this.createIdFormCordinate(pieceData[i][j]);  
     
      var element=document.getElementById(id);
      let  a= pieceData[i][j].cordinates.x
      let b=pieceData[i][j].cordinates.y
      if(element != null){
element.innerHTML = pieceData[a][b]?.piece?.htmlCode ?? "";
//element.style.color = "white";
      }
      
      }
     
    }
    
  }

  createIdFormCordinate(pieceCordinates:any): string {
  let x=pieceCordinates.cordinates.x
  let y=pieceCordinates.cordinates.y
  let z=pieceCordinates.cordinates.z
  let str=`cell-${x}-${y}-${z}`
    return str; 
  }
  getColors(): string
  {
  return "";
  }

}
