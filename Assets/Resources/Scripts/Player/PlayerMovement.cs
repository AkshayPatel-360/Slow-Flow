using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //privates
    private float currentDistance; //the distance from the mouse and ball
    private float goodSpace; //the right amount of space between 0 - max distance
    private float shootPower; //the power when release mouse click
    private Vector3 shootDirection; //derection to shoot
    private LineRenderer line; //use to generate line
    private Transform MainCam; //use to make camera follow ball
    private RaycastHit hitInfo; //for raycasting. enable mouse position to be 3D and not 2D
    private Vector3 currentMousePosition; //the current mouse position
    private Vector3 temp;
    private bool playerClick;
    private bool isLaunched;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;
    public GameObject playerFive;
    public GameObject playerSix;
    public GameObject playerSeven;
    public GameObject playerEight;
    public GameObject blueTeamTerrain;
    public GameObject redTeamTerrain;
    public GameObject redWins;
    public GameObject blueWins;

    //publics
    [Header("The Layer/layers the floors are on")]
    public LayerMask groundLayers;
    [Header("Max pull distance")]
    public float maxDistance = 3f;
    [Header("Power")]
    public float power;
    [Header("The colors for your Line Renderer")]
    public Color StartColor;
    public Color EndColor;
    [Header("Custom camera offset")]
    public Vector3 CamOffset = new Vector3(0, 7, -15);
    [Header("Should the camera follow the ball?")]
    public bool CameraFollowBall;
    [Header("Camera follow speed")]
    public float smoothSpeed = 10.0f;

    public void Update()
    {
      
    }
    private void Awake()
    {
        //lets find what we need in the game and components
        line = GetComponent<LineRenderer>(); //set line renderer

        //get the main camera with tag if follow ball 
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void OnMouseDown()
    {
        if (playerClick == false)
        {

            //enable toe first point of the line
            line.enabled = true;
            //the line begins at this target position
            line.SetPosition(0, transform.position);
        }
    }

    private void OnMouseDrag()
    {
        if (playerClick == false)
        {
            currentDistance = Vector3.Distance(currentMousePosition, transform.position); //update the current distcance
            //lets make sure we dont go pass max distance
            if (currentDistance <= maxDistance)
            {
                temp = currentMousePosition; //saving the current possion while dragin is allowed
                goodSpace = currentDistance;
                line.startColor = StartColor; //set the starting color of the line
            }
            else
            {
                temp = new Vector3(currentMousePosition.x, currentMousePosition.y, temp.z); // dont go any further
                goodSpace = maxDistance;
            }
            //assign the shoot power and times it by your desired power
            shootPower = Mathf.Abs(goodSpace) * power;

            //get mouse position over the floor - when we drag the mouse position will be allow the x y and Z in 3D :) Yay!
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, groundLayers))
            {
                currentMousePosition = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
            }

            //calculate the shoot Direction
            shootDirection = Vector3.Normalize(currentMousePosition - transform.position);
            //handle line drawing and colors

            ///update the line while we drag
            line.SetPosition(1, temp);

        }
    }

    private void OnMouseUp()
    {
        if (playerClick == false)
        {
            Vector3 push = shootDirection * shootPower * -1; //force in the correct direction
            GetComponent<Rigidbody>().AddForce(push, ForceMode.Impulse);
            line.enabled = false; //remove the line
            playerClick = true;
            //CameraFollowBall = true;
            //Debug.Log(gameObject.name);
            if (playerClick = true && gameObject.name == "Player1")
            {
                Invoke("ActivatePlayerTwo", 4f);
            }
            if (playerClick = true && gameObject.name == "Player2")
            {
                Invoke("ActivatePlayerThree", 4f);
            }
            if (playerClick = true && gameObject.name == "Player3")
            {
                Invoke("ActivatePlayerFour", 4f);
            }
            if (playerClick = true && gameObject.name == "Player4")
            {
                Invoke("ActivatePlayerFive", 4f);
            }
            if (playerClick = true && gameObject.name == "Player5")
            {
                Invoke("ActivatePlayerSix", 4f);
            }
            if (playerClick = true && gameObject.name == "Player6")
            {
                Invoke("ActivatePlayerSeven", 4f);
            }
            if (playerClick = true && gameObject.name == "Player7")
            {

                Invoke("ActivatePlayerEight", 4f);
            }
            if (playerClick = true && gameObject.name == "Player8")
            {
                Invoke("WinLose", 4f);
            }
        }
    }

    private void ActivatePlayerTwo()
    {
        playerTwo.SetActive(true);
        //MainCam.Rotate(new Vector3(90, 0, 180));
        //redTeamTerrain.SetActive(true);
        //blueTeamTerrain.SetActive(false);
    }
    private void ActivatePlayerThree()
    {
        playerThree.SetActive(true);
        //redTeamTerrain.SetActive(false);
        //blueTeamTerrain.SetActive(true);
    }
    private void ActivatePlayerFour()
    {
        playerFour.SetActive(true);
        //redTeamTerrain.SetActive(true);
        //blueTeamTerrain.SetActive(false);
    }
    private void ActivatePlayerFive()
    {
        playerFive.SetActive(true);
        //redTeamTerrain.SetActive(true);
        //blueTeamTerrain.SetActive(false);
    }
    private void ActivatePlayerSix()
    {
        playerSix.SetActive(true);
        //redTeamTerrain.SetActive(true);
        //blueTeamTerrain.SetActive(false);
    }
    private void ActivatePlayerSeven()
    {
        playerSeven.SetActive(true);
        //redTeamTerrain.SetActive(true);
        //blueTeamTerrain.SetActive(false);
    }
    private void ActivatePlayerEight()
    {
        playerEight.SetActive(true);
        //redTeamTerrain.SetActive(true);
        //blueTeamTerrain.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(gameObject.name + other.name);
            Destroy(gameObject);
            if (gameObject.name == "Player1" && !playerTwo.activeSelf)
            {
                playerTwo.SetActive(true);
            }

            if (gameObject.name == "Player2" && !playerThree.activeSelf)
            {
                playerThree.SetActive(true);
            }

            if (gameObject.name == "Player3" && !playerFour.activeSelf)
            {
                playerFour.SetActive(true);
            }

            if (gameObject.name == "Player4" && !playerFive.activeSelf)
            {
                playerFive.SetActive(true);
            }

            if (gameObject.name == "Player5" && !playerSix.activeSelf)
            {
                playerSix.SetActive(true);
            }

            if (gameObject.name == "Player6" && !playerSeven.activeSelf)
            {
                playerSeven.SetActive(true);
            }

            if (gameObject.name == "Player7" && !playerEight.activeSelf)
            {
                playerEight.SetActive(true);
            }
            //restartButton.SetActive(true);
        }

    }

    
    private void LateUpdate()
    {
        if (CameraFollowBall)
        {
            //position for camera to follow with offset.
            Vector3 desiredPosition = transform.position + CamOffset;
            // camera follow balll
            MainCam.position = desiredPosition;
        }
        //change color gradualy base of how far you drag
        line.endColor = Color.Lerp(StartColor, EndColor, currentDistance / maxDistance);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Launch Zone"))
        {
            isLaunched = true;
            Debug.Log("Ball has launched");

        }

    }


}










































