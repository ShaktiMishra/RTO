using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QMgmtRTO.BusinessLayer.Display
{
    public class EntranceManager
    {

        #region Entrance BLL -Pravanjan Nayak

        public System.Data.DataTable GetDisplayTimeBLL(string CentreCode)
        {
            DataAccessLayer.Display.EntranceDAO EnDAO = new DataAccessLayer.Display.EntranceDAO();
            Entities.Display entObj1 = new Entities.Display();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = EnDAO.GetDisplayTimeDAL(CentreCode);
            return dt;

        }

        public System.Data.DataTable GetTokenDetailsBLL(string ServiceType, string slottime, string CentreCode)
        {
            DataAccessLayer.Display.EntranceDAO EnDAO = new DataAccessLayer.Display.EntranceDAO();
            Entities.Display entObj1 = new Entities.Display();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = EnDAO.GetTokenDetailsDAL(ServiceType, slottime, CentreCode);
            return dt1;

        }

        public System.Data.DataTable GetSWSlotDetailsBLL(string slottime, string CentreCode)
        {
            DataAccessLayer.Display.EntranceDAO EnDAO = new DataAccessLayer.Display.EntranceDAO();
            Entities.Display entObj1 = new Entities.Display();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = EnDAO.GetSWSlotDetailsDAL(slottime, CentreCode);
            return dt;

        }

        public System.Data.DataTable GetSlotDetailsBLL(string CentreCode)
        {
            DataAccessLayer.Display.EntranceDAO EnDAO = new DataAccessLayer.Display.EntranceDAO();
            Entities.Display entObj1 = new Entities.Display();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = EnDAO.GetSlotDetailsDAL(CentreCode);
            return dt;

        }

        DataAccessLayer.Display.EntranceDAO EnDAO1 = new DataAccessLayer.Display.EntranceDAO();
        public int UpdateslotStatusBLL(string slottime, string ServiceType, string centercode)
        {
            return EnDAO1.UpdateslotStatusDAL(slottime, ServiceType, centercode);
        }


        public System.Data.DataTable GetQRDisplayTimeBLL(string CentreCode)
        {
            DataAccessLayer.Display.EntranceDAO EnDAO = new DataAccessLayer.Display.EntranceDAO();
            Entities.Display entObj1 = new Entities.Display();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = EnDAO.GetQRDisplayTimeDAL(CentreCode);
            return dt;

        }

        public System.Data.DataTable GetQRTokenDetailsBLL(string CentreCode, string applno, DateTime date, string service)
        {
            DataAccessLayer.Display.EntranceDAO EnDAO = new DataAccessLayer.Display.EntranceDAO();
            Entities.Display entObj1 = new Entities.Display();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = EnDAO.GetQRTokenDetailsDAL(CentreCode, applno, date, service);
            return dt1;

        }

        public System.Data.DataTable GetQRSlotDetailsBLL(string CentreCode, string applno, DateTime date, string service)
        {
            DataAccessLayer.Display.EntranceDAO EnDAO = new DataAccessLayer.Display.EntranceDAO();
            Entities.Display entObj1 = new Entities.Display();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = EnDAO.GetQRSlotDetailsDAL(CentreCode, applno, date, service);
            return dt;

        }


        DataAccessLayer.Display.EntranceDAO EnDAO2 = new DataAccessLayer.Display.EntranceDAO();
        public int QRUpdatesTokenDetailsBLL(string applno, string centercode, string currentStatus)
        {
            return EnDAO2.QRUpdatesTokenDetailsDAL(applno, centercode, currentStatus);
        }

        #endregion
    }
}
