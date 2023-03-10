using System.IO;
[System.Serializable]

public class PlayerStats
{
    public string name;
    public int maxHealth;
    public int attackDmg;
    public int score;

    public PlayerStats() 
    {
        //Default Values
        this.attackDmg = 12;
        this.maxHealth = 100;
        this.name = "Player";
        this.score = 0;
    }

    public PlayerStats(string playerName, int maxHealth, int attackDmg, int score) 
    {
        this.score = score;
        this.name = playerName;
        this.maxHealth = maxHealth;
        this.attackDmg = attackDmg;
    }
}
