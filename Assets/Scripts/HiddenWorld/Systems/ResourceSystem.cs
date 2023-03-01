using HiddenWorld.Scriptables;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HiddenWorld.Systems
{
    /// <summary>
    /// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
    /// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
    /// If you don't feel free to make this a standard class
    /// </summary>
    public class ResourceSystem : StaticInstance<ResourceSystem>
    {
        public List<ScriptableEnemy> Enemies { get; private set; }
        private Dictionary<EnemyType, ScriptableEnemy> _EnemyDict;

        protected override void Awake()
        {
            base.Awake();
            AssembleResources();
        }

        private void AssembleResources()
        {
            Enemies = Resources.LoadAll<ScriptableEnemy>("ExampleHeroes").ToList();
            _EnemyDict = Enemies.ToDictionary(r => r.EnemyType, r => r);
        }

        public ScriptableEnemy GetSpecificEnemy(EnemyType t) => _EnemyDict[t];
        public ScriptableEnemy GetRandomEnemy() => Enemies[Random.Range(0, Enemies.Count)];
    }
}
