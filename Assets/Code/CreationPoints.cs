using UnityEngine;

public class CreationPoints : MonoBehaviour
{
    public static Transform[] creationpoints;
    public static int pointsSize;
	void Awake()
	{
		creationpoints = new Transform[transform.childCount];
        pointsSize = creationpoints.Length;
		for(int i = 0; i < pointsSize; i++)
        {
			creationpoints[i] = transform.GetChild(i);
        }
        
	}
}
