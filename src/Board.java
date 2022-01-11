public class Board {
    //going to be a Card[2][4] board
    private Card[][] board;

    public Board( Card[][] board ) {
        this.board = board;
    }

    public String displayBoard( ) {
        String boardString = String.format( """
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
                        └─────────────────────────────────────────────────────────────────────────────────────┘""",
                board[ 0 ][ 0 ].toString( ).split( "\n" )[ 0 ],
                board[ 0 ][ 1 ].toString( ).split( "\n" )[ 0 ],
                board[ 0 ][ 2 ].toString( ).split( "\n" )[ 0 ],
                board[ 0 ][ 3 ].toString( ).split( "\n" )[ 0 ],
                board[ 0 ][ 0 ].toString( ).split( "\n" )[ 1 ],
                board[ 0 ][ 1 ].toString( ).split( "\n" )[ 1 ],
                board[ 0 ][ 2 ].toString( ).split( "\n" )[ 1 ],
                board[ 0 ][ 3 ].toString( ).split( "\n" )[ 1 ],
                board[ 0 ][ 0 ].toString( ).split( "\n" )[ 2 ],
                board[ 0 ][ 1 ].toString( ).split( "\n" )[ 2 ],
                board[ 0 ][ 2 ].toString( ).split( "\n" )[ 2 ],
                board[ 0 ][ 3 ].toString( ).split( "\n" )[ 2 ],
                board[ 0 ][ 0 ].toString( ).split( "\n" )[ 3 ],
                board[ 0 ][ 1 ].toString( ).split( "\n" )[ 3 ],
                board[ 0 ][ 2 ].toString( ).split( "\n" )[ 3 ],
                board[ 0 ][ 3 ].toString( ).split( "\n" )[ 3 ],
                board[ 0 ][ 0 ].toString( ).split( "\n" )[ 4 ],
                board[ 0 ][ 1 ].toString( ).split( "\n" )[ 4 ],
                board[ 0 ][ 2 ].toString( ).split( "\n" )[ 4 ],
                board[ 0 ][ 3 ].toString( ).split( "\n" )[ 4 ],
                board[ 1 ][ 0 ].toString( ).split( "\n" )[ 0 ],
                board[ 1 ][ 1 ].toString( ).split( "\n" )[ 0 ],
                board[ 1 ][ 2 ].toString( ).split( "\n" )[ 0 ],
                board[ 1 ][ 3 ].toString( ).split( "\n" )[ 0 ],
                board[ 1 ][ 0 ].toString( ).split( "\n" )[ 1 ],
                board[ 1 ][ 1 ].toString( ).split( "\n" )[ 1 ],
                board[ 1 ][ 2 ].toString( ).split( "\n" )[ 1 ],
                board[ 1 ][ 3 ].toString( ).split( "\n" )[ 1 ],
                board[ 1 ][ 0 ].toString( ).split( "\n" )[ 2 ],
                board[ 1 ][ 1 ].toString( ).split( "\n" )[ 2 ],
                board[ 1 ][ 2 ].toString( ).split( "\n" )[ 2 ],
                board[ 1 ][ 3 ].toString( ).split( "\n" )[ 2 ],
                board[ 1 ][ 0 ].toString( ).split( "\n" )[ 3 ],
                board[ 1 ][ 1 ].toString( ).split( "\n" )[ 3 ],
                board[ 1 ][ 2 ].toString( ).split( "\n" )[ 3 ],
                board[ 1 ][ 3 ].toString( ).split( "\n" )[ 3 ],
                board[ 1 ][ 0 ].toString( ).split( "\n" )[ 4 ],
                board[ 1 ][ 1 ].toString( ).split( "\n" )[ 4 ],
                board[ 1 ][ 2 ].toString( ).split( "\n" )[ 4 ],
                board[ 1 ][ 3 ].toString( ).split( "\n" )[ 4 ] );
        final int boardHeight = boardString.split( "\n" ).length;

        String[] strs = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        for ( int i = 0; i < boardHeight; i++ ) {
            strs[ i ] += ( boardString.split( "\n" )[ i ] );
        }

        String str = "";
        for ( int i = 0; i < strs.length; i++ ) {
            str += strs[ i ] + "\n";
        }
        return str;
    }

    public Card[][] getCards( ) {
        return board;
    }

    public void placeCard( Card c, Coordinate pos ) {
        board[ pos.y ][ pos.x - 1 ] = c;
    }

    public boolean cardExists( Coordinate pos ) {
        return board[ pos.y ][ pos.x - 1 ] != Card.EMPTY;
    }
}
