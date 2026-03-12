import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChessapiserviceService } from '../../Services/chessapiservice.service';
import { Piece } from '../../Helper/classes/Piece'
import { CdkDrag, CdkDragDrop, CdkDropList, DragDrop } from '@angular/cdk/drag-drop';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { transferArrayItem } from '@angular/cdk/drag-drop';
import { Spot } from '../../Helper/classes/Spot';
@Component({
  selector: 'app-board',
  imports: [CommonModule, CdkDrag, CdkDropList],
  templateUrl: './board.component.html',
  styleUrl: './board.component.scss'
})
export class BoardComponent {
  // the html code fpr pieces can be from database (just to add database entity framework) 
  // or make enum with value and decode it thhrough backedn api call not from FE hardcode 
  chessService: ChessapiserviceService;
  startingPiecesDetails: Piece[] = [];
  piecesDetails: any;
  isActive: boolean = true;
 spots: Spot [][]=[]; 
  constructor(chessService: ChessapiserviceService) {
    this.chessService = chessService;
    this.chessService.getData();
  }


  ngOnInit() {
    this.initializeBoard();
  }


  initializeBoard() {
    //  this.chessService.getData().subscribe(data=>{
    //   console.log("data",data)
    //   this.piecesDetails= data
    // })
    this.chessService.getData().subscribe({
      next: (res: any) => {
        this.piecesDetails = res.spots;
        console.log("--->", res.spots)
        this.spots  = res.spots//JSON.parse(JSON.stringify(res));
        
         console.log("22--->", this.spots)
        this.bindPiceWithHtmlDiv(this.piecesDetails);
      }
    })
  }

  bindPiceWithHtmlDiv(pieceData: any) {
    console.log("pieceData", pieceData)
    for (let i = 0; i < pieceData.length; i++) {
      //console.log("pieceData",pieceData[i])
      for (let j = 0; j < pieceData.length; j++) {
        let id = this.createIdFormCordinate(pieceData[i][j]);

        var element = document.getElementById(id);
        let a = pieceData[i][j].cordinates.x
        let b = pieceData[i][j].cordinates.y
        if (element != null) {
          element.innerHTML = pieceData[a][b]?.piece?.htmlCode ?? "";
          //element.style.color = "white";
        }

      }

    }

  }

  createIdFormCordinate(pieceCordinates: any): string {
    let x = pieceCordinates.cordinates.x
    let y = pieceCordinates.cordinates.y
    let z = pieceCordinates.cordinates.z
    let str = `cell-${x}-${y}-${z}`
    return str;
  }
  getColors(): string {
    return "";
  }

  over(cellCordinate: String) {
    var splittedCellCordinates = cellCordinate.split('-');
    console.log("cellCordinate", splittedCellCordinates)
    var cell_X_Coridnate = splittedCellCordinates[1];
    var cell_Y_Coridnate = splittedCellCordinates[2];
    var cell_Z_Coridnate = splittedCellCordinates[3];
    for (let i = 0; i < this.piecesDetails.length; i++) {
      for (let j = 0; j < this.piecesDetails[i].length; j++) {
        var temp = this.piecesDetails[i];
        if (this.piecesDetails[i][j].cordinates.x == cell_X_Coridnate && this.piecesDetails[i][j].cordinates.y == cell_Y_Coridnate && this.piecesDetails[i][j].cordinates.z == cell_Z_Coridnate) {
          console.log("data", this.piecesDetails[i][j])
        }
      }
    }
  }
  GetPieceDetails(cellCordinate: String):any {
    var splittedCellCordinates = cellCordinate.split('-');
    console.log("cellCordinate", splittedCellCordinates)
    var cell_X_Coridnate = splittedCellCordinates[1];
    var cell_Y_Coridnate = splittedCellCordinates[2];
    var cell_Z_Coridnate = splittedCellCordinates[3];
    for (let i = 0; i < this.piecesDetails.length; i++) {
      for (let j = 0; j < this.piecesDetails[i].length; j++) {
        var temp = this.piecesDetails[i];
        if (this.piecesDetails[i][j].cordinates.x == cell_X_Coridnate && this.piecesDetails[i][j].cordinates.y == cell_Y_Coridnate && this.piecesDetails[i][j].cordinates.z == cell_Z_Coridnate) {
          console.log("data", this.piecesDetails[i][j])
        }
      }
    }
  }
  k:any=1;
  t:any=2;
  connectedDropLists = this.spots.flatMap(row => row.map(cell => `cell-${cell.cordinates.x}-${cell.cordinates.y}`));

