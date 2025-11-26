namespace SoundSwitchWidget
{
    partial class FormSoundSwitchWidget
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSoundSwitchWidget));
            devicesComboBox = new ComboBox();
            contextMenuStrip = new ContextMenuStrip(components);
            optionsToolStripMenuItem = new ToolStripMenuItem();
            mostTopToolStripMenuItem = new ToolStripMenuItem();
            autorunToolStripMenuItem = new ToolStripMenuItem();
            showInTaskbarToolStripMenuItem = new ToolStripMenuItem();
            oppacityToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            volumeProgressBar = new InstantProgressBar();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            devicesComboBox.ContextMenuStrip = contextMenuStrip;
            devicesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            devicesComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            devicesComboBox.FormattingEnabled = true;
            devicesComboBox.Location = new Point(12, 13);
            devicesComboBox.Name = "comboBox1";
            devicesComboBox.Size = new Size(282, 29);
            devicesComboBox.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { optionsToolStripMenuItem, closeToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(131, 52);
            contextMenuStrip.Opening += contextMenuStrip1_Opening;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mostTopToolStripMenuItem, autorunToolStripMenuItem, showInTaskbarToolStripMenuItem, oppacityToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(130, 24);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // mostTopToolStripMenuItem
            // 
            mostTopToolStripMenuItem.Name = "mostTopToolStripMenuItem";
            mostTopToolStripMenuItem.Size = new Size(182, 24);
            mostTopToolStripMenuItem.Text = "Most top";
            mostTopToolStripMenuItem.Click += mostTopToolStripMenuItem_Click;
            // 
            // autorunToolStripMenuItem
            // 
            autorunToolStripMenuItem.Name = "autorunToolStripMenuItem";
            autorunToolStripMenuItem.Size = new Size(182, 24);
            autorunToolStripMenuItem.Text = "Autorun";
            autorunToolStripMenuItem.Click += autorunToolStripMenuItem_Click;
            // 
            // showInTaskbarToolStripMenuItem
            // 
            showInTaskbarToolStripMenuItem.Name = "showInTaskbarToolStripMenuItem";
            showInTaskbarToolStripMenuItem.Size = new Size(182, 24);
            showInTaskbarToolStripMenuItem.Text = "Show in taskbar";
            showInTaskbarToolStripMenuItem.Click += showInTaskbarToolStripMenuItem_Click;
            // 
            // oppacityToolStripMenuItem
            // 
            oppacityToolStripMenuItem.Name = "oppacityToolStripMenuItem";
            oppacityToolStripMenuItem.Size = new Size(182, 24);
            oppacityToolStripMenuItem.Text = "Oppacity";
            oppacityToolStripMenuItem.Click += oppacityToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(130, 24);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // instantProgressBar1
            // 
            volumeProgressBar.ContextMenuStrip = contextMenuStrip;
            volumeProgressBar.Location = new Point(12, 49);
            volumeProgressBar.Minimum = 0;
            volumeProgressBar.Name = "instantProgressBar1";
            volumeProgressBar.Size = new Size(282, 29);
            volumeProgressBar.TabIndex = 1;
            volumeProgressBar.Text = "instantProgressBar1";
            volumeProgressBar.Value = 0;
            volumeProgressBar.MouseDown += instantProgressBar1_MouseDown;
            volumeProgressBar.MouseMove += instantProgressBar1_MouseMove;
            volumeProgressBar.MouseUp += instantProgressBar1_MouseUp;
            // 
            // FormSoundSwitchWidget
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 87);
            ContextMenuStrip = contextMenuStrip;
            Controls.Add(volumeProgressBar);
            Controls.Add(devicesComboBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormSoundSwitchWidget";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "SoundSwitchWidget";
            Activated += FormSoundSwitchWidget_Activated;
            Deactivate += FormSoundSwitchWidget_Deactivate;
            FormClosing += FormSoundSwitchWidget_FormClosing;
            Load += FormSoundSwitchWidget_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox devicesComboBox;
        private InstantProgressBar volumeProgressBar;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem mostTopToolStripMenuItem;
        private ToolStripMenuItem autorunToolStripMenuItem;
        private ToolStripMenuItem showInTaskbarToolStripMenuItem;
        private ToolStripMenuItem oppacityToolStripMenuItem;
    }
}
