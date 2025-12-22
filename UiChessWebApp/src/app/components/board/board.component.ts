import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChessapiserviceService } from '../../Services/chessapiservice.service';
import { Piece} from '../../Helper/classes/Piece'
import { CdkDrag, CdkDragDrop, CdkDropList, DragDrop } from '@angular/cdk/drag-drop';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { transferArrayItem } from '@angular/cdk/drag-drop';
@Component({
  selector: 'app-board',
  imports: [CommonModule, CdkDrag, CdkDropList],
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

  over(cellCordinate:String) {
//get cell data cell-0-0-a

var splittedCellCordinates= cellCordinate.split('-');
console.log("cellCordinate",splittedCellCordinates)
var cell_X_Coridnate=splittedCellCordinates[1];
var cell_Y_Coridnate=splittedCellCordinates[2];
var cell_Z_Coridnate=splittedCellCordinates[3];
for(let i=0; i<this.piecesDetails.length;i++){
  for (let j=0;j<this.piecesDetails[i].length;j++){
    var temp=this.piecesDetails[i];
    if(this.piecesDetails[i][j].cordinates.x == cell_X_Coridnate &&this.piecesDetails[i][j].cordinates.y== cell_Y_Coridnate&&this.piecesDetails[i][j].cordinates.z==cell_Z_Coridnate)
      {
        console.log("data",this.piecesDetails[i][j] )
      }
  }
}
   // console.log('Mouseover called');
  }

// drop(event:any){
// console.log("drop event")
// }
drop(event: CdkDragDrop<string[]>,cells:any) {
  console.log("cell",cells)  
  console.log("drop event",event)
  }

  /*
  Correct Mental Model for Chess ♟️
Chess Concept	CDK Concept
Square	cdkDropList
Piece	cdkDrag
Move	cdkDropListDropped
From / To	previousContainer → container
  */

}
