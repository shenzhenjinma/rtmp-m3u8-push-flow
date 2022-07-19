namespace Oraycn.NPusherDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.label_pushState = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_camera = new System.Windows.Forms.RadioButton();
            this.radioButton_desktop = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_soundCard = new System.Windows.Forms.CheckBox();
            this.checkBox_micro = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start.Enabled = false;
            this.button_start.Location = new System.Drawing.Point(153, 415);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(80, 23);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "开始推流";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(251, 415);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(80, 23);
            this.button_stop.TabIndex = 0;
            this.button_stop.Text = "停止推流";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // label_pushState
            // 
            this.label_pushState.AutoSize = true;
            this.label_pushState.ForeColor = System.Drawing.Color.Red;
            this.label_pushState.Location = new System.Drawing.Point(54, 420);
            this.label_pushState.Name = "label_pushState";
            this.label_pushState.Size = new System.Drawing.Size(53, 12);
            this.label_pushState.TabIndex = 7;
            this.label_pushState.Text = "推流状态";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_camera);
            this.groupBox1.Controls.Add(this.radioButton_desktop);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 50);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像";
            // 
            // radioButton_camera
            // 
            this.radioButton_camera.AutoSize = true;
            this.radioButton_camera.Checked = true;
            this.radioButton_camera.Location = new System.Drawing.Point(11, 22);
            this.radioButton_camera.Name = "radioButton_camera";
            this.radioButton_camera.Size = new System.Drawing.Size(59, 16);
            this.radioButton_camera.TabIndex = 2;
            this.radioButton_camera.TabStop = true;
            this.radioButton_camera.Text = "摄像头";
            this.radioButton_camera.UseVisualStyleBackColor = true;
            // 
            // radioButton_desktop
            // 
            this.radioButton_desktop.AutoSize = true;
            this.radioButton_desktop.Location = new System.Drawing.Point(125, 22);
            this.radioButton_desktop.Name = "radioButton_desktop";
            this.radioButton_desktop.Size = new System.Drawing.Size(47, 16);
            this.radioButton_desktop.TabIndex = 1;
            this.radioButton_desktop.Text = "桌面";
            this.radioButton_desktop.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_soundCard);
            this.groupBox2.Controls.Add(this.checkBox_micro);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 50);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "声音";
            // 
            // checkBox_soundCard
            // 
            this.checkBox_soundCard.AutoSize = true;
            this.checkBox_soundCard.Location = new System.Drawing.Point(125, 22);
            this.checkBox_soundCard.Name = "checkBox_soundCard";
            this.checkBox_soundCard.Size = new System.Drawing.Size(48, 16);
            this.checkBox_soundCard.TabIndex = 1;
            this.checkBox_soundCard.Text = "声卡";
            this.checkBox_soundCard.UseVisualStyleBackColor = true;
            // 
            // checkBox_micro
            // 
            this.checkBox_micro.AutoSize = true;
            this.checkBox_micro.Checked = true;
            this.checkBox_micro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_micro.Location = new System.Drawing.Point(11, 22);
            this.checkBox_micro.Name = "checkBox_micro";
            this.checkBox_micro.Size = new System.Drawing.Size(60, 16);
            this.checkBox_micro.TabIndex = 0;
            this.checkBox_micro.Text = "麦克风";
            this.checkBox_micro.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(241, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "启动设备";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 448);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_pushState);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "傲瑞推流 Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label_pushState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_camera;
        private System.Windows.Forms.RadioButton radioButton_desktop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_soundCard;
        private System.Windows.Forms.CheckBox checkBox_micro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
    }
}

