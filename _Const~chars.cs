namespace Ans.Net6.Web
{

	public static partial class _Const
	{

		//	Пробельные символы:
		//		UnicodeCategory.SpaceSeparator
		public const char CHAR_SP101 = (char)0x0020; // пробел (U+0020)
		public const char CHAR_SP102 = (char)0x00A0; // неразрывный пробел (U+00A0),
		public const char CHAR_SP103 = (char)0x1680; // знак пробела (U+1680),
		public const char CHAR_SP104 = (char)0x2000; // 2 000 (U+2000),
		public const char CHAR_SP105 = (char)0x2001; // четыре EM (U+2001),
		public const char CHAR_SP106 = (char)0x2002; // EN-пробел (U+2002),
		public const char CHAR_SP107 = (char)0x2003; // EM (U+2003),
		public const char CHAR_SP108 = (char)0x2004; // 2–4 EM (U+2004),
		public const char CHAR_SP109 = (char)0x2005; // четыре на EM (U+2005)
		public const char CHAR_SP110 = (char)0x2006; // шесть на EM (U+2006),
		public const char CHAR_SP111 = (char)0x2007; // фигурный пробел (U+2007),
		public const char CHAR_SP112 = (char)0x2008; // знак препинания (U+2008),
		public const char CHAR_SP113 = (char)0x2009; // тонкий пробел (U+2009),
		public const char CHAR_SP114 = (char)0x200A; // пробелы (U+200A),
		public const char CHAR_SP115 = (char)0x202F; // узкие пространства без перерыва (U+202F),
		public const char CHAR_SP116 = (char)0x205F; // среднее математическое пространство (U+205F),
		public const char CHAR_SP117 = (char)0x3000; // идеографический пробел (U+3000).

		//		UnicodeCategory.LineSeparator
		public const char CHAR_SP201 = (char)0x2028; // символ разделителя строк (U+2028).

		//		UnicodeCategory.ParagraphSeparator
		public const char CHAR_SP301 = (char)0x2029; // символ разделителя абзаца (U+2029).

		//		Others
		public const char CHAR_SP401 = (char)0x0009; // табуляция (U+0009),
		public const char CHAR_SP402 = (char)0x000A; // перевод строки (U+000A;),
		public const char CHAR_SP403 = (char)0x000B; // Текстовая строка (U+000B),
		public const char CHAR_SP404 = (char)0x000C; // веб-канал формы (U+000C),
		public const char CHAR_SP405 = (char)0x000D; // возврат каретки (U+000D)		
		public const char CHAR_SP406 = (char)0x0085; // следующая строка (U+0085).


		public const char CHAR_Space = (char)0x160;
		public const char CHAR_EnSpace = (char)0x8194;
		public const char CHAR_EmSpace = (char)0x8195;
		public const char CHAR_SHy = (char)0x173;
		public const char CHAR_EnDash = '–';
		public const char CHAR_EmDash = '—';

		public const char CHAR_Copy = '©';
		public const char CHAR_Reg = '®';
		public const char CHAR_Trade = '™';
		public const char CHAR_OrdM = 'º';
		public const char CHAR_OrdF = 'ª';
		public const char CHAR_PerMil = '‰';
		public const char CHAR_Pi = 'π';
		public const char CHAR_BrVBar = '¦';
		public const char CHAR_Sect = '§';
		public const char CHAR_Deg = '°';
		public const char CHAR_Micro = 'µ';
		public const char CHAR_Para = '¶';
		public const char CHAR_Hellip = '…';
		public const char CHAR_OLine = '‾';
		public const char CHAR_Acute = '´';
		public const char CHAR_Amp = '&';
		public const char CHAR_Tilde = '˜';
		public const char CHAR_Circ = 'ˆ';
		public const char CHAR_Uml = '¨';
		public const char CHAR_Macr = '¯';
		public const char CHAR_Cedil = '¸';
		public const char CHAR_IQuest = '¿';
		public const char CHAR_IExcl = '¡';
		public const char CHAR_Curren = '¤';
		public const char CHAR_CrArr = '↵';

		public const char CHAR_Multiply = '×';
		public const char CHAR_Divide = '÷';
		public const char CHAR_Lt = '<';
		public const char CHAR_Gt = '>';
		public const char CHAR_PlusMn = '±';
		public const char CHAR_Sup1 = '¹';
		public const char CHAR_Sup2 = '²';
		public const char CHAR_Sup3 = '³';
		public const char CHAR_Not = '¬';
		public const char CHAR_Frac14 = '¼';
		public const char CHAR_Frac12 = '½';
		public const char CHAR_Frac34 = '¾';
		public const char CHAR_Frasl = '⁄';
		public const char CHAR_Minus = '−';
		public const char CHAR_Le = '≤';
		public const char CHAR_Ge = '≥';
		public const char CHAR_Asymp = '≈';
		public const char CHAR_Ne = '≠';
		public const char CHAR_Equiv = '≡';
		public const char CHAR_Radic = '√';
		public const char CHAR_Infin = '∞';
		public const char CHAR_Sum = '∑';
		public const char CHAR_Prod = '∏';
		public const char CHAR_Part = '∂';
		public const char CHAR_Int = '∫';
		public const char CHAR_ForAll = '∀';
		public const char CHAR_Exist = '∃';
		public const char CHAR_Empty = '∅';
		public const char CHAR_OSlash = 'Ø';
		public const char CHAR_Isin = '∈';
		public const char CHAR_NotIn = '∉';
		public const char CHAR_Ni = '∋';
		public const char CHAR_Sub = '⊂';
		public const char CHAR_Sup = '⊃';
		public const char CHAR_NSub = '⊄';
		public const char CHAR_Sube = '⊆';
		public const char CHAR_Supe = '⊇';
		public const char CHAR_OPlus = '⊕';
		public const char CHAR_OTimes = '⊗';
		public const char CHAR_Perp = '⊥';
		public const char CHAR_Ang = '∠';
		public const char CHAR_And = '∧';
		public const char CHAR_Or = '∨';
		public const char CHAR_Cap = '∩';
		public const char CHAR_Cup = '∪';

		public const char CHAR_Euro = '€';
		public const char CHAR_Cent = '¢';
		public const char CHAR_Pound = '£';
		public const char CHAR_Yen = '¥';
		public const char CHAR_Fnof = 'ƒ';

		public const char CHAR_Bull = '•';
		public const char CHAR_MidDot = '·';
		public const char CHAR_Dagger = '†';
		public const char CHAR_DDager = '‡';
		public const char CHAR_Spades = '♠';
		public const char CHAR_Clubs = '♣';
		public const char CHAR_Hearts = '♥';
		public const char CHAR_Diams = '♦';
		public const char CHAR_Loz = '◊';

		public const char CHAR_Quot = '"';
		public const char CHAR_Lsquo = '‘';
		public const char CHAR_Rsquo = '’';
		public const char CHAR_Sbquo = '‚';
		public const char CHAR_Lsaquo = '‹';
		public const char CHAR_Rsaquo = '›';
		public const char CHAR_Ldquo = '“';
		public const char CHAR_Rdquo = '”';
		public const char CHAR_Bdquo = '„';
		public const char CHAR_Laquo = '«';
		public const char CHAR_Raquo = '»';
		public const char CHAR_Prime = '′';
		public const char CHAR_DPrime = '″';

		public const char CHAR_ArrowLeft = '←';
		public const char CHAR_ArrowRight = '→';
		public const char CHAR_ArrowUp = '↑';
		public const char CHAR_ArrowDown = '↓';
		public const char CHAR_ArrowLeftRight = '↔';
		public const char CHAR_ArrowUpDown = '↕';
		public const char CHAR_ArrowDLeft = '⇐';
		public const char CHAR_ArrowDRight = '⇒';
		public const char CHAR_ArrowDUp = '⇑';
		public const char CHAR_ArrowDDown = '⇓';
		public const char CHAR_ArrowDLeftRight = '⇔';
		public const char CHAR_ArrowDUpDown = '⇕';

		public const char CHAR_Dot = (char)0xB7;
		public const char CHAR_CursorLeft = (char)0x21E6;
		public const char CHAR_CursorRight = (char)0x21E8;
		public const char CHAR_CursorUp = (char)0x21E7;
		public const char CHAR_CursorDown = (char)0x21E9;
		public const char CHAR_DirectLeft = (char)0x25C4;
		public const char CHAR_DirectRight = (char)0x25BA;
		public const char CHAR_DirectUp = (char)0x25B2;
		public const char CHAR_DirectDown = (char)0x25BC;
		public const char CHAR_Cross = (char)0x2718;
		public const char CHAR_CrossB = (char)0x2716;
		public const char CHAR_CrossI = (char)0x2717;
		public const char CHAR_Select = (char)0x2713;
		public const char CHAR_SelectI = (char)0x2714;
		public const char CHAR_Pointer = (char)0x279D;
		public const char CHAR_PointerB = (char)0x27A1;
		public const char CHAR_PointerD = (char)0x279F;
		public const char CHAR_PointerDB = (char)0x27A0;
		public const char CHAR_PointerS = (char)0x279E;

		//public const UTF16 CHAR_Info = '🛈';
		public const char CHAR_StarBold = '✱';
		public const char CHAR_Circle = '⚪';
		public const char CHAR_CircleF = '⚫';
		public const char CHAR_Star = '★';
		public const char CHAR_StarLight = '☆';
		public const char CHAR_StarCircle = '✪';
		public const char CHAR_StarAroundInside = '✫';
		public const char CHAR_StarRevolving = '✯';
		public const char CHAR_StarWhite = '⚝';
		public const char CHAR_StarRotatingEight = '✵';
		public const char CHAR_Star12 = '✹';
		public const char CHAR_Star8Bold = '✸';
		public const char CHAR_Star6 = '✶';
		public const char CHAR_Star8Shaded = '✷';
		public const char CHAR_Star8 = '✴';
		public const char CHAR_Star8Light = '✳';
		public const char CHAR_StarInCircle = '⍟';
		public const char CHAR_Snowflake = '❄';
		public const char CHAR_SnowflakeTrefoil = '❅';
		public const char CHAR_SnowflakeAngled = '❆';
		public const char CHAR_SnowflakeSextile = '⚹';
		public const char CHAR_SnowflakeInCircle = '⊛';
		public const char CHAR_Asterisk = '❉';
		public const char CHAR_AsteriskPropeller = '❋';
		public const char CHAR_Asterisk16 = '✺';
		public const char CHAR_AsteriskCenter = '✲';
		public const char CHAR_SharpLight = '✧';
		public const char CHAR_Sharp = '✦';
		public const char CHAR_Snowman = '☃';

	}

}
