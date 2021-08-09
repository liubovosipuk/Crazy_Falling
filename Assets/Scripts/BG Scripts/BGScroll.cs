using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed = 0.3f;

    private MeshRenderer mesh_Renderer;
    


    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();

    }

    
    void Update()
    {
        Scroll();
    }

    // создаем пустую прокрутку
    void Scroll()
    {

        // пример hardcode такое лучше не делать имя текстуры лучше задавать в отдельной переменной 
        // это делается в том случае, если это имя будет использоваться несколько раз

        //Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        //offset.y += Time.deltaTime * scrollSpeed;

        //mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scrollSpeed;

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }
} 
