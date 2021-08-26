using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Lab2._01TXT_XML
{
    class ManejadorArchivoXml: ManejadorArchivo
    {
        protected DataSet ds;
        public override System.Data.DataTable getTabla()
        {
            this.ds = new DataSet();
            this.ds.ReadXml("agenda.xml");
            return this.ds.Tables["contactos"];
        }

        public override void aplicaCambios()
        {
            this.ds.WriteXml("agenda.xml");
            this.ds.WriteXml("agendaconschema.xml", XmlWriteMode.WriteSchema);
        }
    }
}
