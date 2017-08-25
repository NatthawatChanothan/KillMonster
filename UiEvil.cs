using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using palinee;
public class UiEvil : MonoBehaviour {
    public Slider healthSlider;
    public AiFsm aifsm;
    private float size;
    private Transform trans;
    private Transform camTrans;
    public float scaleMultiplier = 1f;
    public bool scaleWithDistance = false;
    public Transform camaraL;

    void Awake()
    {
        camTrans = camaraL;
        trans = transform;
    }
	
	void Update () 
    {
        OnHealthChange();
        transform.LookAt(trans.position + camTrans.rotation * Vector3.forward,
            camTrans.rotation * Vector3.up);

        if (!scaleWithDistance) return;
        size = (camTrans.position - transform.position).magnitude;
        transform.localScale = Vector3.one * (size * (scaleMultiplier / 100f));
	}

    public void OnHealthChange()
    {
        healthSlider.value = aifsm.hp;
    }


   
}
