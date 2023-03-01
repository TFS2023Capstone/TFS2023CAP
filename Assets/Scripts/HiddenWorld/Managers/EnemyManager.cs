using HiddenWorld.Scriptables;
using HiddenWorld.Systems;
using UnityEngine;

namespace HiddenWorld.Managers
{
    /// <summary>
    /// An example of a scene-specific manager grabbing resources from the resource system
    /// Scene-specific managers are things like grid managers, unit managers, environment managers etc
    /// </summary>
    public class EnemyManager : StaticInstance<EnemyManager>
    {

        public void SpawnHeroes()
        {
            SpawnUnit(EnemyType.Walker, new Vector3(1, 0, 0));
        }

        void SpawnUnit(EnemyType t, Vector3 pos)
        {
            var Scriptable = ResourceSystem.Instance.GetSpecificEnemy(t);

            var spawned = Instantiate(Scriptable.Prefab, pos, Quaternion.identity, transform);

            // Apply possible modifications here such as potion boosts, team synergies, etc
            var stats = Scriptable.BaseStats;
            stats.Health += 20;

            spawned.SetStats(stats);
        }
    }
}
