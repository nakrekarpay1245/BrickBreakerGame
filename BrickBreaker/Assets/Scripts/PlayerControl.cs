using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed;

    [SerializeField]
    private float maxX;

    [SerializeField]
    private float minX;

    [SerializeField]
    private float controlType;

    LevelController levelController;

    private void Awake()
    {
        levelController = GameObject.FindObjectOfType<LevelController>();
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
           transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit) && Input.GetKey(KeyCode.Mouse0))
        {
            levelController.GameStarted();
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(raycastHit.point.x * controlType, transform.position.y, transform.position.z),
                Time.deltaTime * horizontalSpeed);
        }
    }

    //public void IncreaseScale()
    //{
    //    this.gameObject.transform.localScale *= 2;
    //}
    //public void InvertControl()
    //{
    //    controlType *= -1;
    //}
}
