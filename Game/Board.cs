using System;

public class Board {
    //going to be a Card[2][4] board
    private Card[][] board;

    public Board( Card[][] board ) {
        this.board = board;
    }

    public string displayBoard( ) {
        string boardString = string.Format(
@"┌─────────────────────────────────────────────────────────────────────────────────────┐
│  {0,18}   {1,18}   {2,18}   {3,18}  │
│  {4,18}   {5,18}   {6,18}   {7,18}  │
│  {8,18}   {9,18}   {10,18}   {11,18}  │
│  {12,18}   {13,18}   {14,18}   {15,18}  │
│  {16,18}   {17,18}   {18,18}   {19,18}  │
│                                                                                     │
├─────────────────────────────────────────────────────────────────────────────────────┤
│                                                                                     │
│  {20,18}   {21,18}   {22,18}   {23,18}  │
│  {24,18}   {25,18}   {26,18}   {27,18}  │
│  {28,18}   {29,18}   {30,18}   {31,18}  │
│  {32,18}   {33,18}   {34,18}   {35,18}  │
│  {36,18}   {37,18}   {38,18}   {39,18}  │
└─────────────────────────────────────────────────────────────────────────────────────┘",
                board[ 0 ][ 0 ].toString( ).Split( "\r\n" )[ 0 ],
                board[ 0 ][ 1 ].toString( ).Split( "\r\n" )[ 0 ],
                board[ 0 ][ 2 ].toString( ).Split( "\r\n" )[ 0 ],
                board[ 0 ][ 3 ].toString( ).Split( "\r\n" )[ 0 ],
                board[ 0 ][ 0 ].toString( ).Split( "\r\n" )[ 1 ],
                board[ 0 ][ 1 ].toString( ).Split( "\r\n" )[ 1 ],
                board[ 0 ][ 2 ].toString( ).Split( "\r\n" )[ 1 ],
                board[ 0 ][ 3 ].toString( ).Split( "\r\n" )[ 1 ],
                board[ 0 ][ 0 ].toString( ).Split( "\r\n" )[ 2 ],
                board[ 0 ][ 1 ].toString( ).Split( "\r\n" )[ 2 ],
                board[ 0 ][ 2 ].toString( ).Split( "\r\n" )[ 2 ],
                board[ 0 ][ 3 ].toString( ).Split( "\r\n" )[ 2 ],
                board[ 0 ][ 0 ].toString( ).Split( "\r\n" )[ 3 ],
                board[ 0 ][ 1 ].toString( ).Split( "\r\n" )[ 3 ],
                board[ 0 ][ 2 ].toString( ).Split( "\r\n" )[ 3 ],
                board[ 0 ][ 3 ].toString( ).Split( "\r\n" )[ 3 ],
                board[ 0 ][ 0 ].toString( ).Split( "\r\n" )[ 4 ],
                board[ 0 ][ 1 ].toString( ).Split( "\r\n" )[ 4 ],
                board[ 0 ][ 2 ].toString( ).Split( "\r\n" )[ 4 ],
                board[ 0 ][ 3 ].toString( ).Split( "\r\n" )[ 4 ],
                board[ 1 ][ 0 ].toString( ).Split( "\r\n" )[ 0 ],
                board[ 1 ][ 1 ].toString( ).Split( "\r\n" )[ 0 ],
                board[ 1 ][ 2 ].toString( ).Split( "\r\n" )[ 0 ],
                board[ 1 ][ 3 ].toString( ).Split( "\r\n" )[ 0 ],
                board[ 1 ][ 0 ].toString( ).Split( "\r\n" )[ 1 ],
                board[ 1 ][ 1 ].toString( ).Split( "\r\n" )[ 1 ],
                board[ 1 ][ 2 ].toString( ).Split( "\r\n" )[ 1 ],
                board[ 1 ][ 3 ].toString( ).Split( "\r\n" )[ 1 ],
                board[ 1 ][ 0 ].toString( ).Split( "\r\n" )[ 2 ],
                board[ 1 ][ 1 ].toString( ).Split( "\r\n" )[ 2 ],
                board[ 1 ][ 2 ].toString( ).Split( "\r\n" )[ 2 ],
                board[ 1 ][ 3 ].toString( ).Split( "\r\n" )[ 2 ],
                board[ 1 ][ 0 ].toString( ).Split( "\r\n" )[ 3 ],
                board[ 1 ][ 1 ].toString( ).Split( "\r\n" )[ 3 ],
                board[ 1 ][ 2 ].toString( ).Split( "\r\n" )[ 3 ],
                board[ 1 ][ 3 ].toString( ).Split( "\r\n" )[ 3 ],
                board[ 1 ][ 0 ].toString( ).Split( "\r\n" )[ 4 ],
                board[ 1 ][ 1 ].toString( ).Split( "\r\n" )[ 4 ],
                board[ 1 ][ 2 ].toString( ).Split( "\r\n" )[ 4 ],
                board[ 1 ][ 3 ].toString( ).Split( "\r\n" )[ 4 ] );
        int boardHeight = boardString.Split( "\r\n" ).Length;

        string[] strs = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        for ( int i = 0; i < boardHeight; i++ ) {
            strs[ i ] += ( boardString.Split( "\r\n" )[ i ] );
        }

        string str = "";
        for ( int i = 0; i < strs.Length; i++ ) {
            str += strs[ i ] + "\r\n";
        }
        return str;
    }

    public Card[][] getCards( ) {
        return board;
    }

    public Card getCard( Coordinate coord ) {
        return board[ coord.y ][ coord.x ];
    }

    public void placeCard( Card c, Coordinate pos ) {
        board[ pos.y ][ pos.x ] = c;
    }

    public void removeCard(Coordinate pos)
    {
        board[pos.y][pos.x] = new Card(CardType.EMPTY);

    }
    public bool cardExists( Coordinate pos ) {
        return board[ pos.y ][ pos.x ].ID != CardType.EMPTY;
    }
}
