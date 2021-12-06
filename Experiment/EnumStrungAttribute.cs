/// This is experemental version of file
/// Creator: NickName73
/// Version: 2.0 ~~ 3.0

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NiTiS.Core.Types;

namespace NiTiS.Experiment
{
	[System.AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
	public class StringEnumAttribute : System.Attribute{
		
	}
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class EnumValueNameAttribute : System.Attribute{
		protected string text;
		public EnumValueNameAttribute(string text){
			this.text = text;
		}
		public string Name => text;
	}
	[StringEnum]
	enum Values {
		[EnumValueName("Buble")]
		Zetta = 0,
		Gotta = 2,
	}
	
    public static class Runner 
    {
        public static int Main(string[] args) {
        	
        
        	Console.WriteLine(Values.Zetta.GetEnumValueName());
        	
        	return 0; //error code (if 0, without errors)
        }
        
    }
    public static class Helper {
    	public static string GetEnumValueName(this Enum enumer){
    		//Console.WriteLine(enumer.GetType().GetCustomAttributes(typeof(StringEnumAttribute),false)[0].GetType() == typeof(StringEnumAttribute));
    		if(enumer.GetType().GetCustomAttributes(typeof(StringEnumAttribute),false)[0].GetType() == typeof(StringEnumAttribute)){
    			//Console.WriteLine("F");
    			var field = enumer.GetType().GetField(Enum.GetName(enumer.GetType(),enumer));
    			EnumValueNameAttribute desc = field.GetCustomAttributes(typeof(EnumValueNameAttribute),false)[0] as EnumValueNameAttribute;
    			if(desc.GetType() == typeof(EnumValueNameAttribute)){
    				//Console.WriteLine("$");
    				return desc.Name;
    			}
    		}
    		return "";
    	}
    	public static void ForEach<ET>(this IEnumerable<ET> enm, Action<ET> act){
    		foreach(ET obj in enm){
    			act(obj);
    		
    		}
    	}
    	public static string Field = nameof(Field);
    	public static void ForEachToString<ET>(this IEnumerable<ET> enm){
    		enm.ForEach( (obj) =>{
    			if(obj == null){
    				return;
    			}
    			Console.WriteLine(obj.ToString());
    		} );
    	}
    	public static byte[] ASCIIBytes(this string str){
    		return Encoding.ASCII.GetBytes(str);
    	}
    	public static string ASCIIText(this byte[] array){
    		return new String(Encoding.ASCII.GetChars(array));
    	}
    }
}
