using Menu;
using UnityEngine;

public class InitializeGame : MonoBehaviour
{
    public MenuBuilder MenuBuilder;

    void Start()
    {
        MenuBuilder.Build(gameObject, Random.seed);
    }
}