package utility;

import java.util.ArrayList;
import java.util.Scanner;

public class Menu {
    public String value;
    public String name;
    public ArrayList< String > options;

    public Menu( String name, ArrayList< String > options ) {
        this.name = name;
        this.options = options;
    }

    public void display( ) {
        System.out.println( name );
        for ( int i = 1; i < options.size( ) + 1; i++ ) {
            System.out.println( "(" + i + ") " + options.get( i - 1 ) );
        }
        System.out.print( ">>> " );
        Scanner scn = new Scanner( System.in );
        value = scn.nextLine( );
    }

    public int getIntValue( ) {
        try {
            return Integer.parseInt( value );
        } catch ( Exception valueNotAnInteger ) {
            valueNotAnInteger.printStackTrace( );
            return -1;
        }
    }

    public String getStringValue( ) {
        return value;
    }
}
