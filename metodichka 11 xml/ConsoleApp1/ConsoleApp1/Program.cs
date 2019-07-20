using System;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
		//-- 6 --


		/// <summary>
		///The <c>Distance</c> class provides methods 
		///for converting kilometers to and from miles.
		/// </summary>
		public class Distance
		{
			/// <summary>
			///Converts kilometers to miles.
			/// </summary>
			/// <param name="kilometers">
			///Used to indicate kilometers. 
			///A <see cref="double"/>
			///type representing a value.
			/// </param>
			/// <exception cref="ArgumentException">
			///If <paramref name="kilometers"/>
			///is negative.
			/// </exception>
			/// <returns>Returns the distance in miles.
			/// </returns>
			public static double KilometersToMiles(double kilometers)
			{
				if (kilometers < 0)
				{
					throw new ArgumentException("The value must be positive.");
				}

				return kilometers * 0.621371;
			}

			/// <summary>
			///Converts miles to kilometers.
			/// <param name="miles">
			///Used to indicate miles. 
			/// A <see cref="double"/>type representing a value.
			/// </param>
			/// <exception cref="ArgumentException">
			///If <paramref name="miles"/>is negative.
			/// </exception>
			/// <returns>Returns the distance in 
			///kilometers.</returns>
			public static double MilesToKilometers(double miles)
			{
				if (miles < 0)
				{
					throw new ArgumentException("The value must be positive.");
				}

				return miles * 1.60934;
			}
		}

			// -- 2	--

			static void OutputNode(XmlNode node)
		{
			Console.WriteLine($"Type={node.NodeType}\tName={ node.Name}\tValue ={ node.Value}");

			if (node.HasChildNodes)
			{
				foreach (XmlNode child in node.ChildNodes)
					OutputNode(child);
			}
		}

		static void Main(string[] args)
        {
			// -- 1 --

			//XmlTextWriter writer = null;

			//         try
			//         {
			//             writer = new XmlTextWriter("Cars.xml", System.Text.Encoding.Unicode);
			//             writer.Formatting = Formatting.Indented;
			//             writer.WriteStartDocument();
			//             writer.WriteStartElement("Cars");
			//             writer.WriteStartElement("Car");
			//             writer.WriteAttributeString("Image", "MyCar.jpeg");
			//             writer.WriteElementString("Manufactured", "La Hispano Suiza de Automovils");
			//             writer.WriteElementString("Model", "Alfonso");
			//             writer.WriteElementString("Year", "1912");
			//             writer.WriteElementString("Color", "Black");
			//             writer.WriteElementString("Speed", "130");
			//             writer.WriteEndElement();
			//             Console.WriteLine("The Cars.xml file is generated!");
			//         }
			//         catch (Exception ex)
			//         {
			//             Console.WriteLine(ex.Message);
			//         }
			//         finally
			//         { 
			//	if (writer != null) writer.Close();
			//         }


			//-- 2 --

			//try
			//{
			//	XmlDocument doc = new XmlDocument();
			//	doc.Load("Cars.xml");
			//	OutputNode(doc.DocumentElement);
			//}
			//catch (Exception ex)
			//{
			//	Console.WriteLine(ex.Message);
			//}



			//-- 3 --

			//try
			//{
			//	XmlDocument doc = new XmlDocument();
			//	doc.Load("Cars.xml");
			//	XmlNode root = doc.DocumentElement; 

			//	// удалить первый элемент Cars
			//	root.RemoveChild(root.FirstChild); 

			//	// создать узлы элементов.
			//	XmlNode bike = doc.CreateElement("Motorcycle");
			//	XmlNode elem1 = doc.CreateElement("Nanufactured");
			//	XmlNode elem2 = doc.CreateElement("Model");
			//	XmlNode elem3 = doc.CreateElement("Year");
			//	XmlNode elem4 = doc.CreateElement("Color");
			//	XmlNode elem5 = doc.CreateElement("Engine"); 

			//	// создать текстовые узлы
			//	XmlNode text1 = doc.CreateTextNode("Harley-Davidson Motor Co.Inc.");
			//	XmlNode text2 = doc.CreateTextNode("Harley 20J");
			//	XmlNode text3 = doc.CreateTextNode("1920");
			//	XmlNode text4 = doc.CreateTextNode("Olive");
			//	XmlNode text5 = doc.CreateTextNode("37 HP");

			//	// присоединить текстовые узлы к узлам элементов
			//	elem1.AppendChild(text1);
			//	elem2.AppendChild(text2);
			//	elem3.AppendChild(text3);
			//	elem4.AppendChild(text4);
			//	elem5.AppendChild(text5);

			//	// присоединить узлы элементов к узлу bike
			//	bike.AppendChild(elem1);
			//	bike.AppendChild(elem2);
			//	bike.AppendChild(elem3);
			//	bike.AppendChild(elem4);
			//	bike.AppendChild(elem5);

			//	// присоединить узел bike к корневому узлу
			//	root.AppendChild(bike);

			//	// сохранить измененный документ
			//	doc.Save("Motorcycle.xml"); 
			//	Console.WriteLine("The Motorcycle.xml file is generated!");
			//}
			//catch (Exception ex)
			//{
			//	Console.WriteLine(ex.Message);
			//}


			//-- 4 --

			//XmlTextReader reader = null;

			//try
			//{
			//	reader = new XmlTextReader("Cars.xml");
			//	reader.WhitespaceHandling = WhitespaceHandling.None;

			//	while (reader.Read())
			//	{
			//		Console.WriteLine($"Type={reader.NodeType}\t\tName={ reader.Name}\t\tValue={ reader.Value}");

			//		if (reader.AttributeCount > 0)
			//		{
			//			while (reader.MoveToNextAttribute())
			//			{
			//				Console.WriteLine($"Type={reader.NodeType}\tName={reader.Name}\tValue={reader.Value}");
			//			}
			//		}
			//	}
			//}
			//catch(Exception ex)
			//{
			//	Console.WriteLine(ex.Message);
			//}
			//finally
			//{
			//	if(reader != null) reader.Close();
			//}

			//-- 5 --

			XmlTextReader reader = null;
			try
			{
				reader = new XmlTextReader("Cars.xml");
				reader.WhitespaceHandling = WhitespaceHandling.None;

				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element && reader.Name == "Car" && reader.AttributeCount > 0)
					{
						while (reader.MoveToNextAttribute())
						{
							if (reader.Name == "Image")
							{
								Console.WriteLine(reader.Value);
								break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				if (reader != null) reader.Close();
			}


			

			Console.Read();
        }


	}
}
