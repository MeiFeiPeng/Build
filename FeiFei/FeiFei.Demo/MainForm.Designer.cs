namespace FeiFei.Demo
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_FeiFeiLog = new System.Windows.Forms.GroupBox();
            this.button_Log = new System.Windows.Forms.Button();
            this.button_LogDir = new System.Windows.Forms.Button();
            this.groupBox_FeiFeiLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_FeiFeiLog
            // 
            this.groupBox_FeiFeiLog.Controls.Add(this.button_LogDir);
            this.groupBox_FeiFeiLog.Controls.Add(this.button_Log);
            this.groupBox_FeiFeiLog.Location = new System.Drawing.Point(12, 12);
            this.groupBox_FeiFeiLog.Name = "groupBox_FeiFeiLog";
            this.groupBox_FeiFeiLog.Size = new System.Drawing.Size(960, 55);
            this.groupBox_FeiFeiLog.TabIndex = 0;
            this.groupBox_FeiFeiLog.TabStop = false;
            this.groupBox_FeiFeiLog.Text = "FeiFei.Log";
            // 
            // button_Log
            // 
            this.button_Log.Location = new System.Drawing.Point(6, 20);
            this.button_Log.Name = "button_Log";
            this.button_Log.Size = new System.Drawing.Size(75, 23);
            this.button_Log.TabIndex = 0;
            this.button_Log.Text = "生成日志";
            this.button_Log.UseVisualStyleBackColor = true;
            this.button_Log.Click += new System.EventHandler(this.button_Log_Click);
            // 
            // button_LogDir
            // 
            this.button_LogDir.Location = new System.Drawing.Point(87, 20);
            this.button_LogDir.Name = "button_LogDir";
            this.button_LogDir.Size = new System.Drawing.Size(139, 23);
            this.button_LogDir.TabIndex = 0;
            this.button_LogDir.Text = "打开日志目录";
            this.button_LogDir.UseVisualStyleBackColor = true;
            this.button_LogDir.Click += new System.EventHandler(this.button_LogDir_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 579);
            this.Controls.Add(this.groupBox_FeiFeiLog);
            this.Name = "MainForm";
            this.Text = "FeiFei";
            this.groupBox_FeiFeiLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_FeiFeiLog;
        private System.Windows.Forms.Button button_Log;
        private System.Windows.Forms.Button button_LogDir;
    }
}

