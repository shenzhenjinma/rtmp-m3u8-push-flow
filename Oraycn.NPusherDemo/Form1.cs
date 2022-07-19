using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESBasic;
using Oraycn.MCapture;

namespace Oraycn.NPusherDemo
{
    /*
    * 本demo采用的是 语音视频采集组件MCapture 和 推流组件NPusher 的免费版本。若想获取正式版的MCapture和NPusher，请联系 www.oraycn.com ,客服qq：168757008。
    * 
    */
    public partial class Form1 : Form
    {
        private ISoundcardCapturer soundcardCapturer;//声卡采集器
        private IMicrophoneCapturer microphoneCapturer;//麦克风采集器
        private IDesktopCapturer desktopCapturer;//桌面采集器
        private ICameraCapturer cameraCapturer;//摄像头采集器
        private IAudioMixter audioMixter;//混音器  （用于将声卡数据与麦克风的数据 进行混音）
        private Oraycn.NPusher.IStreamPusher streamPusher;
        private int frameRate = 10; // 采集视频的帧频
        private  bool isPushing = false; //正在推流中
        private int channelCount = 1;



        private Size defaultVideoSize = new Size(640, 480);


        public Form1()
        {
            InitializeComponent();
            this.label_pushState.Text = string.Empty;
            Oraycn.MCapture.GlobalUtil.SetAuthorizedUser("FreeUser", "");
            this.streamPusher = Oraycn.NPusher.PusherFactory.CreatePusher();
            this.streamPusher.Disconnected += StreamPusher_Disconnected;
        }

        private void StreamPusher_Disconnected()
        {
            this.StopPushStream();
            this.ShowStateMsg("推流器断开，推流停止！");
        }

        //启动设备
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                int audioSampleRate = 16000;
                //if (!this.checkBox_micro.Checked && !this.checkBox_soundCard.Checked)
                //{
                //    MessageBox.Show("请选择要选择一个声音的采集源！");
                //    return;
                //}
                this.StopCapturer();

                #region 设置采集器
                if (this.radioButton_desktop.Checked)
                {
                    //桌面采集器

                    //如果需要录制鼠标的操作，第二个参数请设置为true
                    this.desktopCapturer = CapturerFactory.CreateDesktopCapturer(frameRate, false,new Rectangle(0,0,640,480));
                    this.desktopCapturer.ImageCaptured += this.Form1_ImageCaptured;
   
                }
                else if (this.radioButton_camera.Checked)
                {
                    //摄像头采集器
                    this.cameraCapturer = CapturerFactory.CreateCameraCapturer(0, this.defaultVideoSize, frameRate);
                    this.cameraCapturer.ImageCaptured += new CbGeneric<Bitmap>(this.Form1_ImageCaptured);
                }

                if (this.checkBox_micro.Checked)
                {
                    //麦克风采集器
                    this.microphoneCapturer = CapturerFactory.CreateMicrophoneCapturer(0);
                    this.microphoneCapturer.CaptureError += new CbGeneric<Exception>(this.CaptureError);
                }

                if (this.checkBox_soundCard.Checked)
                {
                    //声卡采集器 【目前声卡采集仅支持vista以及以上系统】扬声器 属性 高级设置 16位 48000HZ（DVD音质）
                    this.soundcardCapturer = CapturerFactory.CreateSoundcardCapturer();
                    this.soundcardCapturer.CaptureError += this.CaptureError;
                    if (this.soundcardCapturer.SampleRate != 48000)
                    {
                        throw new Exception("声卡采样率必须为48000HZ");
                    }
                    audioSampleRate = this.soundcardCapturer.SampleRate;
                    this.channelCount = this.soundcardCapturer.ChannelCount;
                }

                if (this.checkBox_micro.Checked && this.checkBox_soundCard.Checked)
                {
                    //混音器
                    this.audioMixter = CapturerFactory.CreateAudioMixter(this.microphoneCapturer, this.soundcardCapturer);
                    this.audioMixter.AudioMixed += audioMixter_AudioMixed;
                    audioSampleRate = this.audioMixter.SampleRate;
                    this.channelCount = this.audioMixter.ChannelCount;
                }

                else if (this.checkBox_micro.Checked)
                {
                    this.microphoneCapturer.AudioCaptured += audioMixter_AudioMixed;
                }
                else if (this.checkBox_soundCard.Checked)
                {
                    this.soundcardCapturer.AudioCaptured += audioMixter_AudioMixed;
                }
                #endregion


                #region //开始采集
                if (this.checkBox_micro.Checked)
                {
                    this.microphoneCapturer.Start();
                }
                if (this.checkBox_soundCard.Checked)
                {
                    this.soundcardCapturer.Start();
                }

                if (this.radioButton_camera.Checked)
                {
                    this.cameraCapturer.Start();
                }
                else if (this.radioButton_desktop.Checked)
                {
                    this.desktopCapturer.Start();
                }
                #endregion

