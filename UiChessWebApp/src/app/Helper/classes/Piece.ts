import { Colors } from "../constants/Color";
import { PieceTypes } from "../constants/PieceTypes";
import { Cordinates } from "./Cordinates";

export class Piece{
 isMovingFirstTime: boolean;
    colorCode: number;
    color: string;
    isWhite: boolean;
    typeOfPiece: string;
    htmlCode: string;

    constructor(
        isMovingFirstTime: boolean,
        colorCode: number,
        color: string,
        isWhite: boolean,
        typeOfPiece: string,
        htmlCode: string
    ) {
        this.isMovingFirstTime = isMovingFirstTime;
        this.colorCode = colorCode;
        this.color = color;
        this.isWhite = isWhite;
        this.typeOfPiece = typeOfPiece;
        this.htmlCode = htmlCode;
    }


  // PieceCordinates:Cordinates;
//   Color:Colors;
// Type:PieceTypes;

// /**
//  *
//  */
// constructor(cordinates:Cordinates , color:Colors,types:PieceTypes) {
//    // super();
//     this.PieceCordinates=cordinates;
//     this.Color=color;
//     this.Type=types;
// }
}