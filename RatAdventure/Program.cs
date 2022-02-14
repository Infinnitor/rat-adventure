using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RatAdventure
{
	static class Program
	{
		private const int textWrapChar = 30;

		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new AlertBox(SpawnTree()));
		}

		static void LinearTreeMut(AlertInfo start, String[] muchoTexto) {
			AlertInfo current = start;
			foreach (String text in muchoTexto) {
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

				AlertInfo appendNode = new AlertInfo("ok", realText);
				current.AddButton(appendNode);
				current = appendNode;
			}
		}

		static AlertInfo Rat1() {
				AlertInfo start = new AlertInfo("rat1", "you ch00se rat One1");
				LinearTreeMut(start, Data.Rat1);
				return start;
		}

		static AlertInfo Rat5() {
			AlertInfo start = new AlertInfo("rat Five", "YOU CHO0SE RAT FIVE");
			LinearTreeMut(start, Data.Rat5);
			return start;
		}

		static AlertInfo SpawnTree() {
			AlertInfo fakeBranch = new AlertInfo(
				"...", "it says the first rat needs the cheese",
				new AlertInfo(
					"...", "a fifth rat comes in and says\nthe second rat does not need cheese",
					new AlertInfo(
						"w", "whcih rat do you fgive the chesse",
						// new AlertInfo("rat 1", ""),
						Rat1(),
						new AlertInfo("rat2two", ""),
						Rat5(),
						new AlertInfo(
							"4", "correct!!!!",
							new AlertInfo("yay", "")
						)
					)
				)
			);

			AlertInfo start = new AlertInfo(
				"2", "two rats are comming",
				new AlertInfo(
					"ok", "one says the other is lieing",
					new AlertInfo(
						"ok,", "the other wants cheese",
						new AlertInfo(
							"rat1", "a third rat comes in you took too long",
							fakeBranch
						),
						new AlertInfo(
							"give cheese to2", "a third rat comes in you took too long",
							fakeBranch
						)
					)
				)
			);
			return start;
		}
	}
}
