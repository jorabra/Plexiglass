namespace Plexiglass
{
   partial class TestForm
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
         this.btnAddOverlay = new System.Windows.Forms.Button();
         this.lblTestText = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // btnAddOverlay
         // 
         this.btnAddOverlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnAddOverlay.Location = new System.Drawing.Point(221, 161);
         this.btnAddOverlay.Name = "btnAddOverlay";
         this.btnAddOverlay.Size = new System.Drawing.Size(143, 41);
         this.btnAddOverlay.TabIndex = 0;
         this.btnAddOverlay.Text = "Add overlay";
         this.btnAddOverlay.UseVisualStyleBackColor = true;
         this.btnAddOverlay.Click += new System.EventHandler(this.btnAddOverlay_Click);
         // 
         // lblTestText
         // 
         this.lblTestText.AutoSize = true;
         this.lblTestText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTestText.Location = new System.Drawing.Point(80, 78);
         this.lblTestText.Name = "lblTestText";
         this.lblTestText.Size = new System.Drawing.Size(425, 31);
         this.lblTestText.TabIndex = 1;
         this.lblTestText.Text = "Test form with transparent overlay";
         // 
         // TestForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(584, 362);
         this.Controls.Add(this.lblTestText);
         this.Controls.Add(this.btnAddOverlay);
         this.MinimumSize = new System.Drawing.Size(600, 400);
         this.Name = "TestForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
         this.Text = "Form with overlay";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnAddOverlay;
      private System.Windows.Forms.Label lblTestText;
   }
}

