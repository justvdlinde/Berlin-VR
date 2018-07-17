using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour {

	public Material lMat;

	public SteamVR_TrackedObject trackedObj;

	private GraphicsLineRenderer currLine;

	private int numClicks = 0;

	void Update () {
		SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject go = new GameObject();

            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            currLine = go.AddComponent<GraphicsLineRenderer>();

            currLine.lmat = new Material(lMat);

            currLine.SetWidth(.1f);
            

        }
        else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {

            currLine.AddPoint(trackedObj.transform.position);
            numClicks++;
        }
        else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
            numClicks = 0;
            currLine = null;
        }

            if (currLine != null) {
            currLine.lmat.color = ColorManager.Instance.GetCurrentColor();
        }
	}
}
