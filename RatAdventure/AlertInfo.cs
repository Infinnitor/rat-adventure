using System;
using System.Collections.Generic;

namespace RatAdventure {
	public class AlertInfo {
		public String buttonText;
		public String displayText;

		public AlertInfo[] buttons;

		private Dictionary<String, String> headers = new Dictionary<String, String>();
		// HEADERS:
		// PlayAudio : Audio Path
		// ChangeImage : Image Path
		// Die

		public AlertInfo(String btn, String text, params AlertInfo[] alerts) {
			this.buttonText = btn;
			this.displayText = text;

			this.buttons = alerts;
		}

		public AlertInfo AddHeader(String h, String v) {
			headers.Add(h, v);
			return this;
		}

		public bool HasHeader(String h) {
			return headers.ContainsKey(h);
		}

		public String HeaderValue(String h) {
			return headers[h];
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
