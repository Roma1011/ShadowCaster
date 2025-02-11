﻿using System.Reflection;

namespace ShadowCaster;

public sealed class Caster
{
    /// <summary>
    /// Execute a mapping from the source object to a new destination object.
    /// The source type is inferred from the source object.
    /// </summary>
    /// <typeparam name="TDestination">Destination type to create</typeparam>
    /// <param name="source">Source object to map from</param>
    /// <param name="shadowType">Selectable types,to which members type need to cast default by property</param>
    /// <param name="characterCasing">Specifies the case of characters typed manually</param>
    /// <returns>Mapped destination object</returns>
    public TDestination AsDestination<TDestination>(object source,ShadowType shadowType=ShadowType.ByProp,CharacterCasing characterCasing=CharacterCasing.Normal) where TDestination:new()
    {
        if (source is null)
            throw new InvalidCastException("Source object cannot be null");
        
        Dictionary<string, object?> transformWarehouse=new();
        switch (shadowType)
        {
            case ShadowType.KeyValue:
            {   
                Dictionary<string, object?>? sourceDic = source as Dictionary<string, object?>;
                if (sourceDic is null)
                    throw new InvalidOperationException("The source must be a non-null Dictionary<string, object?>. Please ensure the source is of the correct type.");
                
                TDestination tDest = new();
                PropertyInfo[] destProps=GetProperties(tDest);
                foreach (var prop in destProps)
                {
                    sourceDic!.TryGetValue(CharacterCaster.Cast(prop.Name,characterCasing), out object? value);
                    if (value is not null)
                        prop.SetValue(tDest,value);
                }
                return tDest;
            }
            default:
            {
                PropertyInfo[] sourceProps = GetProperties(source);
                TransformDataFromPropInfo(source,sourceProps,ref transformWarehouse);
                TDestination tDest = new();
                PropertyInfo[] destProps=GetProperties(tDest);
                foreach (var prop in destProps)
                {
                    transformWarehouse.TryGetValue(CharacterCaster.Cast(prop.Name,characterCasing), out object? value);
                    if (value is not null)
                        prop.SetValue(tDest,value);
                }
                return tDest;
            }
        }
    }
    private PropertyInfo[] GetProperties(object source)
    {
        if (source is null)
            throw new InvalidCastException("Source object cannot be null");
        return (source as Type)!.GetTypeInfo().DeclaredProperties.ToArray();
    }
    private void TransformDataFromPropInfo(object source,PropertyInfo[] propertyInfos,ref Dictionary<string, object?> transformWarehouse,CharacterCasing characterCasing=CharacterCasing.Normal)
    {
        for (short i = 0; i < propertyInfos.Length; i++)
            transformWarehouse.Add(CharacterCaster.Cast(propertyInfos[i].Name,characterCasing),propertyInfos[i].GetValue(source));
    }
}
