using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace RatAdventure
{
	public partial class AlertBox : Form
	{
		private AlertInfo tree;

		private int w = 350;
		private int h = 200;

		private Label currentText;
		private List<Button> currentButtons;

		public AlertBox(AlertInfo alertTree)
		{
			this.tree = alertTree;

			InitializeComponent();
			ResetContent();
		}

		private void ButtonNextClick(object sender, EventArgs e) {
			Button caller = (Button) sender;

			foreach (AlertInfo a in this.tree.buttons) {
				if (a.buttonText == caller.Text) {
					this.tree = a;

					if (a.HasHeader("PlayAudio")) {
						// MessageBox.Show("aaa");
						(new SoundPlayer(a.HeaderValue("PlayAudio"))).Play();
					}

					if (this.tree.buttons.Length == 0) {
						MessageBox.Show((a.buttonText != "yay") ? "you died" : "the rat has eatn chesse");
						Application.Exit();
						return;
					}
				}
			}

			this.Controls.Remove(this.currentText);
			foreach (Button b in this.currentButtons) {
				this.Controls.Remove(b);
			}

			this.ResetContent();
		}

		public void ResetContent() {

			this.currentText = new Label();
			this.currentButtons = new List<Button>();

			this.currentText.Text = this.tree.displayText;
			// MessageBox.Show(this.currentText.Text);

			this.currentText.Location = new Point(20, 20);
			this.currentText.TextAlign = ContentAlignment.MiddleCenter;

			this.currentText.AutoSize = true;
			this.currentText.Font = new Font("Calibri", 14);

			this.Controls.Add(this.currentText);


			int i = 1;
			int buttonSpacing = this.w / (this.tree.buttons.Length+1);
			// MessageBox.Show(buttonSpacing.ToString());

			foreach (AlertInfo a in this.tree.buttons) {
				Button newBtn = new Button();

				newBtn.AutoSize = true;
				newBtn.Text = a.buttonText;

				// if (a.buttonText == "") {
				// 	newBtn.Text = "";
				// 	Label laalalba = new Label();
				// 	laalalba.Text =
				// 	this.Controls.Add(laalalba);
				// }

				newBtn.Location = new Point((i*buttonSpacing)-newBtn.Width/2, this.h-50);

				newBtn.Click += new System.EventHandler(this.ButtonNextClick);

				this.currentButtons.Add(newBtn);
				this.Controls.Add(newBtn);

				i++;
			}

		}
	}
}
