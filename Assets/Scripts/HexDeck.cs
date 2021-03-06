﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexDeck {

    List<HexTileData> deckList;
    Player owner;

    public List<HexTileData> DeckList
    {
        get
        {
            return deckList;
        }

        set
        {
            deckList = value;
        }
    }

    public HexDeck()
    {
        DeckList = new List<HexTileData>();
        BuildDeck();
        Shuffle();
    }

   

    public HexTileData GetNextHex()
    {
        if (DeckList.Count > 0)
        {
            HexTileData nextHex;
            nextHex = DeckList[0];
            //Debug.Log("Removing");
            DeckList.RemoveAt(0);
            UIManager.current.UpdateRemainingTiles();
            return nextHex;
            

        }
        else
        {

            return null;
        }

    }

    void BuildDeck()
    {
        int i = 0;
        //These are here incase i need to test the end of the game quickly
       //DeckList.Add(HexManager.current.HexPrototypes["King"].Clone());
       // DeckList.Add(HexManager.current.HexPrototypes["Queen"].Clone());
        
        
        foreach (KeyValuePair<string, HexTileData> proto in HexManager.current.HexPrototypes)
        {
            for (i = 0; i < proto.Value.numberInDeck; i++)
            {
                DeckList.Add(proto.Value.Clone());
            }
        
        }
        
        
    }

    void Shuffle()
    {
       //s System.Random _random = new System.Random();

        HexTileData temp;

        int n = DeckList.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
           // int r = i + (int)(_random.NextDouble() * (n - i));\
            int r = i + Random.Range(0, n-i);

            temp = DeckList[r];
            DeckList[r] = DeckList[i];
            DeckList[i] = temp;
        }
    }


}




