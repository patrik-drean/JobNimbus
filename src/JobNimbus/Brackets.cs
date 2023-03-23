namespace JobNimbus;

public class Brackets
{   
    public bool IsBracketsMatch(string input)
    {
        var openBrackets = new Stack<char>();
       
        foreach (var c in input)
        {
            if (c == '{')                                  
                openBrackets.Push(c);
            
            else if (c == '}')
            {                    
                if (openBrackets.Count == 0)                                         
                    return false;                    

                var lastOpenBracket = openBrackets.Pop();

                if (lastOpenBracket != '{')                                        
                    return false;                    
            }
        }
       
        if (openBrackets.Count > 0)            
            return false;            
        
        return true;
    }
}