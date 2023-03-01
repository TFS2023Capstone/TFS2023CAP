using System;
using UnityEngine;

namespace HiddenWorld.Scriptables
{
    /// <summary>
    /// Create a scriptable hero 
    /// </summary>
    [CreateAssetMenu(fileName = "ScriptableObjects")]
    public class ScriptableEnemy : ScriptableUnitBase
    {
        public EnemyType EnemyType;
    }

    [Serializable]
    public enum EnemyType
    {
        Walker = 0,
        Turret = 1
    }
}

