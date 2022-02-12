using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MessageCheckpoint : MonoBehaviour
{
    #region Trait / ability varibles
    public static int VisibleCards;
    int ResDur;
    #endregion

    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;


    // I dont know what I am doing
    public bool[] Player2Card = new bool[120];
    public bool[] Player2CardVisible = new bool[120];

    // temp
    int[] StorageTemp = new int[2];

    public static void Restart()
    {
        VisibleCards = 0;
    }

    // *REMEMBER* Awake is when the object is inzlied, so DIFFERENT from Start
    void Awake()
    {
        if (DeckChooser.P2Deck == "Spindle")
        {
            StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[0] + 1;
            ApplyStatsP2(StorageTemp);
            StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[1] + 1;
            ApplyStatsP2(StorageTemp);
            StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[2] + 1;
            ApplyStatsP2(StorageTemp);
            StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[3] + 1;
            ApplyStatsP2(StorageTemp);
            if (SpawnDeckList.SpindleDeckStarter.Length >= 5)
            {
                StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[4] + 1;
                ApplyStatsP2(StorageTemp);
            }
            if (SpawnDeckList.SpindleDeckStarter.Length >= 6)
            {
                StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[5] + 1;
                ApplyStatsP2(StorageTemp);
            }
            if (SpawnDeckList.SpindleDeckStarter.Length >= 7)
            {
                StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[6] + 1;
                ApplyStatsP2(StorageTemp);
            }
            if (SpawnDeckList.SpindleDeckStarter.Length >= 8)
            {
                StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[7] + 1;
                ApplyStatsP2(StorageTemp);
            }
            if (SpawnDeckList.SpindleDeckStarter.Length >= 9)
            {
                StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[8] + 1;
                ApplyStatsP2(StorageTemp);
            }
            if (SpawnDeckList.SpindleDeckStarter.Length >= 10)
            {
                StorageTemp[1] = SpawnDeckList.SpindleDeckStarter[4] + 1;
                ApplyStatsP2(StorageTemp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Player2NotFull(int ID)
    {
        Player2Card[ID] = false;
        Debug.Log("Player2Card " + ID + " is not full");

        if (Player2CardVisible[ID] == true)
        {
            Player2CardVisible[ID] = false;
            VisibleCards -= 1;
        }
    }

    void SendBlock(int OriginID)
    {
        BroadcastMessage("Block", OriginID);
    }

    void ApplyStatsP2(int[] TempStorage)
    {
        #region I am Icaurs
        if (Player2Card[0] == false)
        {
            TempStorage[0] = 0;
        }
        else if (Player2Card[1] == false)
        {
            TempStorage[0] = 1;
        }
        else if (Player2Card[2] == false)
        {
            TempStorage[0] = 2;
        }
        else if (Player2Card[3] == false)
        {
            TempStorage[0] = 3;
        }
        else if (Player2Card[4] == false)
        {
            TempStorage[0] = 4;
        }
        else if (Player2Card[5] == false)
        {
            TempStorage[0] = 5;
        }
        else if (Player2Card[6] == false)
        {
            TempStorage[0] = 6;
        }
        else if (Player2Card[7] == false)
        {
            TempStorage[0] = 7;
        }
        else if (Player2Card[8] == false)
        {
            TempStorage[0] = 8;
        }
        else if (Player2Card[9] == false)
        {
            TempStorage[0] = 9;
        }
        else if (Player2Card[10] == false)
        {
            TempStorage[0] = 10;
        }
        else if (Player2Card[11] == false)
        {
            TempStorage[0] = 11;
        }
        else if (Player2Card[12] == false)
        {
            TempStorage[0] = 12;
        }
        else if (Player2Card[13] == false)
        {
            TempStorage[0] = 13;
        }
        else if (Player2Card[14] == false)
        {
            TempStorage[0] = 14;
        }
        else if (Player2Card[15] == false)
        {
            TempStorage[0] = 15;
        }
        else if (Player2Card[16] == false)
        {
            TempStorage[0] = 16;
        }
        else if (Player2Card[17] == false)
        {
            TempStorage[0] = 17;
        }
        else if (Player2Card[18] == false)
        {
            TempStorage[0] = 18;
        }
        else if (Player2Card[19] == false)
        {
            TempStorage[0] = 19;
        }
        else if (Player2Card[20] == false)
        {
            TempStorage[0] = 20;
        }
        else if (Player2Card[21] == false)
        {
            TempStorage[0] = 21;
        }
        else if (Player2Card[22] == false)
        {
            TempStorage[0] = 22;
        }
        else if (Player2Card[23] == false)
        {
            TempStorage[0] = 23;
        }
        else if (Player2Card[24] == false)
        {
            TempStorage[0] = 24;
        }
        else if (Player2Card[25] == false)
        {
            TempStorage[0] = 25;
        }
        else if (Player2Card[26] == false)
        {
            TempStorage[0] = 26;
        }
        else if (Player2Card[27] == false)
        {
            TempStorage[0] = 27;
        }
        else if (Player2Card[28] == false)
        {
            TempStorage[0] = 28;
        }
        else if (Player2Card[29] == false)
        {
            TempStorage[0] = 29;
        }
        else if (Player2Card[30] == false)
        {
            TempStorage[0] = 30;
        }
        else if (Player2Card[31] == false)
        {
            TempStorage[0] = 31;
        }
        else if (Player2Card[32] == false)
        {
            TempStorage[0] = 32;
        }
        else if (Player2Card[33] == false)
        {
            TempStorage[0] = 33;
        }
        else if (Player2Card[34] == false)
        {
            TempStorage[0] = 34;
        }
        else if (Player2Card[35] == false)
        {
            TempStorage[0] = 35;
        }
        else if (Player2Card[36] == false)
        {
            TempStorage[0] = 36;
        }
        else if (Player2Card[37] == false)
        {
            TempStorage[0] = 37;
        }
        else if (Player2Card[38] == false)
        {
            TempStorage[0] = 38;
        }
        else if (Player2Card[39] == false)
        {
            TempStorage[0] = 39;
        }
        else if (Player2Card[40] == false)
        {
            TempStorage[0] = 40;
        }
        else if (Player2Card[41] == false)
        {
            TempStorage[0] = 41;
        }
        else if (Player2Card[42] == false)
        {
            TempStorage[0] = 42;
        }
        else if (Player2Card[43] == false)
        {
            TempStorage[0] = 43;
        }
        else if (Player2Card[44] == false)
        {
            TempStorage[0] = 44;
        }
        else if (Player2Card[45] == false)
        {
            TempStorage[0] = 45;
        }
        else if (Player2Card[46] == false)
        {
            TempStorage[0] = 46;
        }
        else if (Player2Card[47] == false)
        {
            TempStorage[0] = 47;
        }
        else if (Player2Card[48] == false)
        {
            TempStorage[0] = 48;
        }
        else if (Player2Card[49] == false)
        {
            TempStorage[0] = 49;
        }
        else if (Player2Card[50] == false)
        {
            TempStorage[0] = 50;
        }
        else if (Player2Card[51] == false)
        {
            TempStorage[0] = 51;
        }
        else if (Player2Card[52] == false)
        {
            TempStorage[0] = 52;
        }
        else if (Player2Card[53] == false)
        {
            TempStorage[0] = 53;
        }
        else if (Player2Card[54] == false)
        {
            TempStorage[0] = 54;
        }
        else if (Player2Card[55] == false)
        {
            TempStorage[0] = 55;
        }
        else if (Player2Card[56] == false)
        {
            TempStorage[0] = 56;
        }
        else if (Player2Card[57] == false)
        {
            TempStorage[0] = 57;
        }
        else if (Player2Card[58] == false)
        {
            TempStorage[0] = 58;
        }
        else if (Player2Card[59] == false)
        {
            TempStorage[0] = 59;
        }
        else if (Player2Card[60] == false)
        {
            TempStorage[0] = 60;
        }
        else if (Player2Card[61] == false)
        {
            TempStorage[0] = 61;
        }
        else if (Player2Card[62] == false)
        {
            TempStorage[0] = 62;
        }
        else if (Player2Card[63] == false)
        {
            TempStorage[0] = 63;
        }
        else if (Player2Card[64] == false)
        {
            TempStorage[0] = 64;
        }
        else if (Player2Card[65] == false)
        {
            TempStorage[0] = 65;
        }
        else if (Player2Card[66] == false)
        {
            TempStorage[0] = 66;
        }
        else if (Player2Card[67] == false)
        {
            TempStorage[0] = 67;
        }
        else if (Player2Card[68] == false)
        {
            TempStorage[0] = 68;
        }
        else if (Player2Card[69] == false)
        {
            TempStorage[0] = 69;
        }
        else if (Player2Card[70] == false)
        {
            TempStorage[0] = 70;
        }
        else if (Player2Card[71] == false)
        {
            TempStorage[0] = 71;
        }
        else if (Player2Card[72] == false)
        {
            TempStorage[0] = 72;
        }
        else if (Player2Card[73] == false)
        {
            TempStorage[0] = 73;
        }
        else if (Player2Card[74] == false)
        {
            TempStorage[0] = 74;
        }
        else if (Player2Card[75] == false)
        {
            TempStorage[0] = 75;
        }
        else if (Player2Card[76] == false)
        {
            TempStorage[0] = 76;
        }
        else if (Player2Card[77] == false)
        {
            TempStorage[0] = 77;
        }
        else if (Player2Card[78] == false)
        {
            TempStorage[0] = 78;
        }
        else if (Player2Card[79] == false)
        {
            TempStorage[0] = 79;
        }
        else if (Player2Card[80] == false)
        {
            TempStorage[0] = 80;
        }
        else if (Player2Card[81] == false)
        {
            TempStorage[0] = 81;
        }
        else if (Player2Card[82] == false)
        {
            TempStorage[0] = 82;
        }
        else if (Player2Card[83] == false)
        {
            TempStorage[0] = 83;
        }
        else if (Player2Card[84] == false)
        {
            TempStorage[0] = 84;
        }
        else if (Player2Card[85] == false)
        {
            TempStorage[0] = 85;
        }
        else if (Player2Card[86] == false)
        {
            TempStorage[0] = 86;
        }
        else if (Player2Card[87] == false)
        {
            TempStorage[0] = 87;
        }
        else if (Player2Card[88] == false)
        {
            TempStorage[0] = 88;
        }
        else if (Player2Card[89] == false)
        {
            TempStorage[0] = 89;
        }
        else if (Player2Card[90] == false)
        {
            TempStorage[0] = 90;
        }
        else if (Player2Card[91] == false)
        {
            TempStorage[0] = 91;
        }
        else if (Player2Card[92] == false)
        {
            TempStorage[0] = 92;
        }
        else if (Player2Card[93] == false)
        {
            TempStorage[0] = 93;
        }
        else if (Player2Card[94] == false)
        {
            TempStorage[0] = 94;
        }
        else if (Player2Card[95] == false)
        {
            TempStorage[0] = 95;
        }
        else if (Player2Card[96] == false)
        {
            TempStorage[0] = 96;
        }
        else if (Player2Card[97] == false)
        {
            TempStorage[0] = 97;
        }
        else if (Player2Card[98] == false)
        {
            TempStorage[0] = 98;
        }
        else if (Player2Card[99] == false)
        {
            TempStorage[0] = 99;
        }
        else if (Player2Card[100] == false)
        {
            TempStorage[0] = 100;
        }
        else if (Player2Card[101] == false)
        {
            TempStorage[0] = 101;
        }
        else if (Player2Card[102] == false)
        {
            TempStorage[0] = 102;
        }
        else if (Player2Card[103] == false)
        {
            TempStorage[0] = 103;
        }
        else if (Player2Card[104] == false)
        {
            TempStorage[0] = 104;
        }
        else if (Player2Card[105] == false)
        {
            TempStorage[0] = 105;
        }
        else if (Player2Card[106] == false)
        {
            TempStorage[0] = 106;
        }
        else if (Player2Card[107] == false)
        {
            TempStorage[0] = 107;
        }
        else if (Player2Card[108] == false)
        {
            TempStorage[0] = 108;
        }
        else if (Player2Card[109] == false)
        {
            TempStorage[0] = 109;
        }
        else if (Player2Card[110] == false)
        {
            TempStorage[0] = 110;
        }
        else if (Player2Card[111] == false)
        {
            TempStorage[0] = 111;
        }
        else if (Player2Card[112] == false)
        {
            TempStorage[0] = 112;
        }
        else if (Player2Card[113] == false)
        {
            TempStorage[0] = 113;
        }
        else if (Player2Card[114] == false)
        {
            TempStorage[0] = 114;
        }
        else if (Player2Card[115] == false)
        {
            TempStorage[0] = 115;
        }
        else if (Player2Card[116] == false)
        {
            TempStorage[0] = 116;
        }
        else if (Player2Card[117] == false)
        {
            TempStorage[0] = 117;
        }
        else if (Player2Card[118] == false)
        {
            TempStorage[0] = 118;
        }
        else
        {
            Debug.LogError("<color=red>Error:</color> Either I messed up the script or you somehow have 120 cards on one side and you want more");
        }
        #endregion

        Player2Card[TempStorage[0]] = true;
        VisibleCards += 1;

        BroadcastMessage("ReciveGooStats", TempStorage);
    }

    void TimePassing()
    {
        ResDur -= 1;
        if (ResDur == 0)
        {
            BroadcastMessage("StopRes");
        }
    }

    #region Abilities
    void Spawn___(int id)
    {
        StorageTemp[1] = id + 1;
        ApplyStatsP2(StorageTemp);
        SendMessageUpwards("LazyPassTurn");
    }

    void Inhabit___(int id)
    {
        BroadcastMessage("Inhabit", id + 1);
    }

    void InhabitingMessage()
    {
        BroadcastMessage("Inhabitingg");
    }

    void RefreshCard(int id)
    {
        BroadcastMessage("RefreshCcard", id + 1);
    }

    void RefreshSpecies(string Species)
    {
        BroadcastMessage("RefreshSpices", Species);
    }

    void SendRefresh()
    {
        BroadcastMessage("Refresh");
    }

    void TtrapLay()
    {
        BroadcastMessage("TttrapLay");
    }

    void TtttrapLay()
    {
        StorageTemp[1] = 1 + 1;
        ApplyStatsP2(StorageTemp);
    }

    void Ccannibalize()
    {
        Debug.Log("Chose the card that will gain HP");
        SendMessageUpwards("MiscText", "Chose the card that will gain HP");
        BroadcastMessage("Cccannibalize");
    }

    void Ccccannibalize()
    {
        Debug.Log("Chose the card that will be eaten");
        SendMessageUpwards("MiscText", "Chose the card that will be eaten");
        BroadcastMessage("Cccccannibalize");
    }

    void Ccccccannibalize(int HeP)
    {
        BroadcastMessage("GainHeP", HeP);
    }

    void ResSpeciesCard(object[] Stats)
    {
        ResDur = Convert.ToInt32(Stats[0]);
        BroadcastMessage("RresSpeciesCard", Stats);
    }

    void SendSongOfVenom()
    {
        BroadcastMessage("SongOfVenom");
    }

    #endregion

    #region Traits
    void NotVisible(int[] ID)
    {
        Player2CardVisible[ID[1]] = false;
        VisibleCards -= 1;
    }
    #endregion
}