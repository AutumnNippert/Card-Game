package logic;

public class NPC {
    public enum Type {
        Friendly,
        Hostile
    }

    Type type;
    String name;
    int hp;

    public NPC(Type type, String name, int hp) {
        this.type = type;
        this.name = name;
        this.hp = hp;
    }

    public enum NPCs {
        LoreMaster(new NPC(Type.Friendly, "Ghernard of Logaria", 100));

        public NPC npc;

        NPCs(NPC npc) {
            this.npc = npc;
        }

    }

}
