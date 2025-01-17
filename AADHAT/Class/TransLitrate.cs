using System;
using System.Text;

namespace HindiTranslitration
{
	class TransLitrate
	{

		static bool isConsonent(char a,bool hflag)
		{
			string str = "aieouh";
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == a)
				{
					return false;
				}
			}
			return true;
		}
		static bool isTrueVowel(char a)
		{
			string str = "aieou";
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == a)
				{
					return true;
				}
			}
			return false;
		}
		static bool isDigit(char a)
		{
			string str = "0123456789";
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == a)
				{
					return true;
				}
			}
			return false;
		}
		static bool isPunct(char a)
		{
			string str = ",.><?/+=-_}{[]*&^%$#@!~`\"\\|:;";
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == a)
				{
					return true;
				}
			}
			return false;
		}
		static bool isVowel(char a)
		{
			string str = "aieouh";
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == a)
				{
					return true;
				}
			}
			return false;
		}
		static bool isSpecial(char a)
		{
			string str = "hy";
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == a)
				{
					return true;
				}
			}
			return false;
		}
		static string GetMatra(string str)
		{
			int i = 0;
			if(str.Length<1)
			{
				return "्";
			}
			while (str[i] == 'h')
			{
				i++;
				if (i >= str.Length)
				{
					break;
				}
			}
			if (i < str.Length)
			{
				str = str.Substring(i);
			}
			if (str == "aa")
			{
				return "ा";
			}
			if (str == "ai")
			{
				return "ै";
			}
			else if (str=="e")
			{
				return "े";
			}
			else if (str == "ee")
			{
				return "ी";
			}
			else if (str == "i")
			{
				return "ि";
			}
			else if (str == "u")
			{
				return "ु";
                
			}
			else if (str == "oo")
			{
				return "ू";
			}
			else if (str == "o")
			{
				return "ो";
			}
			else if (str == "h")
			{
				return "";
			}
			else if (str == "hh")
			{
				return "";
			}
			return "";
          
		}
		static string GethShift(string str,ref int totalCoreSoundCharacter)
		{
			//खगघङचछजटठडढणतथदधनपफमयरऱलवशषसह
			totalCoreSoundCharacter=2;
			if (str.IndexOf("kh") == 0)
			{
				return "ख";
			}
			else if (str.IndexOf("gh") == 0)
			{
				return "घ";
			}
			else if (str.IndexOf("bh") == 0)
			{
				return "भ";
			}
			else if (str.IndexOf("chh") == 0)
			{
				totalCoreSoundCharacter=3;
				return "छ";
			}
			else if (str.IndexOf("ch") == 0)
			{
				return "च";
			}
			else if (str.IndexOf("jh") == 0)
			{
				return "झ";
			}
			else if (str.IndexOf("thh") == 0)
			{
				totalCoreSoundCharacter=3;
				return "ट";
			}
			else if (str.IndexOf("th") == 0)
			{
				return "थ";
			}
			else if (str.IndexOf("gh") == 0)
			{
				return "घ";
			}
			else if (str.IndexOf("dhh") == 0)
			{
				totalCoreSoundCharacter=3;
				return "ड";
			}
			else if (str.IndexOf("dh") == 0)
			{
				return "ध";
			}
			else if (str.IndexOf("shh") == 0)
			{
				totalCoreSoundCharacter=3;
				return "ष";
			}
			else if (str.IndexOf("sh") == 0)
			{
				return "श";
			}
			else if (str.IndexOf("rh") == 0)
			{
				return "ण";
			}
			else if (str.IndexOf("h")>=1)
			{
				/*
				 * VERY IMORTANT STEP
				 * */
				string sound="";
				totalCoreSoundCharacter=0;
				foreach(char c in str)
				{
					if(!isTrueVowel(c))
					{
						sound=sound+ResolveCharacterSound(c);
						totalCoreSoundCharacter++;
					}
					else
					{
						break;
					}
					
				}
				return sound;

			}
			totalCoreSoundCharacter=1;
			return null;
		}
		static string GetCoreSound(string str, ref int totalCoreSoundCharacter)
		{
			string soundmap = "अबसदइफगहईजकलमनओपकरसतउववज़यज";
			string h_shift = GethShift(str,ref totalCoreSoundCharacter);
			if (h_shift == null)
			{
				int position = ((str[0]) - 'a');
				if (position < soundmap.Length && position >= 0)
				{
					return "" + soundmap[position];
				}
				totalCoreSoundCharacter=1;
				return str;

			}
			else
			{
				return h_shift;
			}
		}
		static string GetSpecialSound(string str)
		{
			//अआइईउऊऑऒओऔ
			if (str == "aa")
			{
				return "आ";
			}
			else if (str == "au")
			{
				return "औ";
			}
			else if (str == "e")
			{
				return "इ";
			}
			else if (str == "ee")
			{
				return "ई";
			}
			else if (str == "i")
			{
				return "इ";
			}
			else if (str == "o")
			{
				return "ओ";
			}
			else if (str == "x")
			{
				return "एक्स";
			}
			return null;

		}
		static string ResolveCharacterSound(char c)
		{
			string str = "" + c;
			int totalCoreSoundCharacter=0;
			if(isPunct(c))
			{
				return str;
			}
			else if (isDigit(c))
			{
				return "" + (char)('०' + (c - '0'));
			}
			else if (isConsonent(str[0], false))
			{
				return "" + GetCoreSound(str,ref totalCoreSoundCharacter) + "्";
			}
			else
			{
				return "" + GetCoreSound(str,ref totalCoreSoundCharacter);
			}
		}
		static string GetSound(string str)
		{
			int totalCoreSoundCharacter=0;
			str = str.ToLower().Trim();
			if (str == null || str == "")
			{
				return "";
			}
			string SpecialSound = GetSpecialSound(str);
			if (SpecialSound != null)
			{
				return SpecialSound;
			}
			if (str.Length == 1)
			{

				return ResolveCharacterSound(str[0]);            
           
			}
			else
			{
                
				string core_sound=GetCoreSound(str,ref totalCoreSoundCharacter);
				string matra="";
				try
				{
					matra =GetMatra(str.Substring(totalCoreSoundCharacter));
				}
				catch(Exception exp)
				{
					matra="";
				}
				return "" + core_sound + matra;
			}
			//return str;
            
		}
		public static string SuperTrim(string str)
		{
			while(true)
			{
				string trimmed=str.Replace("  "," ");
				if(trimmed.Length==str.Length)
				{
					break;
				}
				str=trimmed;
			}
			
			return str;
		}
		public static string DoTransLitrate(string str)
		{
			int i=0;
			string ret="";
			int pi = 0;
			bool vowelFlag = false;
			str = str.ToLower();
			while (i<str.Length)
			{

				try
				{

					if ((str[i] == 'h' && vowelFlag) || (isConsonent(str[i], vowelFlag) && i > 0) 
						|| (str[i] == ' ')
						|| isPunct(str[i])
						|| isDigit(str[i])
						|| ((i - pi) > 5))
					{
						if (pi < i)
						{
							ret += GetSound(str.Substring(pi, i - pi));
						}
						if (str[i] == ' ')
						{
							ret += ' ';
						}
						if (((str[i] == ' ') || isPunct(str[i])))
						{
							ret += str[i];
							pi = i + 1;
						}
						else if(isDigit(str[i]))
						{
							string digi = "" + (char)('०' + (str[i] - '0'));
							ret += digi;
							pi = i + 1;
						}
						else
						{
							pi = i;
						}
						vowelFlag = false;

					}
					else if (isVowel(str[i]) && str[i] != 'h')
					{
						vowelFlag = true;
					}
					++i;
				}
				catch (Exception exp)
				{
					ret += "error!!";
				}
			}
			if (pi < i)
			{
				try
				{
					ret += GetSound(str.Substring(pi, i - pi));
				}
				catch (Exception exp)
				{
					ret += "error!!";
				}
			}
			return SuperTrim(ret);
		}
	}
}
