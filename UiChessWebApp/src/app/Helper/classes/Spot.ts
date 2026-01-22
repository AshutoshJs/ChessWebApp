import { Cordinates } from "./Cordinates"
import { Piece } from "./Piece"

export class Spot{
cordinates: Cordinates;
    piece : Piece;
isSpotEmpty: boolean;

/**
 *
 */
constructor(c:Cordinates ,p: Piece,ispotempty: boolean) {
    this.cordinates = c;
    this.piece = p;
    this.isSpotEmpty = ispotempty;
    
}
}

