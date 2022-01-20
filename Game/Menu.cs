using System;
using System.Collections.Generic;

public class Menu {
    public String value;
    public String name;
    public List<String> options;

    public Menu( String name, List< String > options ) {
        this.name = name;
        this.options = options;
    }

    public void display( ) {
        Console.WriteLine( name );
        for ( int i = 1; i < options.Count + 1; i++ ) {
            Console.WriteLine( "(" + i + ") " + options[i - 1] );
        }
        Console.Write( ">>> " );
        value = Console.ReadLine();
    }

    public int getIntValue( ) {
        return int.Parse( value );
    }

    public String getStringValue( ) {
        return value;
    }
}
