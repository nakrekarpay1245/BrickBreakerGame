using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform generateTransform;

    [SerializeField]
    private GameObject[] brickPrefabs;

    Vector3 generatePosition;

    [SerializeField]
    private GameObject bricks;
    void Start()
    {
        generatePosition = generateTransform.position;
        GenerateBricks();
    }

    void GenerateBricks()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject currentBrick =
                    Instantiate(brickPrefabs[Random.Range(0, brickPrefabs.Length)], bricks.transform);

                currentBrick.transform.position = generatePosition;

                generatePosition = new Vector3(generatePosition.x + 0.5f,
                   0, generatePosition.z);
            }
            generatePosition = new Vector3(generateTransform.position.x,
                0, generatePosition.z + 0.5f);
        }
    }
}
