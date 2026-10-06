using UnityEngine;

public class ButtonPlaceBuild : MonoBehaviour
{
    public GameObject building;

    public void PlaceBuild()
    {
        Instantiate(building, Vector3.zero, Quaternion.Euler(0, 270, 0));
    }
}
