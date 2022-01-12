import java.util.ArrayList;

public class Player {
    private ArrayList< Card > cards = new ArrayList<>( 0 );
    private int playerNumber;
    private Deck deck;

    public Player( int number, Deck deck ) {
        this.playerNumber = number;
        this.deck = deck;
    }

    public void giveCard( Card c ) {
        cards.add( c );
    }

    public void drawCardFromDeck( ) {
        int cardIndex = getRandInt( deck.getCards( ).size( ) );
        Card c = deck.getCards( ).get( cardIndex );
        giveCard( c );
        deck.getCards( ).remove( c );
    }

    public int getRandInt( int max ) {
        return ( int ) ( Math.random( ) * max );
    }

    private ArrayList< Card > getCards( ) {
        return cards;
    }

    public void setCards( ArrayList< Card > cards ) {
        this.cards = cards;
    }

    public String displayCards( ) {
        String[] strs = { "", "", "", "", "" };
        for ( int i = 0; i < cards.size( ); i++ ) {
            final int cardHeight = 5;
            for ( int j = 0; j < cardHeight; j++ ) {
                strs[ j ] += ( cards.get( i ).toString( ).split( "\n" )[ j ] + "\t" );
            }
        }

        String str = "";
        for ( int i = 0; i < strs.length; i++ ) {
            str += strs[ i ] + "\n";
        }
        return str.substring( 0, str.length( ) - 1 );
    }

    public String displayCardBacks( ) {
        String[] strs = { "", "", "", "", "" };
        for ( int i = 0; i < cards.size( ); i++ ) {
            final int cardHeight = 5;
            for ( int j = 0; j < cardHeight; j++ ) {
                strs[ j ] += ( cards.get( i ).back.split( "\n" )[ j ] + "\t" );
            }
        }

        String str = "";
        for ( int i = 0; i < strs.length; i++ ) {
            str += strs[ i ] + "\n";
        }
        return str.substring( 0, str.length( ) - 1 );
    }

    public void playCard( Board board, Card c, Coordinate pos ) {
        cards.remove( c );
        board.placeCard( c, pos );
        System.out.println( "Card: " + c.getName( ) + " played at position: " + pos.x );
    }

    public boolean hasCard( Card c ) {
        return cards.contains( c );
    }
}
