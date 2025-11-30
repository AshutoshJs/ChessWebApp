import { Colors } from "../constants/Color";
import { PieceTypes } from "../constants/PieceTypes";
import { Cordinates } from "./Cordinates";

export class Piece{
PieceCordinates:Cordinates;
  Color:Colors;
Type:PieceTypes;

/**
 *
 */
constructor(cordinates:Cordinates , color:Colors,types:PieceTypes) {
   // super();
    this.PieceCordinates=cordinates;
    this.Color=color;
    this.Type=types;
}
}