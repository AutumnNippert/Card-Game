using System;

public class Board {
    //going to be a Card[2][4] board
    private Card[][] board;

    public Board( Card[][] board ) {
        this.board = board;
    }

    public String displayBoard( ) {
        String boardString = String.Format( @"
                        ┌─────────────────────────────────────────────────────────────────────────────────────┐
                        │  %18s   %18s   %18s   %18s  │
                        │  %18s   %18s   %18s   %18s  │
                        │  %18s   %18s   %18s   %18s  │
                        │  %18s   %18s   %18s   %18s  │
                        │  %18s   %18s   %18s   %18s  │
                        │                                                                                     │
                        ├─────────────────────────────────────────────────────────────────────────────────────┤
                        │                                                                                     │
                        │  %18s   %18s   %18s   %18s  │
                        │  %18s   %18s   %18s   %18s  │
                        │  %18s   %18s   %18s   %18s  │
                        │  %18s   %18s   %18s   %18s  │
                        │  %18s   %18s   %18s   %18s  │
                        └─────────────────────────────────────────────────────────────────────────────────────┘",
                board[ 0 ][ 0 ].toString( ).Split( "\n" )[ 0 ],
                board[ 0 ][ 1 ].toString( ).Split( "\n" )[ 0 ],
                board[ 0 ][ 2 ].toString( ).Split( "\n" )[ 0 ],
                board[ 0 ][ 3 ].toString( ).Split( "\n" )[ 0 ],
                board[ 0 ][ 0 ].toString( ).Split( "\n" )[ 1 ],
                board[ 0 ][ 1 ].toString( ).Split( "\n" )[ 1 ],
                board[ 0 ][ 2 ].toString( ).Split( "\n" )[ 1 ],
                board[ 0 ][ 3 ].toString( ).Split( "\n" )[ 1 ],
                board[ 0 ][ 0 ].toString( ).Split( "\n" )[ 2 ],
                board[ 0 ][ 1 ].toString( ).Split( "\n" )[ 2 ],
                board[ 0 ][ 2 ].toString( ).Split( "\n" )[ 2 ],
                board[ 0 ][ 3 ].toString( ).Split( "\n" )[ 2 ],
                board[ 0 ][ 0 ].toString( ).Split( "\n" )[ 3 ],
                board[ 0 ][ 1 ].toString( ).Split( "\n" )[ 3 ],
                board[ 0 ][ 2 ].toString( ).Split( "\n" )[ 3 ],
                board[ 0 ][ 3 ].toString( ).Split( "\n" )[ 3 ],
                board[ 0 ][ 0 ].toString( ).Split( "\n" )[ 4 ],
                board[ 0 ][ 1 ].toString( ).Split( "\n" )[ 4 ],
                board[ 0 ][ 2 ].toString( ).Split( "\n" )[ 4 ],
                board[ 0 ][ 3 ].toString( ).Split( "\n" )[ 4 ],
                board[ 1 ][ 0 ].toString( ).Split( "\n" )[ 0 ],
                board[ 1 ][ 1 ].toString( ).Split( "\n" )[ 0 ],
                board[ 1 ][ 2 ].toString( ).Split( "\n" )[ 0 ],
                board[ 1 ][ 3 ].toString( ).Split( "\n" )[ 0 ],
                board[ 1 ][ 0 ].toString( ).Split( "\n" )[ 1 ],
                board[ 1 ][ 1 ].toString( ).Split( "\n" )[ 1 ],
                board[ 1 ][ 2 ].toString( ).Split( "\n" )[ 1 ],
                board[ 1 ][ 3 ].toString( ).Split( "\n" )[ 1 ],
                board[ 1 ][ 0 ].toString( ).Split( "\n" )[ 2 ],
                board[ 1 ][ 1 ].toString( ).Split( "\n" )[ 2 ],
                board[ 1 ][ 2 ].toString( ).Split( "\n" )[ 2 ],
                board[ 1 ][ 3 ].toString( ).Split( "\n" )[ 2 ],
                board[ 1 ][ 0 ].toString( ).Split( "\n" )[ 3 ],
                board[ 1 ][ 1 ].toString( ).Split( "\n" )[ 3 ],
                board[ 1 ][ 2 ].toString( ).Split( "\n" )[ 3 ],
                board[ 1 ][ 3 ].toString( ).Split( "\n" )[ 3 ],
                board[ 1 ][ 0 ].toString( ).Split( "\n" )[ 4 ],
                board[ 1 ][ 1 ].toString( ).Split( "\n" )[ 4 ],
                board[ 1 ][ 2 ].toString( ).Split( "\n" )[ 4 ],
                board[ 1 ][ 3 ].toString( ).Split( "\n" )[ 4 ] );
        int boardHeight = boardString.Split( "\n" ).Length;

        String[] strs = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        for ( int i = 0; i < boardHeight; i++ ) {
            strs[ i ] += ( boardString.Split( "\n" )[ i ] );
        }

        String str = "";
        for ( int i = 0; i < strs.Length; i++ ) {
            str += strs[ i ] + "\n";
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
        return board[ pos.y ][ pos.x ].type != CardType.EMPTY;
    }
}
