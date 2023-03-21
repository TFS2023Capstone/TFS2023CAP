using UnityEngine;

namespace HiddenWorld.Helpers
{
    public interface ISnappable
    {
        void OnSnapped(Vector3 socketPosition);
    }
}
