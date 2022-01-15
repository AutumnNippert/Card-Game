import javax.sound.sampled.*;
import java.io.File;
import java.io.IOException;

public class MusicPlayer {
    Clip clip;
    AudioInputStream audioStream;

    // constructor to initialize streams and clip
    public MusicPlayer( String filePath )
            throws UnsupportedAudioFileException,
            IOException, LineUnavailableException {


        File audioFile = new File( filePath );

        audioStream = AudioSystem.getAudioInputStream( audioFile );
        AudioFormat format = audioStream.getFormat( );

        DataLine.Info info = new DataLine.Info( Clip.class, format );
        clip = ( Clip ) AudioSystem.getLine( info );
        clip.open( audioStream );
        clip.start( );
    }

    public MusicPlayer( ) {

    }

    public void play( ) {
        clip.start( );
    }

    public void loop( ) {
        clip.loop( Clip.LOOP_CONTINUOUSLY );
    }

    public void close( ) {
        try {
            clip.close( );
            audioStream.close( );
        } catch ( Exception e ) {
            e.printStackTrace( );
        }
    }
}
