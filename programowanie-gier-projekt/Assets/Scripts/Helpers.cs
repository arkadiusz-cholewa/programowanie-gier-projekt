using UnityEngine;

namespace Assets.Scripts
{
    public class Helpers
    {
        public static float GetRandomXPosition() => Random.Range(Constants.MinX, Constants.MaxX);
        public static float GetRandomYPosition() => Random.Range(Constants.MinY, Constants.MaxY);
    }
}