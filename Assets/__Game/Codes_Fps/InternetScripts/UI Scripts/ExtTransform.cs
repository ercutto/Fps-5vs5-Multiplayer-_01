
using UnityEngine;

public static class ExtTransform
{
   public static void DestroyChilderen(this Transform t,bool destroyImmidiatly = false)
    {
        foreach (Transform child in t)
        {
            if (destroyImmidiatly)
            {
                MonoBehaviour.DestroyImmediate(child.gameObject);
            }
           
            else
            {
                MonoBehaviour.Destroy(child.gameObject);
            }
        }
    }
}