/*endPos = camera.ScreenToWorldPoint(Input.mousePosition) + camaraOffSet;
line.SetPosition(1, endPos);
// line.SetPosition(1, transform.position + transform.forward * 4f);


//playerRB.velocity = transform.forward * shootPower;*/

/*if(line == null)
            {
                
                line = GetComponent<LineRenderer>();

            }
            line.positionCount = 2;
            startPos = camera.ScreenToWorldPoint(Input.mousePosition);
            line.SetPosition(0, startPos);
            line.useWorldSpace = true;*/





/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


if (Physics.Raycast(ray, out hit))
{
    if (hit.collider.gameObject.tag == "Player")
    {
        canMove = true;
        player = hit.collider.gameObject;
        playerRB = player.GetComponent<Rigidbody>();
        *//* if (lr == null)
         {
             lr = gameObject.AddComponent<LineRenderer>();
         }
         lr.positionCount = 2;
         startPos = player.transform.position;

         lr.SetPosition(0, startPos);*//*

    }
    xRot += Input.GetAxis("Mouse X");
    yRot += Input.GetAxis("Mouse Y");
    transform.rotation = Quaternion.Euler(yRot, xRot, 0f);
    line.gameObject.SetActive(true);
    line.SetPosition(0, player.transform.position);

}
else
{

}*/