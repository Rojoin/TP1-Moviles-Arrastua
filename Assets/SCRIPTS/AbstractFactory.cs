using UnityEngine;


public class AbstractFactory
{
    static AbstractFactory instance;
    public static AbstractFactory Instance
    {
        get
        {
            if (instance == null)
                instance = new AbstractFactory();

            return instance;
        }
    }

    public GameObject CreateGameObject(GameObject prefab, Transform transform, Transform parent)
    {
        return GameObject.Instantiate(prefab, position: transform.position, transform.rotation, parent);
    }
}