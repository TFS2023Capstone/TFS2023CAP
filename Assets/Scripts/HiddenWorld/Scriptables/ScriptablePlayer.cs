using System;
using System.Collections.Generic;
using UnityEngine;

namespace HiddenWorld.Scriptables
{
    /// <summary>
    /// Create a scriptable hero 
    /// </summary>
    [CreateAssetMenu(fileName = "ScriptableObjects")]
    public class ScriptablePlayer : ScriptableUnitBase
    {
        public List<Item> Items;
    }

    [Serializable]
    public enum Item
    {
        Spyglass = 0,
        Compass = 1
    }
}


