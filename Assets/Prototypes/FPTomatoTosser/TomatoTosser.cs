using UnityEngine;

public class TomatoTosser : MonoBehaviour
{
    Vector3 startingLocalPosition;
    [SerializeField]
    Vector3 offsetFullyCharged;
    [SerializeField]
    float offsetAngleDegrees;

    [SerializeField]
    private GameObject tomatoThrowablePrefab;
    [SerializeField]
    private Transform throwPoint;
    [SerializeField]
    private float maxThrowLift = 5;
    [SerializeField]
    private float maxThrowForce = 10;
    [SerializeField]
    private float minThrowForce = 2;
    [SerializeField]
    private GameObject handTomatoSceneObject;

    bool isCharging = false;
    float chargedPercent = 0;
    [SerializeField]
    private float chargeRate = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        startingLocalPosition = transform.localPosition;    
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCharging)
        {
            if (chargedPercent > 0)
            {
                chargedPercent -= Time.deltaTime * chargeRate;
                if (chargedPercent <= 0)
                {
                    chargedPercent = 0;
                    //handTomatoSceneObject.SetActive(true);
                }
                OffsetUpdate();
            }
        }
        else
        {
            Charging();
        }
    }

    public void BeginCharging()
    {
        isCharging = true;
        chargedPercent = 0;
    }

    private void Charging()
    {
        chargedPercent += Time.deltaTime * chargeRate;
        if (chargedPercent > 1) chargedPercent = 1;
        OffsetUpdate();
    }

    public void Release()
    {
        isCharging = false;
        GameObject newTomato = Instantiate(tomatoThrowablePrefab, throwPoint);
        newTomato.transform.parent = null;
        Rigidbody rb = newTomato.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Mathf.Lerp(minThrowForce, maxThrowForce, chargedPercent));
        rb.AddForce(transform.up * Mathf.Lerp(0, maxThrowLift, chargedPercent));
        //handTomatoSceneObject.SetActive(false);
    }

    private void OffsetUpdate()
    {
        transform.SetLocalPositionAndRotation(
            Vector3.Lerp(startingLocalPosition, startingLocalPosition + offsetFullyCharged, chargedPercent),
            Quaternion.Euler(0, 0, Mathf.Lerp(0, offsetAngleDegrees, chargedPercent))
        );
    }
}
