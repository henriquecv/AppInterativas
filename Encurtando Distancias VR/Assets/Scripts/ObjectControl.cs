//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectControl : MonoBehaviour
{
    [SerializeField]
    private string scene = "";
    [SerializeField]
    private bool isInfo;
    // Gaze Timer logic
    private bool _gvrStatus = false;
    private float _gvrTimer = 0;
    private float _totalTime = 2.0f;
    private Image imgGaze; //We get this image by the Tag "Gaze Image"
    private bool _gazeComplete = false;
    private GameObject gazePoint;
    [SerializeField]
    private GameObject UICard;
    public void Start()
    {
        gazePoint = GameObject.Find("GazePoint");
        imgGaze = GameObject.Find("GazePointExpand").GetComponent<Image>();
        imgGaze.fillAmount = 0;
        UICard.SetActive(false);
    }
    public void Update()
    {
        // Gaze Timer logic
        if (_gvrStatus)
        {
            _gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = _gvrTimer / _totalTime;
        }

        if (_gvrTimer > _totalTime && _gazeComplete != true)
        {
            sendHello();
            _gazeComplete = true;
        }
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        _gvrStatus = true;
        imgGaze.fillAmount = 0;
        Debug.Log("Entered!");
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        _gvrStatus = false;
        _gvrTimer = 0;
        imgGaze.fillAmount = 0;
        _gazeComplete = false;
        UICard.SetActive(false);
        Debug.Log("Exited!");
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {

    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void sendHello()
    {
         if(!isInfo)
            SceneManager.LoadScene(scene);
         else
            UICard.SetActive(true);

    }

}
