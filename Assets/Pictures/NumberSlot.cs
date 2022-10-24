using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberSlot : MonoBehaviour , IDropHandler
{



    //1. Bedingung. Zur Ueberpruefung ob ObjektName gleich ArrayName ist 
    private string [] rightstring = new string [] {"Nummer","Nummer (1)","Nummer (2)","Nummer (3)","Nummer (4)", 
                                                "Nummer (5)","Nummer (6)","Nummer (7)","Nummer (8)","Nummer (9)",
                                                "Nummer (10)","Nummer (11)","Nummer (12)","Nummer (13)","Nummer (14)"}; 
    
    private float [] rightx1 = new float [] {3104,2846,3307,2731,2944,3227, // 2. Bedingung. Zur Ueberpruefung ob Objekt auf X steht
                                             3422,2646,2771,2892,3024,
                                             3154,3282,3405,3522}; 

    private bool [] rightbool = new bool [] {false,false,false,false,false, // Wenn 1.Bdng[i] und 2.Bdng[i] erfuellt sind -> rightbool[i] = true
                                                false,false,false,false,false, // Wenn alle rightbool[i] auf true -> Weiterkommen
                                                false,false,false,false,false };         


   public void OnDrop(PointerEventData eventData){
    
    if(eventData.pointerDrag != null){
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        //Debug.Log(eventData.pointerDrag.transform.position.x); // beim Loslassen der NummerObjekte die X Koordinate anzeigenlassen
        //Debug.Log(eventData.pointerDrag.transform.position.y); // beim Loslassen der NummerObjekte die Y Koordinate anzeigenlassen
        
    }
    for (int i= 0 ;i < 15; i ++){
       if(eventData.pointerDrag.name == rightstring[i]
        &&eventData.pointerDrag.transform.position.x <= rightx1[i]
        &&eventData.pointerDrag.transform.position.x >= rightx1[i]-1)
        {
         Debug.Log("Gleich");
         rightbool[i] = true;
        }
    }
    
        
   }

  

      public float getXAxis(){
    return transform.position.x;
}
}