                this.checkBox_micro.Enabled = false;
                this.checkBox_soundCard.Enabled = false;
                this.radioButton_desktop.Enabled = false;
                this.radioButton_camera.Enabled = false;

                this.button3.Enabled = false;
                this.button_start.Enabled = true;
                this.button_stop.Enabled = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void DisplayVideo(Image img)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric<Image>(this.DisplayVideo), img);
            }
            else
            {
                Image old = this.pictureBox1.BackgroundImage;
                this.pictureBox1.BackgroundImage = img;
                if (old != null)
                {
                    old.Dispose();
                }
            }
        }

        #region 开始推流
        private string streamID = "aa01";
        private void button_start_Click(object sender, EventArgs e)
        {
            //TODO 开始录制桌面，依据 声音复选框 来选择使用 声卡 麦克风 还是混合录制, 图像复选框来选择 图像的采集器
            try
            {
                int videoWidth = 0, videoHeight = 0;
                if (this.radioButton_desktop.Checked)
                {
                    videoWidth = this.desktopCapturer.VideoSize.Width;
                    videoHeight = this.desktopCapturer.VideoSize.Height;
                }
                else {
                    videoWidth = this.defaultVideoSize.Width;
                    videoHeight = this.defaultVideoSize.Height;
                }
                this.streamPusher.UpsideDown4RGB24 = true;
                this.streamPusher.Initialize(ConfigurationManager.AppSettings["NginxServerIP"], int.Parse(ConfigurationManager.AppSettings["NginxServerPort"]), true, this.streamID, videoWidth, videoHeight, NPusher.InputAudioDataType.PCM, NPusher.InputVideoDataType.RGB24,this.channelCount);

                //this.streamPusher.Initialize("rtmp://push.live.zsyoushi.com/live/obs", videoWidth, videoHeight, NPusher.InputAudioDataType.PCM, NPusher.InputVideoDataType.RGB24, this.channelCount);
                this.isPushing = true;
                this.button_start.Enabled = false;
                this.button_stop.Enabled = true;
                this.button3.Enabled = false;
                this.ShowStateMsg("推流中...");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        #region CaptureError
        void CaptureError(Exception obj)
        {

        } 
        #endregion

        #region Form1_ImageCaptured
        //采集到的视频或桌面图像
        void Form1_ImageCaptured(Bitmap img)
        {
            if (this.radioButton_camera.Checked)//显示摄像头的图像到窗体
            {
                Image copy = ESBasic.Helpers.ImageHelper.CopyImageDeeply(img);
                this.DisplayVideo(copy);
            }
            if (this.isPushing)
            {
                img.RotateFlip(RotateFlipType.Rotate180FlipY);
                byte[] data = ESBasic.Helpers.ImageHelper.GetRGB24CoreData(img);
                this.streamPusher.PushVideoFrame(data);
            }            
        } 
        #endregion

        #region audioMixter_AudioMixed
        //采集到的声卡、麦克风、声卡麦克风的混音数据
        void audioMixter_AudioMixed(byte[] audioData)
        {
            if (this.isPushing)
            {
                if (this.checkBox_soundCard.Checked && !this.checkBox_micro.Checked)
                {
                    audioData = AudioHelper.ConvertTo16kFrom48k(audioData ,this.channelCount);
                }
                this.streamPusher.PushAudioFrame(audioData);
            }
        } 
        #endregion
        #endregion

        #region 结束推流
        private void button_stop_Click(object sender, EventArgs e)
        {
            try
            {
                this.StopPushStream();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        /// <summary>
        /// 断开连接器，关闭推流
        /// </summary>
        private void StopPushStream()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.StopPushStream));
            }
            else
            {

                this.streamPusher.Close();
                this.StopCapturer();
                this.checkBox_micro.Enabled = true;
                this.checkBox_soundCard.Enabled = true;
                this.radioButton_camera.Enabled = true;
                this.radioButton_desktop.Enabled = true;

                this.button_start.Enabled = false;
                this.button_stop.Enabled = false;
                this.button3.Enabled = true;


                this.isPushing = false;
                this.ShowStateMsg("推流停止");
            }
        }
        #endregion

        private void StopCapturer()
        {
            if (this.desktopCapturer != null)
            {
                this.desktopCapturer.Stop();
                this.desktopCapturer.Dispose();
            }
            if (this.cameraCapturer != null)
            {
                this.cameraCapturer.Stop();
                this.cameraCapturer.Dispose();
            }
            if (this.microphoneCapturer != null)
            {
                this.microphoneCapturer.Stop();
                this.microphoneCapturer.Dispose();
            }
            if (this.soundcardCapturer != null)
            {
                this.soundcardCapturer.Stop();
                this.soundcardCapturer.Dispose();
            }
        }



        private void ShowStateMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<string>(this.ShowStateMsg), msg);
            }
            else
            {
                this.label_pushState.Text = msg;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isPushing)
            {
                MessageBox.Show("正在推流中，退出前请先停止推流！");
                e.Cancel = true;
                return;
            }
            this.StopCapturer();
            e.Cancel = false;
        }

    }
}
