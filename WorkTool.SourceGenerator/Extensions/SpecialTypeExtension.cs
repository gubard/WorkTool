﻿namespace WorkTool.SourceGenerator.Extensions;

public static class SpecialTypeExtension
{
    public static bool IsEnumerableType(this SpecialType type)
    {
        switch (type)
        {
            case SpecialType.None:                                                           return false;
            case SpecialType.System_Object:                                                  return false;
            case SpecialType.System_Enum:                                                    return false;
            case SpecialType.System_MulticastDelegate:                                       return false;
            case SpecialType.System_Delegate:                                                return false;
            case SpecialType.System_ValueType:                                               return false;
            case SpecialType.System_Void:                                                    return false;
            case SpecialType.System_Boolean:                                                 return false;
            case SpecialType.System_Char:                                                    return false;
            case SpecialType.System_SByte:                                                   return false;
            case SpecialType.System_Byte:                                                    return false;
            case SpecialType.System_Int16:                                                   return false;
            case SpecialType.System_UInt16:                                                  return false;
            case SpecialType.System_Int32:                                                   return false;
            case SpecialType.System_UInt32:                                                  return false;
            case SpecialType.System_Int64:                                                   return false;
            case SpecialType.System_UInt64:                                                  return false;
            case SpecialType.System_Decimal:                                                 return false;
            case SpecialType.System_Single:                                                  return false;
            case SpecialType.System_Double:                                                  return false;
            case SpecialType.System_String:                                                  return false;
            case SpecialType.System_IntPtr:                                                  return false;
            case SpecialType.System_UIntPtr:                                                 return false;
            case SpecialType.System_Array:                                                   return false;
            case SpecialType.System_Collections_IEnumerable:                                 return true;
            case SpecialType.System_Collections_Generic_IEnumerable_T:                       return true;
            case SpecialType.System_Collections_Generic_IList_T:                             return true;
            case SpecialType.System_Collections_Generic_ICollection_T:                       return true;
            case SpecialType.System_Collections_IEnumerator:                                 return true;
            case SpecialType.System_Collections_Generic_IEnumerator_T:                       return true;
            case SpecialType.System_Collections_Generic_IReadOnlyList_T:                     return true;
            case SpecialType.System_Collections_Generic_IReadOnlyCollection_T:               return true;
            case SpecialType.System_Nullable_T:                                              return false;
            case SpecialType.System_DateTime:                                                return false;
            case SpecialType.System_Runtime_CompilerServices_IsVolatile:                     return false;
            case SpecialType.System_IDisposable:                                             return false;
            case SpecialType.System_TypedReference:                                          return false;
            case SpecialType.System_ArgIterator:                                             return false;
            case SpecialType.System_RuntimeArgumentHandle:                                   return false;
            case SpecialType.System_RuntimeFieldHandle:                                      return false;
            case SpecialType.System_RuntimeMethodHandle:                                     return false;
            case SpecialType.System_RuntimeTypeHandle:                                       return false;
            case SpecialType.System_IAsyncResult:                                            return false;
            case SpecialType.System_AsyncCallback:                                           return false;
            case SpecialType.System_Runtime_CompilerServices_RuntimeFeature:                 return false;
            case SpecialType.System_Runtime_CompilerServices_PreserveBaseOverridesAttribute: return false;
            default:                                                                         return false;
        }
    }

    public static bool IsPrimitiveType(this SpecialType type)
    {
        switch (type)
        {
            case SpecialType.None:                                                           return false;
            case SpecialType.System_Object:                                                  return false;
            case SpecialType.System_Enum:                                                    return true;
            case SpecialType.System_MulticastDelegate:                                       return false;
            case SpecialType.System_Delegate:                                                return false;
            case SpecialType.System_ValueType:                                               return false;
            case SpecialType.System_Void:                                                    return false;
            case SpecialType.System_Boolean:                                                 return true;
            case SpecialType.System_Char:                                                    return true;
            case SpecialType.System_SByte:                                                   return true;
            case SpecialType.System_Byte:                                                    return true;
            case SpecialType.System_Int16:                                                   return true;
            case SpecialType.System_UInt16:                                                  return true;
            case SpecialType.System_Int32:                                                   return true;
            case SpecialType.System_UInt32:                                                  return true;
            case SpecialType.System_Int64:                                                   return true;
            case SpecialType.System_UInt64:                                                  return true;
            case SpecialType.System_Decimal:                                                 return true;
            case SpecialType.System_Single:                                                  return true;
            case SpecialType.System_Double:                                                  return true;
            case SpecialType.System_String:                                                  return true;
            case SpecialType.System_IntPtr:                                                  return true;
            case SpecialType.System_UIntPtr:                                                 return true;
            case SpecialType.System_Array:                                                   return false;
            case SpecialType.System_Collections_IEnumerable:                                 return false;
            case SpecialType.System_Collections_Generic_IEnumerable_T:                       return false;
            case SpecialType.System_Collections_Generic_IList_T:                             return false;
            case SpecialType.System_Collections_Generic_ICollection_T:                       return false;
            case SpecialType.System_Collections_IEnumerator:                                 return false;
            case SpecialType.System_Collections_Generic_IEnumerator_T:                       return false;
            case SpecialType.System_Collections_Generic_IReadOnlyList_T:                     return false;
            case SpecialType.System_Collections_Generic_IReadOnlyCollection_T:               return false;
            case SpecialType.System_Nullable_T:                                              return false;
            case SpecialType.System_DateTime:                                                return true;
            case SpecialType.System_Runtime_CompilerServices_IsVolatile:                     return false;
            case SpecialType.System_IDisposable:                                             return false;
            case SpecialType.System_TypedReference:                                          return false;
            case SpecialType.System_ArgIterator:                                             return false;
            case SpecialType.System_RuntimeArgumentHandle:                                   return false;
            case SpecialType.System_RuntimeFieldHandle:                                      return false;
            case SpecialType.System_RuntimeMethodHandle:                                     return false;
            case SpecialType.System_RuntimeTypeHandle:                                       return false;
            case SpecialType.System_IAsyncResult:                                            return false;
            case SpecialType.System_AsyncCallback:                                           return false;
            case SpecialType.System_Runtime_CompilerServices_RuntimeFeature:                 return false;
            case SpecialType.System_Runtime_CompilerServices_PreserveBaseOverridesAttribute: return false;
            default:                                                                         return false;
        }
    }
}