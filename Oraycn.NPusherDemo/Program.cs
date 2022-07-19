using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oraycn.NPusherDemo
{
    /*
    * 本demo采用的是 语音视频采集组件MCapture 的免费版本。若想获取MCapture其它版本，请联系 www.oraycn.com 。
    * 
    */
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
    }
}
