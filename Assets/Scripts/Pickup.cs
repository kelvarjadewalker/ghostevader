using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Editor Fields
    [SerializeField] private int pointsPerPickup;

    // External Functions
    public int PointsPerPickup()
    {
        return pointsPerPickup;
    }
}
