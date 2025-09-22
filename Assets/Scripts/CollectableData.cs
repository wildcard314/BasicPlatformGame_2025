using UnityEngine;

public class CollectableData : MonoBehaviour
{
    public int collectableValue;

    public void destroyCollectable()
    {
        Destroy(this.gameObject);
    }

    public int getValue()
    {
        return collectableValue;
    }

}
