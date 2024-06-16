using SellerSense.ViewManager;
using SellerSense.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellerSense.Model.Reports;
using static SellerSense.ViewManager.VM_Companies;
using CommonUtil;

namespace SellerSense.ViewManager
{
    public class VM_Companies
    {
        public List<VM_Company> _companies { get; set; }
        private string _lastSavedWorkspaceLocation;
        private CrossCompanySharedWrapper _companiesSharedWrapper1;
        private CrossCompanySharedWrapper _companiesSharedWrapper2;
        private CrossCompanySharedWrapper _companiesSharedWrapper3;
        private CrossCompanySharedWrapper _companiesSharedWrapper4;
        private CrossCompanySharedWrapper _companiesSharedWrapper5;


        private CrossCompanyEvents _crossCompanyEvents;
       
        public static string GetRandomCode(string name, int length)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            string codeName = name.Replace(" ", "");
            if (codeName.Length>8)
                codeName = codeName.Substring(0,8);
 
            return codeName + "_" + str_build.ToString();
        }


        public VM_Companies()
        {
            LoadLastSavedCompanies();
            
        }

        internal int GetTotalInventoryForAllCompanies(string inhouseCode)
        {
            
           int tcomp1 = _companiesSharedWrapper1._crossCompanyLinkedInventoryCount.GetTotalInventoryCountForThisCompany(inhouseCode);
           int tcomp2 = _companiesSharedWrapper2._crossCompanyLinkedInventoryCount.GetTotalInventoryCountForThisCompany(inhouseCode);
           int tcomp3 = _companiesSharedWrapper3._crossCompanyLinkedInventoryCount.GetTotalInventoryCountForThisCompany(inhouseCode);
           int tcomp4 = _companiesSharedWrapper4._crossCompanyLinkedInventoryCount.GetTotalInventoryCountForThisCompany(inhouseCode);
           int tcomp5 = _companiesSharedWrapper5._crossCompanyLinkedInventoryCount.GetTotalInventoryCountForThisCompany(inhouseCode);
            return tcomp1 + tcomp2 + tcomp3 + tcomp4 + tcomp5;
        }


        private void LoadLastSavedCompanies()
        {
           
            if (!ProjIO.DoesWorkspaceAndProjectsExists())
                return;
            _lastSavedWorkspaceLocation =  ProjIO.GetUserSetting(Constants.WorkspaceDir);
            _crossCompanyEvents = new CrossCompanyEvents();
            _companies = new List<VM_Company>();
            _companiesSharedWrapper1 = new CrossCompanySharedWrapper(this);
            _companiesSharedWrapper2 = new CrossCompanySharedWrapper(this);
            _companiesSharedWrapper3 = new CrossCompanySharedWrapper(this);
            _companiesSharedWrapper4 = new CrossCompanySharedWrapper(this);
            _companiesSharedWrapper5 = new CrossCompanySharedWrapper(this);

           
            if (DoesCompanyExist(Constants.Company1Name, Constants.Company1Code))
                _companies.Add(new VM_Company(ProjIO.GetUserSetting(Constants.Company1Name),
                    ProjIO.GetUserSetting(Constants.Company1Code), _companiesSharedWrapper1,
                    _crossCompanyEvents));

            if (DoesCompanyExist(Constants.Company2Name, Constants.Company2Code))
                _companies.Add(new VM_Company(ProjIO.GetUserSetting(Constants.Company2Name), 
                    ProjIO.GetUserSetting(Constants.Company2Code), _companiesSharedWrapper2, _crossCompanyEvents));

            if (DoesCompanyExist(Constants.Company3Name, Constants.Company3Code))
                _companies.Add(new VM_Company(ProjIO.GetUserSetting(Constants.Company3Name), 
                    ProjIO.GetUserSetting(Constants.Company3Code), _companiesSharedWrapper3, _crossCompanyEvents));

            if (DoesCompanyExist(Constants.Company4Name, Constants.Company4Code))
                _companies.Add(new VM_Company(ProjIO.GetUserSetting(Constants.Company4Name), 
                    ProjIO.GetUserSetting(Constants.Company4Code), _companiesSharedWrapper4, _crossCompanyEvents));

            if (DoesCompanyExist(Constants.Company5Name, Constants.Company5Code))
                _companies.Add(new VM_Company(ProjIO.GetUserSetting(Constants.Company5Name), 
                    ProjIO.GetUserSetting(Constants.Company5Code), _companiesSharedWrapper5, _crossCompanyEvents));
        }


