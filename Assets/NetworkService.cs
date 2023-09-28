using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using UnityEngine.Experimental.Networking;


public class NetworkService 
{
	private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=Chicago,us&mode=xml&APPID=188e2e8cb4ba801748304cf287a4ca46";
	private const string jsonApi = "http://api.openweathermap.org/data/2.5/weather?q=Moscow,ru&APPID=188e2e8cb4ba801748304cf287a4ca46";
	private IEnumerator CallAPI(string url, Action<string> callback) 
	{
		using (UnityWebRequest request = UnityWebRequest.Get(url)) 
		{
			yield return request.Send(); 
			if (request.responseCode != (long)System.Net.HttpStatusCode.OK) 
			{
				Debug.LogError("response error: " + request.responseCode);
			} 
			else 
			{
				callback(request.downloadHandler.text);
			}
		}
	}
	public IEnumerator GetWeatherJSON(Action<string> callback) 
	{
		return CallAPI(jsonApi, callback);
	}
	public IEnumerator GetWeatherXML(Action<string> callback) 
	{
		return CallAPI(xmlApi, callback);
	}
}