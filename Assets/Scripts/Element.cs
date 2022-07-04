using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
    public string name;
    public string symbol;
    public int atomicNum;

    public Element(string name, string symbol, int atomicNum)
    {
        this.name = name;
        this.symbol = symbol;
        this.atomicNum = atomicNum;
    }

    public string getName()
    {
        return this.name;
    }

    public string getSymbol()
    {
        return this.symbol;
    }

    public int getNum()
    {
        return this.atomicNum;
    }
    
}
