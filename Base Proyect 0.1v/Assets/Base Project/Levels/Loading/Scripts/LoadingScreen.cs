using System.Collections;
using UnityEngine;
using Managers;

public class LoadingScreen : MonoBehaviour
{
	public RectTransform loadingBar;

	private float width;

	private void Start()
	{
		width = loadingBar.sizeDelta.x;
		loadingBar.sizeDelta = new Vector3(0, loadingBar.sizeDelta.y);

		StartCoroutine(Loading());
	}

	private IEnumerator Loading()
	{
		while(GameManager.Instance.progress * width < width)
		{
			ChargeBar(GameManager.Instance.progress);
			yield return null;
		}
	}

	private void ChargeBar(float progress)
	{
		loadingBar.sizeDelta = new Vector2((progress * width), loadingBar.sizeDelta.y);
	}
}