  drop(event: CdkDragDrop<any>) {
   console.log("Previous container data:", event.previousContainer.data);
console.log("Current container data:", event.container.data);
console.log("Dragged item data:", event);
   // console.log("drop event current container data", event.item.data)
   // console.log("drop event previous container data", event.container.data)
 /*var fromPieceDetails =  this.GetPieceDetails(event.previousContainer.data);
 var toPieceDetails =  this.GetPieceDetails(event.container.data);
 console.log("fromPieceDetails",fromPieceDetails)
    console.log("this.piecesDetails",this.piecesDetails)*/
    //this.chessService.canMove()
  }

  onDragStart(event: any) {
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
/*
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChessapiserviceService } from '../../Services/chessapiservice.service';
import { Piece } from '../../Helper/classes/Piece'
import { CdkDrag, CdkDragDrop, CdkDropList, DragDrop } from '@angular/cdk/drag-drop';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { transferArrayItem } from '@angular/cdk/drag-drop';
import { Spot } from '../../Helper/classes/Spot';

@Component({
  selector: 'app-board',
  imports: [CommonModule, CdkDrag, CdkDropList],
  templateUrl: './board.component.html',
  styleUrl: './board.component.scss'
})
export class BoardComponent implements OnInit {
  chessService: ChessapiserviceService;
  startingPiecesDetails: Piece[] = [];
  piecesDetails: any;
  isActive: boolean = true;
  spots: Spot[][] = [];
  connectedDropLists: string[] = [];

  constructor(chessService: ChessapiserviceService) {
    this.chessService = chessService;
  }

  ngOnInit() {
    this.initializeBoard();
  }

  initializeBoard() {
    this.chessService.getData().subscribe({
      next: (res: any) => {
        this.spots = res.spots;
        console.log("Spots loaded:", this.spots);
        
        // Initialize connected drop lists AFTER spots are loaded
        this.updateConnectedDropLists();
      },
      error: (err) => {
        console.error("Error loading board:", err);
      }
    })
  }

  // Update connected drop lists based on current spots
  updateConnectedDropLists() {
    this.connectedDropLists = this.spots.flatMap(row => 
      row.map(cell => `cell-${cell.cordinates.x}-${cell.cordinates.y}-${cell.cordinates.z}`)
    );
    console.log("Connected drop lists:", this.connectedDropLists);
  }

  drop(event: CdkDragDrop<any>) {
    console.log("DROP EVENT FIRED");
    console.log("Previous container ID:", event.previousContainer.id);
    console.log("Current container ID:", event.container.id);
    console.log("Previous container data:", event.previousContainer.data);
    console.log("Current container data:", event.container.data);
    
    // Get the dragged piece data
    const draggedData = event.item.data;
    
    // Only proceed if we're moving to a different cell
    if (event.previousContainer.id !== event.container.id) {
      // Get coordinates
      const fromCell = event.previousContainer.data;
      const toCell = event.container.data;
      
      console.log(`Moving piece from (${fromCell.cordinates.x},${fromCell.cordinates.y}) to (${toCell.cordinates.x},${toCell.cordinates.y})`);
      
      // Update the board data structure
      // Move the piece from source to destination
      toCell.piece = fromCell.piece;
      fromCell.piece = null;
      
      // Force Angular to detect changes
      this.spots = [...this.spots];
      
      // Optional: Call service to validate move
      // this.chessService.validateMove(fromCell, toCell);
    } else {
      console.log("Same container - no move needed");
    }
  }

  // Helper method to get cell by coordinates
  getCellByCoordinates(x: number, y: number, z: string): Spot | null {
    for (const row of this.spots) {
      for (const cell of row) {
        if (cell.cordinates.x === x && 
            cell.cordinates.y === y && 
            cell.cordinates.z === z) {
          return cell;
        }
      }
    }
    return null;
  }
}

*/