using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor.Recorder;
using UnityEditor;
using UnityEditor.Recorder.Input;

public class Flim : MonoBehaviour
{
    RecorderController m_RecorderController;
    // Start is called before the first frame update
    void Start()
    {
        var controllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();
        m_RecorderController = new RecorderController(controllerSettings);

        var mediaOutputFolder = Application.streamingAssetsPath;

        var videoRecorder = ScriptableObject.CreateInstance<MovieRecorderSettings>();
        videoRecorder.name = "My Video Recorder";
        videoRecorder.Enabled = true;

        videoRecorder.OutputFormat = MovieRecorderSettings.VideoRecorderOutputFormat.MP4;
        videoRecorder.VideoBitRateMode = VideoBitrateMode.Low;

        /*videoRecorder.ImageInputSettings = new GameViewInputSettings
        {
            OutputWidth = 1920,
            OutputHeight = 1080
        };*/

        videoRecorder.AudioInputSettings.PreserveAudio = true;

        videoRecorder.OutputFile = Path.Combine(mediaOutputFolder, "video " + 1);

        controllerSettings.AddRecorderSettings(videoRecorder);

        controllerSettings.SetRecordModeToManual();
        controllerSettings.FrameRate = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PleaseRecord()
    {
        m_RecorderController.StartRecording();
    }

    public void StopRecord()
    {
        m_RecorderController.StopRecording();
    }
}
