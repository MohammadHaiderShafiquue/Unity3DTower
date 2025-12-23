using System;
using UnityEngine;

[Serializable]
public class GraphData
{
    public Entry[] entries;
}

[Serializable]
public class Entry
{
    public string country;
    public float value;
}
