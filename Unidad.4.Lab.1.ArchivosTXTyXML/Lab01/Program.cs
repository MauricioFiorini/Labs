using System;
using System.IO;   // Namespace para manipular archivos TXT (entradas y salidas de datos)
using System.Xml;  // Namespace para manipular archivos XML

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- LEYENDO ARCHIVO TXT ---");
            Leer();

            Console.WriteLine("\n--- ESCRIBIENDO EN EL ARCHIVO TXT ---");
            Escribir();

            Console.WriteLine("\n--- LEYENDO ARCHIVO TXT ACTUALIZADO ---");
            Leer();

            Console.WriteLine("\n--- GENERANDO ARCHIVO XML ---");
            EscribirXML();
            Console.WriteLine("Archivo XML generado con éxito.");

            Console.WriteLine("\n--- LEYENDO ARCHIVO XML ---");
            LeerXML();

            // Evita que la consola se cierre hasta que oprimamos una tecla
            Console.ReadKey();
        }

        // Método para leer el archivo de texto línea por línea[cite: 1]
        static void Leer()
        {
            // Utilizamos StreamReader por ser más eficiente para texto[cite: 1]
            using (StreamReader lector = new StreamReader("agenda.txt"))
            {
                string linea;
                // Leemos con el método ReadLine()[cite: 1]
                while ((linea = lector.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        // Split divide el string en un array usando el carácter ';'[cite: 1]
                        string[] valores = linea.Split(';');
                        Console.WriteLine($"Nombre: {valores[0]} {valores[1]}, Email: {valores[2]}, Tel: {valores[3]}");
                    }
                }
            }
        }

        // Método para agregar texto al final del archivo TXT[cite: 1]
        static void Escribir()
        {
            // File.AppendText crea un canal (Stream) optimizado para agregar texto al final[cite: 1]
            using (StreamWriter escritor = File.AppendText("agenda.txt"))
            {
                // Escribimos los datos utilizando WriteLine[cite: 1]
                escritor.WriteLine("Ana;Martinez;amartinez@gmail.com;444-4444");
            }
        }

        // Método para guardar los datos en formato XML[cite: 1]
        static void EscribirXML()
        {
            // Configuramos la indentación para que el XML sea legible
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            // Crea el objeto XmlWriter que nos permitirá generar el archivo[cite: 1]
            using (XmlWriter escritorXML = XmlWriter.Create("agendaxml.xml", settings))
            {
                // Escribe el encabezado del documento con la versión y codificación[cite: 1]
                escritorXML.WriteStartDocument();

                // Nodo raíz
                escritorXML.WriteStartElement("DocumentElement");

                // Leemos el TXT para transformarlo en XML
                using (StreamReader lector = new StreamReader("agenda.txt"))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(linea))
                        {
                            string[] valores = linea.Split(';');

                            // Sentencias para guardar los nodos de XML[cite: 1]
                            escritorXML.WriteStartElement("contactos");

                            escritorXML.WriteStartElement("nombre");
                            escritorXML.WriteValue(valores[0]);
                            escritorXML.WriteEndElement(); // Cerramos el tag de nombre[cite: 1]

                            escritorXML.WriteStartElement("apellido");
                            escritorXML.WriteValue(valores[1]);
                            escritorXML.WriteEndElement(); // Cerramos el tag de apellido[cite: 1]

                            escritorXML.WriteStartElement("email");
                            escritorXML.WriteValue(valores[2]);
                            escritorXML.WriteEndElement(); // Cerramos el tag de email[cite: 1]

                            escritorXML.WriteStartElement("telefono");
                            escritorXML.WriteValue(valores[3]);
                            escritorXML.WriteEndElement(); // Cerramos el tag de telefono[cite: 1]

                            escritorXML.WriteEndElement(); // Cerramos el tag de contactos[cite: 1]
                        }
                    }
                }
                escritorXML.WriteEndElement(); // Cerramos el tag de DocumentElement[cite: 1]

                // Indica que es el final del documento XML[cite: 1]
                escritorXML.WriteEndDocument();
            }
        }

        // Método para visualizar el archivo XML recién creado[cite: 1]
        static void LeerXML()
        {
            // Utilizamos el objeto XmlReader para leer[cite: 1]
            using (XmlReader lectorXML = XmlReader.Create("agendaxml.xml"))
            {
                // Para leer cada nodo usamos el método Read()[cite: 1]
                while (lectorXML.Read())
                {
                    // Accedemos a los elementos del último nodo a través de NodeType, Name y Value[cite: 1]
                    if (lectorXML.NodeType == XmlNodeType.Element)
                    {
                        Console.Write($"<{lectorXML.Name}> ");
                    }
                    else if (lectorXML.NodeType == XmlNodeType.Text)
                    {
                        Console.Write(lectorXML.Value);
                    }
                    else if (lectorXML.NodeType == XmlNodeType.EndElement)
                    {
                        Console.WriteLine($" </{lectorXML.Name}>");
                    }
                }
            }
        }
    }
}
