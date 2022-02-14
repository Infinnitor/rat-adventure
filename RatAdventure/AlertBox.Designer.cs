using System;

﻿namespace RatAdventure
{
	partial class AlertBox
	{
		// WINFORMS STUFF: Required designer variable.
		private System.ComponentModel.IContainer components = null;

		// WINFORMS STUFF: Clean up any resources being used.
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		// winforms method that i am editing
		private void InitializeComponent() {

			var ratImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(ratImage)).BeginInit();

			String ratPath = @"data\rat.png";
			ratImage.Image = System.Drawing.Image.FromFile(ratPath);
			ratImage.Location = new System.Drawing.Point(this.w/2 - 50,this.h/3);
			// ratImage.Size = new System.Drawing.Size(48, 40);
			ratImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			ratImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			// ratImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;

			this.components = new System.ComponentModel.Container();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(this.w, this.h);
			this.Text = "rAT";

				 // ((System.ComponentModel.ISupportInitialize)(alertStoryText)).EndInit();

			this.Controls.Add(ratImage);
		}
	}
}
