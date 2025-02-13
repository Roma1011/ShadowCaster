using System.Reflection;

namespace ShadowCaster;

public class ShadowSeer
{
    public  static bool IsShadow(Type reference, Type? candidate)
    {
        if (reference is null)
            throw new InvalidOperationException("Reference can't be null");
        
        if(reference==candidate)
            return true;
        
        return false;
    }
    public static object? DuskWrap(PropertyInfo shadowProperty, object? shadowValue)
        => shadowValue is null ? default : Convert.ChangeType(shadowValue, shadowProperty.PropertyType);
}