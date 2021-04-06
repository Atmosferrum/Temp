using UnityEngine;
using System.Reflection;

/// <summary>
/// Player Stas prototype (GET Player Stats form names of Variables) 
/// </summary>
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    PropertyInfo[] piArray;

    [System.Serializable]
    public class PStats
    {
        //Base Stats
        public int PlayerLvl { get; set; }
        public int Killed { get; set; }
        public int Died { get; set; }
        public int Dealt { get; set; }
        public int Recived { get; set; }
        public int TimeSpent { get; set; }
        public int Complete { get; set; }
        public int Distance { get; set; }
        //Deffence Stats
        public int HP { get; set; }
        public int Dodge { get; set; }
        public int Leech { get; set; }
        public int MoveSpd { get; set; }
        public int WindRes { get; set; }
        public int FireRes { get; set; }
        public int EarthRes { get; set; }
        public int WaterRes { get; set; }
        //Offence Stats
        public int Dmg { get; set; }
        public int CChance { get; set; }
        public int CDmg { get; set; }
        public int AttackSpd { get; set; }
        public int WindDmg { get; set; }
        public int FireDmg { get; set; }
        public int EarthDmg { get; set; }
        public int WaterDmg { get; set; }
    }

    public PStats pstats = new PStats();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }        

        piArray = pstats.GetType().GetProperties();

        foreach (PropertyInfo p in piArray)
        {
            if(p.Name == "HP")
                if (PlayerPrefs.GetInt(p.Name) == 0 || !PlayerPrefs.HasKey(p.Name))
                    p.SetValue(pstats, 25);
                else
                    p.SetValue(pstats, PlayerPrefs.GetInt(p.Name));
            else if(p.Name == "Dmg")
            {
                if (PlayerPrefs.GetInt(p.Name) == 0 || !PlayerPrefs.HasKey(p.Name))
                    p.SetValue(pstats, 5);
                else
                    p.SetValue(pstats, PlayerPrefs.GetInt(p.Name));
            }
            else
            {
                if (PlayerPrefs.GetInt(p.Name) == 0 || !PlayerPrefs.HasKey(p.Name))
                    p.SetValue(pstats, 1);
                else
                    p.SetValue(pstats, PlayerPrefs.GetInt(p.Name));
            }
                
        }
    }

    private void Start()
    {
        foreach (PropertyInfo p in piArray)
        {
            GameData.Instance.SavePlayerStats(p.Name);
        }
    }

    /// <summary>
    /// GET Player Stat by Variable name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public int pstatCalc(string name)
    {
        return (int)pstats.GetType().GetProperty(name).GetValue(pstats);
    }
}
