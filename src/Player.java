import java.util.ArrayList;

public class Player {
    private ArrayList< Card > cards = new ArrayList<>( 0 );

    public Player( ) {

    }

    public void giveCard( Card c ) {
        cards.add( c );
    }

    private ArrayList< Card > getCards( ) {
        return cards;
    }

    public void setCards( ArrayList< Card > cards ) {
        this.cards = cards;
    }

    public String displayCards( ) {
        String[] strs = {"", "", "", "", ""};
        for ( int i = 0; i < cards.size( ); i++ ) {
            final int cardHeight = 5;
            for ( int j = 0; j < cardHeight; j++ ) {
                strs[j] += ( cards.get( i ).toString( ).split( "\n" )[j] + "\t");
            }
        }

        String str = "";
        for ( int i = 0; i < strs.length; i++ ) {
            str += strs[i] + "\n";
        }
        return str.substring( 0, str.length( ) - 1);
    }
}