        private bool DoesCompanyExist(string name, string code)
        {
            if (!string.IsNullOrEmpty(ProjIO.GetUserSetting(name)) &&
                !string.IsNullOrEmpty(ProjIO.GetUserSetting(code)))
                return true;
            else
                return false;
        }

       

        internal void AddCompany1(string name, string code)
        {
            ProjIO.SaveUserSetting(Constants.Company1Code, code);
            ProjIO.SaveUserSetting(Constants.Company1Name, name);
            ProjIO.CreateWorkspace();
            ProjIO.CreateCompanyDir(code);
        }

        internal void AddCompany2(string name, string code)
        {
            ProjIO.SaveUserSetting(Constants.Company2Code, code);
            ProjIO.SaveUserSetting(Constants.Company2Name, name);
            ProjIO.CreateWorkspace();
            ProjIO.CreateCompanyDir(code);
        }

        internal void AddCompany3(string name, string code)
        {
            ProjIO.SaveUserSetting(Constants.Company3Code, code);
            ProjIO.SaveUserSetting(Constants.Company3Name, name);
        }

        internal void AddCompany4(string name, string code)
        {
            ProjIO.SaveUserSetting(Constants.Company4Code, code);
            ProjIO.SaveUserSetting(Constants.Company4Name, name);
        }

        internal void AddCompany5(string name, string code)
        {
            ProjIO.SaveUserSetting(Constants.Company5Code, code);
            ProjIO.SaveUserSetting(Constants.Company5Name, name);
        }


        public class CrossCompanyEvents
        {
            public event EventHandler CrossCompanySharedInventoryUpdated;
            public void InvokeCrossCompanySharedInventoryUpdate()
            {
                CrossCompanySharedInventoryUpdated?.Invoke(this, EventArgs.Empty);
            }
        }


        //IMP - this class is different for each company
        //wraps all cross company shared class objects
        public class CrossCompanySharedWrapper
        {
            internal CrossCompanyLinkedInventoryCount _crossCompanyLinkedInventoryCount;
            private VM_Companies _vm_companies;
            internal OrderStatusReportBuilder _orderReportBuilder;
            internal InventoryStatusReportBuilder _InvReportBuilder;



            internal void SendCrossCompanyInventoryStatus()
            {
                string a_outOfStock =""; string f_outOfStock = ""; string s_outOfStock = ""; string m_outOfStock = ""; 
                _InvReportBuilder = new InventoryStatusReportBuilder(_vm_companies._companies[0]._inventoriesViewManager._inventoryViewList, _vm_companies._companies[0]._code
                    , _vm_companies._companies[1]._inventoriesViewManager._inventoryViewList, _vm_companies._companies[1]._code);
                (InvStatusReport az, InvStatusReport fk, InvStatusReport sp, InvStatusReport mso) = _InvReportBuilder.Build();

                var OutOfStockcompanya = az.outOfStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[0]._code)).ToList();
                var OutOfStockcompanyb = az.outOfStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[1]._code)).ToList();
                a_outOfStock = FormatOutOfStockItems(a_outOfStock, "Amazon", OutOfStockcompanya, OutOfStockcompanyb);

                OutOfStockcompanya = fk.outOfStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[0]._code)).ToList();
                OutOfStockcompanyb = fk.outOfStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[1]._code)).ToList();
                f_outOfStock = FormatOutOfStockItems(f_outOfStock, "Flipkart", OutOfStockcompanya, OutOfStockcompanyb);

                OutOfStockcompanya = sp.outOfStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[0]._code)).ToList();
                OutOfStockcompanyb = sp.outOfStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[1]._code)).ToList();
                s_outOfStock = FormatOutOfStockItems(s_outOfStock, "Snapdeal", OutOfStockcompanya, OutOfStockcompanyb);

                OutOfStockcompanya = mso.outOfStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[0]._code)).ToList();
                OutOfStockcompanyb = mso.outOfStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[1]._code)).ToList();
                m_outOfStock = FormatOutOfStockItems(m_outOfStock, "Meesho", OutOfStockcompanya, OutOfStockcompanyb);

                string sa_outOfStock = ""; string sf_outOfStock = ""; string ss_outOfStock = ""; string sm_outOfStock = "";
                var SingleStockcompanya = az.singleStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[0]._code)).ToList();
                var SingleStockcompanyb = az.singleStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[1]._code)).ToList();
                sa_outOfStock = FormatSingleStockItems(sa_outOfStock, "Amazon", SingleStockcompanya, SingleStockcompanyb);

                SingleStockcompanya = fk.singleStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[0]._code)).ToList();
                SingleStockcompanyb = fk.singleStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[1]._code)).ToList();
                sf_outOfStock = FormatSingleStockItems(sf_outOfStock, "Flipkart", SingleStockcompanya, SingleStockcompanyb);

                SingleStockcompanya = sp.singleStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[0]._code)).ToList();
                SingleStockcompanyb = sp.singleStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[1]._code)).ToList();
                ss_outOfStock = FormatSingleStockItems(ss_outOfStock, "Snapdeal", SingleStockcompanya, SingleStockcompanyb);

