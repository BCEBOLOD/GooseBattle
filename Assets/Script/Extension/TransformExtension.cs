using UnityEngine;

public static class TransformExtension 
{
   public static void Destoy(this Transform transform)
    {
        Object.Destroy(transform.gameObject);
    }
    public static void DestoyParent(this Transform transform)
    {
        Object.Destroy(transform.parent.gameObject);
    }

    public static void Active(this Transform transform)
    {
        transform.gameObject.SetActive(true);
    }
    public static void Deactivate(this Transform transform)
    {
        transform.gameObject.SetActive(false);
    }
    public static void Active(this GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public static void Deactivate(this GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
