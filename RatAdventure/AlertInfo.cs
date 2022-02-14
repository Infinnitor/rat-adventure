using System;

namespace RatAdventure {
	public class AlertInfo {
		public String buttonText;
		public String displayText;

		public AlertInfo[] buttons;

		private String imagePath = "";

		public AlertInfo(String btn, String text, params AlertInfo[] alerts) {
			this.buttonText = btn;
			this.displayText = text;

			this.buttons = alerts;
		}

		public AlertInfo AddImage(String path) {
			this.imagePath = path;
			return this;
		}

		public void AddButton(params AlertInfo[] alerts) {
			this.buttons = alerts;
		}

		public AlertInfo Clone() {
			AlertInfo copy = new AlertInfo(this.buttonText, this.displayText);
			copy.buttons = this.buttons;
			return copy;
		}
	}
}
