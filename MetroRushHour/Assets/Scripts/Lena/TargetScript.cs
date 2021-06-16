using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
   // public int typeOfTarget;
    public Types.typeOfTarget currentType;
    // string currentTarget;

    //public string targetPositive = "targetPositive";
    //public string targetNegative;
    //public string Crowd;

    public Transform slPos;
    Slider currentSlider;
    public GameObject skinHead;           // ������
    public Material greyMat;
    public Text dollarText;

    public int robStage = 0;
    // public int numTryToRob = 0;
    public bool isRobbed;
    public int valueDollarPerson;
    public int valueDollarGoodPerson;
    public int valueDollarBadPerson;
    public int valueDollarUnluck;

    public bool sliderLevel1;
    public bool sliderLevel2;
    public bool sliderLevel3;

    public GameObject skinPlayer;
    public AudioSource audioSTarget;
    public AudioClip[] audioClipsRob;

    void Awake()
    {
        //switch (typeOfTarget)
        //{
        //    case 1:
        //        currentTarget = "targetPositive";
        //        break;
        //    case 2:
        //        currentTarget = "targetNegative";
        //        break;
        //    case 3:
        //        currentTarget = "targetCrowd";
        //        break;
        //}

        // currentSlider = GetComponentInChildren<Slider>();

        GameObject slInst = Instantiate(Resources.Load("SliderRob")) as GameObject;
        slInst.transform.SetParent(slPos);
        //slInst.transform.position = Vector3.up;
        slInst.GetComponent<Slider>().transform.localPosition = Vector3.up;
        currentSlider = slInst.GetComponent<Slider>();
        //currentSlider.enabled = false;
        //slPos.gameObject.
        if (sliderLevel1)
        {
            currentSlider.gameObject.GetComponent<SliderRob>().speed = SliderSpeed.sliderSpeedL1;
        }
        if (sliderLevel2)
        {
            currentSlider.gameObject.GetComponent<SliderRob>().speed = SliderSpeed.sliderSpeedL2;
        }
        if (sliderLevel3)
        {
            currentSlider.gameObject.GetComponent<SliderRob>().speed = SliderSpeed.sliderSpeedL3;
        }
        currentSlider.gameObject.SetActive(false);
        audioSTarget = GetComponent<AudioSource>();
        isRobbed = false;
        switch (currentType)
        {
            case Types.typeOfTarget.green:
                valueDollarPerson = valueDollarGoodPerson;
                break;
            case Types.typeOfTarget.red:
                valueDollarPerson = valueDollarBadPerson;
                break;
            case Types.typeOfTarget.yellow:
                valueDollarPerson = 0;
                break;
        }
    }
    private void Update()
    {
        if (isRobbed)
        {
            Invoke("ChangeColorRubLucky", 0f);

        }

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    if (robStage == 0)
        //    {
        //        Invoke("StageRob1", 0.5f);
        //        //StageRob1();
        //        Debug.Log("����� ������ � Target ������ 1");

        //    }
        //    if (robStage == 1)
        //    {
        //        Debug.Log("����� ������ � Target ������ 2");
        //        //Invoke("StageRob2(other)", 0.5f);
        //        //StageRob2(other);
        //    }

        //}

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<TestPlayerScript>() != null)
        {
            //    other.GetComponent<TestPlayerScript>().TargetingOn(currentTarget, currentSlider);
            //}

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (robStage == 0)
                {
                    Invoke("StageRob1", 0.2f);
                    //StageRob1();
                    //Debug.Log("����� ������ � Target ������ 1");

                }
                if (robStage == 1)
                {
                    //Debug.Log("����� ������ � Target ������ 2");
                    //Invoke("StageRob2(other)", 0.5f);
                    StageRob2(other);
                }

            }




            //    if (robStage == 0)
            //{
            //    if (Input.GetKeyUp(KeyCode.Space))
            //    {
            //        Debug.Log("����� ������ � Target");
            //        //currentSlider.enabled = true;
            //        currentSlider.gameObject.SetActive(true);
            //        robStage = 1;
            //    }
            //}
            //if (robStage == 1)
            //{
            //    if (Input.GetKeyUp(KeyCode.Space))
            //    {
            //        if (typeOfTarget == 1)
            //        {

            //            if (currentSlider.value < 0.3f || currentSlider.value > 0.7f)
            //            {
            //                other.GetComponent<TestPlayerScript>().MoveRobUnluck();
            //                Dollar.dollarSum -= valueDollarUnluck;
            //                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
            //                return;
            //            }
            //            else
            //            {
            //                //Debug.Log("������ � ������� ������");

            //                other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
            //                numTryToRob = 1;
            //                Dollar.dollarSum += valueDollarGoodPerson;
            //                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
            //                robStage = 2;
            //                return;
            //            }
            //        }

            //        if (typeOfTarget == 2)
            //        {

            //            if (currentSlider.value < 0.3f || currentSlider.value > 0.7f)
            //            {
            //                other.GetComponent<TestPlayerScript>().MoveRobUnluck();
            //                Dollar.dollarSum -= valueDollarUnluck;
            //                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
            //                return;
            //            }
            //            else

            //            {
            //                //other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
            //                numTryToRob = 1;
            //                Dollar.dollarSum += valueDollarBadPerson;
            //                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
            //                robStage = 2;
            //                return;
            //            }
            //        }
            //    }
            //}
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //if (other.GetComponent<TestPlayerScript>() != null)
        //{
        //    other.GetComponent<TestPlayerScript>().TargetingOff();
        //}
        currentSlider.gameObject.SetActive(false);
    }
    public void ChangeColorRubLucky()
    {
        //skin.GetComponent<MeshRenderer>().material = greyMat;
        //skinHead.GetComponentInChildren<SkinnedMeshRenderer>().material = greyMat;
        skinHead.GetComponent<SkinnedMeshRenderer>().material = greyMat;
        //currentSlider.enabled = false;
        currentSlider.gameObject.SetActive(false);
        //Destroy(GetComponent<TargetScript>());

    }
    public void DestroyTarget()
    {
        Destroy(GetComponent<TargetScript>());
        
    }

    void StageRob1()
    {
        //Debug.Log("����� ������ � Target ������ 1");
        currentSlider.gameObject.SetActive(true);
        
        robStage = 1;
    }

    void StageRob2(Collider player)
    {
        Collider other = player;
        //skinPlayer.GetComponent<Transform>().LookAt(skinPlayer.GetComponent<TestPlayerScript>().frontPoint);
        skinPlayer.GetComponent<Animator>().SetBool("Steal", true);

        if (currentSlider.value < 0.25f || currentSlider.value > 0.5f)
        {
            other.GetComponent<TestPlayerScript>().MoveRobUnluck();
            if ((Dollar.dollarSum - valueDollarUnluck) <= 0)
            {
                Dollar.dollarSum = 0;
            }
            else { Dollar.dollarSum -= valueDollarUnluck; }

            dollarText.text = "Dollars: " + Dollar.dollarSum.ToString() + " / " + Dollar.dollarFinal.ToString();
            audioSTarget.PlayOneShot(audioClipsRob[1]);
            //skinPlayer.GetComponent<Animator>().SetBool("Steal", false);
            isRobbed = true;
            return;
        }
        else
        {
            //Debug.Log("������ � ������� ������");
            audioSTarget.PlayOneShot(audioClipsRob[0]);
            if (currentType == Types.typeOfTarget.green)
            {
                other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
            }
            isRobbed = true;
            Dollar.dollarSum += valueDollarPerson;
            dollarText.text = "Dollars: " + Dollar.dollarSum.ToString() + " / " + Dollar.dollarFinal.ToString();
            robStage = 2;
            // Debug.Log("����� ���������� �������");
            //skinPlayer.GetComponent<Animator>().SetBool("Steal", false);
            return;
        }


        //if (typeOfTarget == 1)
        //{

        //    if (currentSlider.value < 0.25f || currentSlider.value > 0.5f)
        //    {
        //        other.GetComponent<TestPlayerScript>().MoveRobUnluck();
        //        if ((Dollar.dollarSum - valueDollarUnluck) <= 0)
        //        {
        //            Dollar.dollarSum = 0;
        //        }
        //        else { Dollar.dollarSum -= valueDollarUnluck; }

        //        dollarText.text = "Dollars: " + Dollar.dollarSum.ToString()+ " / " + Dollar.dollarFinal.ToString();
        //        audioSTarget.PlayOneShot(audioClipsRob[1]);
        //        //skinPlayer.GetComponent<Animator>().SetBool("Steal", false);
        //        isRobbed = true;
        //        return;
        //    }
        //    else
        //    {
        //        //Debug.Log("������ � ������� ������");
        //        audioSTarget.PlayOneShot(audioClipsRob[0]);
        //        other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
        //        isRobbed = true;
        //        Dollar.dollarSum += valueDollarGoodPerson;
        //        dollarText.text = "Dollars: " + Dollar.dollarSum.ToString() + " / " + Dollar.dollarFinal.ToString();
        //        robStage = 2;
        //       // Debug.Log("����� ���������� �������");
        //        //skinPlayer.GetComponent<Animator>().SetBool("Steal", false);
        //        return;
        //    }
        //}
        //if (typeOfTarget == 2)
        //{

        //    if (currentSlider.value < 0.25f || currentSlider.value > 0.5f)
        //    {
        //        other.GetComponent<TestPlayerScript>().MoveRobUnluck();
        //        if ((Dollar.dollarSum - valueDollarUnluck) <= 0)
        //        {
        //            Dollar.dollarSum = 0;
        //        }
        //        else { Dollar.dollarSum -= valueDollarUnluck; }
        //        dollarText.text = "Dollars: " + Dollar.dollarSum.ToString() + " / " + Dollar.dollarFinal.ToString();
        //        audioSTarget.PlayOneShot(audioClipsRob[1]);
        //        isRobbed = true;

        //        //skinPlayer.GetComponent<Animator>().SetBool("Steal", false);
        //        return;
        //    }
        //    else

        //    {
        //        audioSTarget.PlayOneShot(audioClipsRob[0]);
        //        //other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
        //        isRobbed = true;
        //        Dollar.dollarSum += valueDollarBadPerson;
        //        dollarText.text = "Dollars: " + Dollar.dollarSum.ToString() + " / " + Dollar.dollarFinal.ToString();
        //        robStage = 2;
        //       // Debug.Log("����� ���������� ������");
        //        //skinPlayer.GetComponent<Animator>().SetBool("Steal", false);
        //        return;
        //    }
        //}
    }
}
