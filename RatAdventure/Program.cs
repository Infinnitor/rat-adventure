using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RatAdventure
{
	static class Program
	{

		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new AlertBox(SpawnTree()));
		}

		static AlertInfo LinearTreeMut(AlertInfo start, String[] muchoTexto) {
			AlertInfo current = start;
			foreach (String text in muchoTexto) {
				AlertInfo appendNode = new AlertInfo("ok", text);
				current.AddButton(appendNode);
				current = appendNode;
			}

			return current;
		}

		static AlertInfo Rat1() {
				AlertInfo start = new AlertInfo("rat1", "you ch00se rat One1");
				LinearTreeMut(start, Data.Rat1);
				return start;
		}

		static AlertInfo Rat5() {
			AlertInfo start = new AlertInfo("rat Five", "YOU CHO0SE RAT FIVE").AddHeader("PlayAudio", @"data\monster.wav");
			AlertInfo last = LinearTreeMut(start, Data.Rat5_1);

			AlertInfo yes = new AlertInfo("yeah", "HELL YEA MOTHER.FUCKER");
			AlertInfo no = new AlertInfo("nope", "OK BRO THAT'S FINE, NOT EVERYONE HAS THE SAME TASTES,, BITCH!");

			LinearTreeMut(yes, Data.Rat5_2);
			LinearTreeMut(no, Data.Rat5_2);
			last.AddButton(new AlertInfo("ok", "YOU EVER EAT CHEESE?", yes, no));

			return start;
		}

		static AlertInfo SpawnTree() {
			AlertInfo fakeBranch = new AlertInfo(
				"...", "it says the first rat needs the cheese",
				new AlertInfo(
					"...", "a fifth rat comes in and says the second rat does not need cheese",
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
