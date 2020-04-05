<Query Kind="Statements" />

Func<string, KeyValuePair<string, string>> SeparateKeyAndLetters = (keyAndLetters) =>
{
	var line = keyAndLetters.Replace(" ", "").Split('=');
	return new KeyValuePair<string, string>(line[0], line[1]);
};

Func<KeyValuePair<string, string>, IEnumerable<KeyValuePair<string, string>>> SwitchValuesAndKeys = (keyValue) =>
{
	return keyValue.Value.ToCharArray().Distinct().Where(ch => char.IsLetter(ch)).Select(ch => new KeyValuePair<string, string>(ch.ToString(), keyValue.Key));
};

Func<string, Dictionary<string, string>, string> ReplaceLettersWithKeys = (word, letterKeyDic) =>
{
	var replaces = word.ToUpper().ToCharArray().Where(ch => char.IsLetter(ch)).Select(ch => letterKeyDic[ch.ToString()]);
	return string.Join("", replaces);
};


var keyPadDic = @"2 = ABC2
                     3 = DEF3
                     4 = GHI4
                     5 = JKL5
                     6 = MNO6
                     7 = PQRS7
                     8 = TUV8
                     9 = WXYZ9".Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
.Select(keyPadCombination => SeparateKeyAndLetters(keyPadCombination))
.Select(keyValues => SwitchValuesAndKeys(keyValues))
.SelectMany(pivotedValues => pivotedValues.Select(rec => new { key = rec.Key, value = rec.Value }))
.ToDictionary(rec => rec.key, rec => rec.value); ;



var keyPress = "4663";

var sr = new StreamReader("C:\\T9.txt");
string total = sr.ReadToEnd();
sr.Close();

total
.Split(new[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries)
.Where(word => word.Length == keyPress.Length)
.Select(word => new { word = word, code = ReplaceLettersWithKeys(word, keyPadDic)})
.Where(result => result.code == keyPress)
.Select(col => col.word)
.Dump();


