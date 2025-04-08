using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TypoMayhem.Data.Helpers
{
	public static class KeyboardHandler
	{
		public static char GetKeyChar(KeyboardDevice keyboard, Key key)
		{
			bool isShiftPressed = keyboard.IsKeyDown(Key.LeftShift) || keyboard.IsKeyDown(Key.RightShift);
			bool isControlPressed = keyboard.IsKeyDown(Key.LeftCtrl) || keyboard.IsKeyDown(Key.RightCtrl);
			bool isAltPressed = keyboard.IsKeyDown(Key.LeftAlt) || keyboard.IsKeyDown(Key.RightAlt);

			char character;
			if (key == Key.Space)
			{
				character = ' ';
			}
			else if (key == Key.Oem7 || key == Key.Oem1 || key == Key.Oem3)
			{
				switch (key)
				{
					case Key.Oem1: character = isShiftPressed ? 'Ü' : 'ü'; break;
					case Key.Oem7: character = isShiftPressed ? 'Ä' : 'ä'; break;
					case Key.Oem3: character = isShiftPressed ? 'Ö' : 'ö'; break;

					default:
						character = isShiftPressed ? '?' : 'ß';
						break;
				}
			}
			else if (key >= Key.D0 && key <= Key.D9 || key == Key.Oem4)
			{
				character = (char)('0' + (key - Key.D0));
				if (isShiftPressed)
				{
					switch (key)
					{
						case Key.D1: character = '!'; break;
						case Key.D2: character = '"'; break;
						case Key.D3: character = '§'; break;
						case Key.D4: character = '$'; break;
						case Key.D5: character = '%'; break;
						case Key.D6: character = '&'; break;
						case Key.D7: character = '/'; break;
						case Key.D8: character = '('; break;
						case Key.D9: character = ')'; break;
						case Key.D0: character = '='; break;
					}
				}
				else if (isAltPressed)
				{
					switch (key)
					{
						case Key.D7: character = '{'; break;
						case Key.D8: character = '['; break;
						case Key.D9: character = ']'; break;
						case Key.D0: character = '}'; break;
						case Key.Oem4: character = '\\'; break;
					}
				}
			}
			else if (key >= Key.NumPad0 && key <= Key.NumPad9)
			{
				character = (char)('0' + (key - Key.NumPad0));
			}
			else
			{
				switch (key)
				{
					case Key.OemComma: character = isShiftPressed ? ';' : ','; break;
					case Key.OemPeriod: character = isShiftPressed ? ':' : '.'; break;
					case Key.OemMinus: character = isShiftPressed ? '_' : '-'; break;
					case Key.OemPlus: character = isShiftPressed ? '*' : '+'; break;
					case Key.OemQuestion: character = isShiftPressed ? '\'' : '#'; break;
					case Key.OemSemicolon: character = isShiftPressed ? ':' : ';'; break;
					case Key.OemQuotes: character = isShiftPressed ? '"' : '\''; break;
					case Key.OemTilde: character = isShiftPressed ? '~' : '`'; break;
					case Key.OemBackslash: character = isShiftPressed ? '|' : '\\'; break;
					case Key.Oem4: character = isShiftPressed ? '?' : 'ß'; break;

					default:
						character = key.ToString().ToLower()[0];
						if (isShiftPressed)
						{
							character = char.ToUpper(character);
						}
						break;
				}
			}
			return character;
		}
	}
}
