using System;
using System.Collections;
using UnityEngine;

public class Swap : MonoBehaviour
{
    private GameObject firstSelect;
    private GameObject secondSelect;

    private GameObject firstBox;
    private GameObject secondBox;


    private bool inAnimation = false;

    private void Update()
    {
        mouseSelect();
        swap();

        showSelection(firstSelect);
        showSelection(secondSelect);
    }

    private bool checkRelation()
    {
        int[] array = GetComponent<TreeToArray>().getArray();

        int firstValue = firstBox.GetComponent<Box>().getBoxValue();
        int secondValue = secondBox.GetComponent<Box>().getBoxValue();

        int firstIndex = Array.IndexOf(array, firstValue);
        int secondIndex = Array.IndexOf(array, secondValue);

        if (firstIndex == GetComponent<TreeToArray>().getParent(secondIndex))
            return true;
        else if (secondIndex == GetComponent<TreeToArray>().getParent(firstIndex))
            return true;
        else return false;
    }

    //Swap, wenn 2 Nodes selected sind
    private void swap()
    {
        if (firstSelect && secondSelect)
        {
            StartCoroutine(InitiateSwap());
        }
    }

    IEnumerator InitiateSwap()
    {
        if (checkRelation())
        {
            firstSelect.transform.GetComponent<Node>().setPlacedBox(null);
            secondSelect.transform.GetComponent<Node>().setPlacedBox(null);

            yield return StartCoroutine(SwapBox());

            try
            {
                firstSelect.transform.GetComponent<Node>().setPlacedBox(secondBox);
                secondSelect.transform.GetComponent<Node>().setPlacedBox(firstBox);
            }
            catch (Exception) { }
            
        }
        yield return new WaitForSeconds(0.1f);
        deselect();
    }

    IEnumerator SwapBox()
    {
        Vector3 startingPos = firstSelect.transform.position;
        Vector3 finalPos = secondSelect.transform.position;

        while ((firstBox.transform.position - finalPos).sqrMagnitude > 0.0001f)
        {
            firstBox.transform.position = Vector2.MoveTowards(firstBox.transform.position, finalPos, 0.05f * Time.deltaTime);
            secondBox.transform.position = Vector2.MoveTowards(secondBox.transform.position, startingPos, 0.05f * Time.deltaTime);
            yield return null;
        }
    }

    //Slection Highlight, wenn eine Node ausgewählt ist
    private void showSelection(GameObject selectedObject)
    {
        if (selectedObject)
            selectedObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    //Raycast
    private void mouseSelect()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !inAnimation)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.back, 100, ~LayerMask.NameToLayer("Node"));
            if (hit)
            {
                if (hit.transform.GetComponent<Node>().hasPlacedBox() && !hit.transform.GetComponent<Node>().getLocked()) 
                    select(hit.transform.gameObject);
            }
        }
    }

    //Select & Deselect
    public void select(GameObject Node) 
    {
        if (firstSelect == Node)
            deselect();
        else if (!firstSelect)
        {
            firstSelect = Node;
            firstBox = firstSelect.transform.GetComponent<Node>().getPlacedBox();
        }
        else if (firstSelect)
        {
            secondSelect = Node;
            secondBox = secondSelect.transform.GetComponent<Node>().getPlacedBox();
        }
    }

    public void deselect()
    {
        if (firstSelect)
        {
            firstSelect.transform.GetChild(0).gameObject.SetActive(false);
            firstSelect = null;
            //firstBox = null;
        }
        if (secondSelect)
        {
            secondSelect.transform.GetChild(0).gameObject.SetActive(false);
            secondSelect = null;
            //secondBox = null;
        }
    }
}