#if IncludeMeesho
                SingleStockcompanya = mso.singleStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[0]._code)).ToList();
                SingleStockcompanyb = mso.singleStockItems.Where(x => x.companyCode.Equals(_vm_companies._companies[1]._code)).ToList();
                sm_outOfStock = FormatSingleStockItems(sm_outOfStock, "Meesho", SingleStockcompanya, SingleStockcompanyb);
#endif

                string msg = a_outOfStock + Environment.NewLine + f_outOfStock + Environment.NewLine + s_outOfStock + Environment.NewLine + m_outOfStock 
                    +Environment.NewLine + sa_outOfStock + Environment.NewLine + sf_outOfStock + Environment.NewLine + ss_outOfStock + Environment.NewLine + sm_outOfStock;
                Views.MessagePopBox msgPop = new Views.MessagePopBox(msg, () =>
                {
                    //callback when user click on telegram button
                    //Logger.Telegram(f_outOfStock);
                    //Logger.Telegram(a_outOfStock);
                    //Logger.Telegram(s_outOfStock);
                    //Logger.Telegram(m_outOfStock);
                    //Logger.Telegram(sa_outOfStock);
                    //Logger.Telegram(sf_outOfStock);
                    //Logger.Telegram(ss_outOfStock);
                    //Logger.Telegram(sm_outOfStock);
                }
                , "Send To Telegram");
                msgPop.ShowDialog();
               



                //return _orderReportBuilder.WithTodaysOrderCount().Build();
            }

            private string FormatOutOfStockItems(string outOfStock, string site,
                List<InvStatusReport.OutOfStockItem> OutOfStockcompanya, List<InvStatusReport.OutOfStockItem> OutOfStockcompanyb)
            {
                outOfStock = string.Empty;
                outOfStock = outOfStock + ("Out of Stock Items "+ site + " " + _vm_companies._companies[0]._code + Environment.NewLine);
                foreach (var item in OutOfStockcompanya)
                    outOfStock = outOfStock + (item.InhouseCode + ":" + item.Title + Environment.NewLine);
                outOfStock = outOfStock + (Environment.NewLine + "Out of Stock Items " + site + " " + _vm_companies._companies[1]._code + Environment.NewLine);
                //Company B out of stock or single stock items
                foreach (var item in OutOfStockcompanyb)
                    outOfStock = outOfStock + (item.InhouseCode + ":" + item.Title + Environment.NewLine);
                return outOfStock;
            }

            private string FormatSingleStockItems(string SingleStock, string site,
                List<InvStatusReport.SingleStockItem> SingleStockcompanya, List<InvStatusReport.SingleStockItem> SingleStockcompanyb)
            {
                SingleStock = string.Empty;
                SingleStock = SingleStock + ("Single Stock Items " + site + " " + _vm_companies._companies[0]._code + Environment.NewLine);
                foreach (var item in SingleStockcompanya)
                    SingleStock = SingleStock + (item.InhouseCode + ":" + item.Title + Environment.NewLine);
                SingleStock = SingleStock + (Environment.NewLine + "Single Stock Items " + site + " " + _vm_companies._companies[1]._code + Environment.NewLine);
                //Company B out of stock or single stock items
                foreach (var item in SingleStockcompanyb)
                    SingleStock = SingleStock + (item.InhouseCode + ":" + item.Title + Environment.NewLine);
                return SingleStock;
            }

            internal void SendCrossCompanyTodaysOrderReport()
            {
                _orderReportBuilder = 
                    new OrderStatusReportBuilder(_vm_companies._companies[0]._product_Model, _vm_companies._companies[1]._product_Model);
                M_OrderStatusReport orders = _orderReportBuilder.WithTodaysOrderCount().Build();

                string msg = Environment.NewLine +
                "Total orders today: " + orders.TotalOrders_Today.TotalOrder + Environment.NewLine +
                "Company: " + orders.TotalOrders_Today.CompanyA.Company + Environment.NewLine +
                "Amazon: " + orders.TotalOrders_Today.CompanyA.AmzOrderCount + Environment.NewLine +
                "Flipkart: " + orders.TotalOrders_Today.CompanyA.FkOrderCount + Environment.NewLine +
                "Snapdeal: " + orders.TotalOrders_Today.CompanyA.SpdOrderCount + Environment.NewLine +
                "Meesho: " + orders.TotalOrders_Today.CompanyA.MsoOrderCount + Environment.NewLine +
                "Company: " + orders.TotalOrders_Today.CompanyB.Company + Environment.NewLine +
                "Amazon: " + orders.TotalOrders_Today.CompanyB.AmzOrderCount + Environment.NewLine +
                "Flipkart: " + orders.TotalOrders_Today.CompanyB.FkOrderCount + Environment.NewLine +
                "Snapdeal: " + orders.TotalOrders_Today.CompanyB.SpdOrderCount + Environment.NewLine
#if IncludeMeesho
                + "Meesho: " + orders.TotalOrders_Today.CompanyB.MsoOrderCount + Environment.NewLine
#endif                
                ;

                Views.MessagePopBox msgPop = new Views.MessagePopBox(msg, () => {
                    //callback when user click on telegram button
                    //Logger.Telegram(msg);
                }
            , "Send To Telegram");
                msgPop.ShowDialog();
               
            }

            public CrossCompanySharedWrapper(VM_Companies vm_companies)
            {
                _vm_companies = vm_companies;
                _crossCompanyLinkedInventoryCount = new CrossCompanyLinkedInventoryCount(vm_companies);
            }

        }




        // Represents linked inhouse inventory, stores individual inv counts from all vendors in all companies.
        // Then used to update inhouse inventory column, shows user total all inventory asssigned to 
        // all vendors.
        public class CrossCompanyLinkedInventoryCount
        {
            private IList<LinkedProductInventory> linkedInv { get; set; }
            private VM_Companies _vm_companies;

            public CrossCompanyLinkedInventoryCount(VM_Companies _companies)
            {
                _vm_companies = _companies;
                linkedInv = new List<LinkedProductInventory>();
            }

            public int GetAllInventoriesFromAllCompanies(string inHouseCode)
            {
                return _vm_companies.GetTotalInventoryForAllCompanies(inHouseCode);
            }

            

            public int GetTotalInventoryCountForThisCompany(string inhouseCode)
            {
                int total = 0;
                var prod = linkedInv.FirstOrDefault( x=>x.LinkedInhouseCode == inhouseCode);
                if (prod != null)
                    total = total + prod.AmzCount + prod.SnpCount + prod.FkCount
#if IncludeMeesho
                        + prod.MesshoCount
#endif
                        ;
                return total;
            }


#if IncludeMeesho
            public void AddToSharedInventory(string inhouseCode, int amzCount, int fkCount, int spdCount, int msoCount)
            {
                var item = linkedInv.FirstOrDefault(x => x.LinkedInhouseCode == inhouseCode);
                if (item != null)
                { item.SnpCount = spdCount; item.AmzCount = amzCount; item.MesshoCount = msoCount; item.FkCount = fkCount; }
                else 
                { 
                    LinkedProductInventory inventory = new LinkedProductInventory()
                    { AmzCount = amzCount, FkCount = fkCount, SnpCount = spdCount, MesshoCount = msoCount, LinkedInhouseCode = inhouseCode };
                    linkedInv.Add(inventory);
                }
            }

#else
            public void AddToSharedInventory(string inhouseCode, int amzCount, int fkCount, int spdCount)
            {
                var item = linkedInv.FirstOrDefault(x => x.LinkedInhouseCode == inhouseCode);
                if (item != null)
                { item.SnpCount = spdCount; item.AmzCount = amzCount;  item.FkCount = fkCount; }
                else
                {
                    LinkedProductInventory inventory = new LinkedProductInventory()
                    { AmzCount = amzCount, FkCount = fkCount, SnpCount = spdCount, LinkedInhouseCode = inhouseCode };
                    linkedInv.Add(inventory);
                }
            }
#endif

            public class LinkedProductInventory
            {
                internal string LinkedInhouseCode { get; set; }
                internal int AmzCount { get; set; }
                internal int FkCount { get; set; }
                internal int SnpCount { get; set; }
#if IncludeMeesho
                internal int MesshoCount { get; set; }
#endif
            }

        }





    }
}
