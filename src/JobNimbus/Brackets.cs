namespace JobNimbus;

public class Brackets
{
    private readonly Dictionary<char, char> _brackets;
    private readonly char[] _openingBrackets;
    private readonly char[] _openCloseBrackets;

    public Brackets()
    {
        _brackets = CreateBrackets();

        _openingBrackets = _brackets.Select(x => x.Value).ToArray();        

        _openCloseBrackets = CreateOpenCloseBrackets();
    }

    public bool IsBracketsMatch(string input)
    {
        var openBracketStack = new Stack<char>();

        foreach (var c in input)
        {            
            if (!IsBracketExist(_openCloseBrackets, c))
                continue;

            if (IsBracketExist(_openingBrackets, c))
            { 
                openBracketStack.Push(c);
            }
            
            if (_brackets.TryGetValue(c, out var openingBracket))
            {                    
                if (openBracketStack.Count == 0)                                         
                    return false;                    

                var previousOpenBracket = openBracketStack.Pop();

                if (previousOpenBracket != openingBracket) 
                    return false;
            }
        }
       
        if (openBracketStack.Count > 0)            
            return false;            
        
        return true;
    }

    private static bool IsBracketExist(char[] brackets, char key) 
    {
        return brackets.Any(x => x == key);
    }

    private char[] CreateOpenCloseBrackets()
    {
        var closingBrackets = _brackets.Select(x => x.Key).ToArray();

        return _openingBrackets.Concat(closingBrackets).ToArray();
    }

    private static Dictionary<char, char> CreateBrackets()
    {
        return new Dictionary<char, char>
        {
            { '}', '{' },
            { ']', '[' },
            { ')', '(' }
        };
    }
}