package screens;

import logic.NPC;

import java.io.File;
import java.io.FileNotFoundException;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Scanner;

public class Dialogue {
    NPC npc;
    String fileName;
    int position;


    public Dialogue(NPC npc, String fileName) {
        this.npc = npc;
        this.fileName = fileName;
    }

    public void init(){
        try {
            File file = new File(fileName);
            Scanner scn = new Scanner(file);
            while (scn.hasNextLine()) {
                String data = scn.nextLine();
                System.out.println(data);
            }
            scn.close();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }
}
