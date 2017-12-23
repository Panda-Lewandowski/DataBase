namespace BC3XML
{
    partial class Bc3xml
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xmlTextBox = new System.Windows.Forms.TextBox();
            this.loadXmlButton = new System.Windows.Forms.Button();
            this.domButton = new System.Windows.Forms.Button();
            this.linqButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // xmlTextBox
            // 
            this.xmlTextBox.Location = new System.Drawing.Point(12, 12);
            this.xmlTextBox.Multiline = true;
            this.xmlTextBox.Name = "xmlTextBox";
            this.xmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xmlTextBox.Size = new System.Drawing.Size(358, 316);
            this.xmlTextBox.TabIndex = 0;
            // 
            // loadXmlButton
            // 
            this.loadXmlButton.Location = new System.Drawing.Point(377, 13);
            this.loadXmlButton.Name = "loadXmlButton";
            this.loadXmlButton.Size = new System.Drawing.Size(240, 23);
            this.loadXmlButton.TabIndex = 1;
            this.loadXmlButton.Text = "load XML";
            this.loadXmlButton.UseVisualStyleBackColor = true;
            this.loadXmlButton.Click += new System.EventHandler(this.loadXmlButton_Click);
            // 
            // domButton
            // 
            this.domButton.Location = new System.Drawing.Point(377, 43);
            this.domButton.Name = "domButton";
            this.domButton.Size = new System.Drawing.Size(240, 23);
            this.domButton.TabIndex = 3;
            this.domButton.Text = "DOM";
            this.domButton.UseVisualStyleBackColor = true;
            this.domButton.Click += new System.EventHandler(this.domButton_Click);
            // 
            // linqButton
            // 
            this.linqButton.Location = new System.Drawing.Point(377, 73);
            this.linqButton.Name = "linqButton";
            this.linqButton.Size = new System.Drawing.Size(240, 23);
            this.linqButton.TabIndex = 4;
            this.linqButton.Text = "Linq";
            this.linqButton.UseVisualStyleBackColor = true;
            this.linqButton.Click += new System.EventHandler(this.linqButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(377, 103);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(240, 225);
            this.resultTextBox.TabIndex = 5;
            this.resultTextBox.Text = "";
            // 
            // Bc3xml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 340);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.linqButton);
            this.Controls.Add(this.domButton);
            this.Controls.Add(this.loadXmlButton);
            this.Controls.Add(this.xmlTextBox);
            this.Name = "Bc3xml";
            this.Text = "BC3.XML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xmlTextBox;
        private System.Windows.Forms.Button loadXmlButton;
        private System.Windows.Forms.Button domButton;
        private System.Windows.Forms.Button linqButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RichTextBox resultTextBox;

    }
}

