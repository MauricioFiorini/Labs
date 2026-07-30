using System.Data;

namespace Lab02
{
    public class ManejadorArchivoXml : ManejadorArchivo
    {
        public override void getTabla()
        {
            DataSet ds = new DataSet();
            // Carga los datos a partir del XML[cite: 2]
            ds.ReadXml("agenda.xml");
            if (ds.Tables.Count > 0)
            {
                misContactos = ds.Tables["contactos"]; // "contactos" es el nombre del nodo elemento en el XML
            }
        }

        public override void aplicaCambios()
        {
            // El DataSet tiene la capacidad de escribir la estructura y los datos a XML[cite: 2]
            DataSet ds = new DataSet("agenda");
            ds.Tables.Add(misContactos.Copy());

            // Sobrescribe el archivo, no lo modifica incrementalmente[cite: 2]
            ds.WriteXml("agenda.xml", XmlWriteMode.WriteSchema);
        }
    }
}