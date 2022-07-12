using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private Checkpoint _lastCheckpoint;

        public static Player Player { get; private set; }

        public GameManager()
            : base()
        {
            Player = Player != null ? Player : FindObjectOfType<Player>();
        }

        public void ChangeCheckpoint(Checkpoint checkpoint)
        {
            _lastCheckpoint = checkpoint;
        }

        public void ToLastCheckpoint()
        {
            Player.Spawn(_lastCheckpoint);
        }
    }
}