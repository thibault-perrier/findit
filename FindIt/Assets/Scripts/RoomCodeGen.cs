using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCodeGen : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            string code = CodeGen(5);
            Debug.Log(code);
        }
    }

    private string CodeGen(int length)
    {
        string code = "";
        for (int index = 0; index < length; index++)
        {
            int ASCIIvalue = 0;
            if (Random.Range(0, 2) == 0) //then it's a number
            {
                ASCIIvalue = Random.Range(48, 58);
            }
            else //then it's a letter 
            {
                ASCIIvalue = Random.Range(65, 91);
            }
            char c = (char)ASCIIvalue;
            // Debug.Log(c);
            code += c;
        }
        return code;
    }
}
