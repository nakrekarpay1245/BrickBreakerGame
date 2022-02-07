using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed;

    private Vector3 moveSpeed;

    private Vector3 startPosition;

    [SerializeField]
    private float scor;

    [SerializeField]
    private float health;

    [SerializeField]
    private float totalBricks;

    [SerializeField]
    private float brokenBricks;

    //bool isBallGreather;
    //bool isBallFaster;
    //bool isPaddleGreather;

    [SerializeField]
    private GameObject paddle;

    private LevelController levelController;

    [SerializeField]
    private Text levelFinishedTitle;

    [SerializeField]
    private GameObject levelFinishedPanel;

    [SerializeField]
    private GameObject retryButtonInFinishPanel;

    //private void Awake()
    //{
    //    levelController = GameObject.FindObjectOfType<LevelController>();
    //    retryButtonInFinishPanel.SetActive(false);
    //    levelFinishedPanel.SetActive(false);
    //}

    void Start()
    {
        //startPosition = transform.position;
        //totalBricks = levelController.staticProgres;
        BallStart();
    }

    private void BallStart()
    {
        //transform.position = startPosition;
        moveSpeed = new Vector3(Random.Range(1, speed.x), 0, Random.Range(1, speed.z));
    }
    void FixedUpdate()
    {
        transform.Translate(moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            if (Mathf.Abs(transform.position.x - other.gameObject.transform.position.x) > 0.25f)
            {
                moveSpeed.x = -moveSpeed.x;
            }

            if (Mathf.Abs(transform.position.z - other.gameObject.transform.position.z) > 0.25f)
            {
                moveSpeed.z = -moveSpeed.z;
            }
            other.gameObject.GetComponent<Collider>().enabled = false;
            Destroy(other.gameObject);
            //other.gameObject.GetComponent<Brick>().Function(this);
            IncreaseScor();
        }

        if (other.gameObject.CompareTag("RightWall"))
        {
            moveSpeed.x = -moveSpeed.x;
        }

        if (other.gameObject.CompareTag("LeftWall"))
        {
            moveSpeed.x = -moveSpeed.x;
        }

        if (other.gameObject.CompareTag("UpWall"))
        {
            moveSpeed.z = -moveSpeed.z;
        }

        if (other.gameObject.CompareTag("DownWall"))
        {
            moveSpeed = Vector3.zero;
            //levelFinishedTitle.text = "You Lose !";
            //retryButtonInFinishPanel.SetActive(true);
            //levelFinishedPanel.SetActive(true);
        }

        if (other.gameObject.CompareTag("Paddle"))
        {
            moveSpeed.z = -moveSpeed.z;
            moveSpeed.x = moveSpeed.x + other.relativeVelocity.x;
        }
    }

    private void IncreaseScor()
    {
        scor++;
        //if (brokenBricks == totalBricks)
        //{
        //    Debug.Log("You Win !");
        //    levelFinishedTitle.text = "You Win !";
        //}
        //levelController.IncreaseProgress();
    }

    //public void IncreasePaddleScale()
    //{
    //    if (!isPaddleGreather)
    //    {
    //        isPaddleGreather = true;
    //        paddle.GetComponent<PlayerControl>().IncreaseScale();
    //    }
    //}

    //public void IncreaseBallSpeed()
    //{
    //    if (!isBallFaster)
    //    {
    //        isBallFaster = true;
    //        moveSpeed *= 2;
    //    }
    //}

    //public void InvertPaddleControl()
    //{
    //    paddle.GetComponent<PlayerControl>().InvertControl();
    //}

    //public void IncreaseBallScale()
    //{
    //    if (!isBallGreather)
    //    {
    //        isBallGreather = true;
    //        this.transform.localScale *= 2;
    //    }
    //}
}
