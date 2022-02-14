using System;
using System.Collections.Generic;

namespace RatAdventure {
	public class AlertInfo {
		public String buttonText;
		public String displayText;

		public AlertInfo[] buttons;

		private const int textWrapChar = 30;

		private Dictionary<String, String> headers = new Dictionary<String, String>();
		// HEADERS:
		// PlayAudio : Audio Path
		// ChangeImage : Image Path
		// Die : idk what this is

		public AlertInfo(String btn, String text, params AlertInfo[] alerts) {
			this.buttonText = btn;
			this.displayText = wrapText(text);

			this.buttons = alerts;
		}

		private String wrapText(String text) {
			String realText = text;
			if (realText.Length > textWrapChar) {
				int i = textWrapChar;
				while (realText[i] != ' ' && i < realText.Length-1) {
					i++;
				}

				// This is to edit the character in the text lol (mutability moment)
				char[] chars = realText.ToCharArray();
				chars[i] = '\n';
				realText = new String(chars);
			}

			return realText;
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
