using UnityEngine;

public class TeleportingPlatformsScript : MonoBehaviour
{
    private float disappearingTimer = 0;
    public float groupOneTime;
    public float groupTwoTime;
    public GameObject groupOne;
    public GameObject groupTwo;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disappearingTimer <= groupOneTime)
        {
            disappearingTimer += Time.deltaTime;
            groupOne.SetActive(true);
            groupTwo.SetActive(false);


        }

        else if (disappearingTimer > groupOneTime)
        {
            if (disappearingTimer <= groupTwoTime)
            {
                disappearingTimer += Time.deltaTime;
                groupOne.SetActive(false);
                groupTwo.SetActive(true);

            }

            else if (disappearingTimer > groupTwoTime)
            {
                disappearingTimer = 0;
            }
        }


    }
}
