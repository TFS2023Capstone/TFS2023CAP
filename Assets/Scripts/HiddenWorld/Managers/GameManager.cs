using System;
using UnityEngine;

namespace HiddenWorld.Managers
{
    public class GameManager : StaticInstance<GameManager>
    {
        public static event Action<GameState> OnBeforeStateChanged;
        public static event Action<GameState> OnAfterStateChanged;

        public GameState State { get; private set; }

        // Kick the game off with the first state
        void Start() => ChangeState(GameState.Starting);

        public void ChangeState(GameState newState)
        {
            OnBeforeStateChanged?.Invoke(newState);

            State = newState;
            switch (newState)
            {
                case GameState.Starting:
                    HandleStarting();
                    break;
                case GameState.SpawningPlayer:
                    HandleSpawningHeroes();
                    break;
                case GameState.SpawningEnemies:
                    HandleSpawningEnemies();
                    break;
                case GameState.Win:
                    break;
                case GameState.Lose:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            OnAfterStateChanged?.Invoke(newState);

            Debug.Log($"New state: {newState}");
        }

        private void HandleStarting()
        {
            // Do some start setup, could be environment, cinematics etc

            // Eventually call ChangeState again with your next state

            ChangeState(GameState.SpawningPlayer);
        }

        private void HandleSpawningHeroes()
        {
            EnemyManager.Instance.SpawnHeroes();

            ChangeState(GameState.SpawningEnemies);
        }

        private void HandleSpawningEnemies()
        {

            // Spawn enemies

            ChangeState(GameState.NormalGameplay);
        }
    }

    [Serializable]
    public enum GameState
    {
        Starting = 0,
        SpawningPlayer = 1,
        SpawningEnemies = 2,
        NormalGameplay = 3,
        Win = 4,
        Lose = 5,
    }
}
