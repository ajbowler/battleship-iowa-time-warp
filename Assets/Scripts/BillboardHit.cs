using UnityEngine;
using System.Collections;

public class BillboardHit : MonoBehaviour {
    public Camera cam;
    public float fadeSpeed;
    public float floatSpeed;
    public float waitSeconds;

    public Texture tex;

    private float floating;
    private Renderer theRenderer;

    void Awake()
    {
        if (!cam) cam = Camera.main;
        theRenderer = GetComponent<Renderer>();
        theRenderer.material.SetTexture("_MainTex", tex);
        floating = 0;
    }

    void Update()
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
        transform.Translate(new Vector3(0,floating,0));
        StartCoroutine(Fade());
        if (theRenderer.material.GetColor("_TintColor").a <= 0)
            Destroy(this.gameObject);
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(waitSeconds);
        Color color = theRenderer.material.GetColor("_TintColor");
        color.a -= fadeSpeed * Time.deltaTime;
        theRenderer.material.SetColor("_TintColor", color);
        floating = floatSpeed;
    }
}
