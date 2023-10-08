using SellerSense.ViewManager;
using SellerSense.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellerSense.Model.Reports;

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
        //private CrossCompanyLinkedInventoryCount _crossCompany1LinkedInventoryCount;
        //private CrossCompanyLinkedInventoryCount _crossCompany2LinkedInventoryCount;
        //private CrossCompanyLinkedInventoryCount _crossCompany3LinkedInventoryCount;
        //private CrossCompanyLinkedInventoryCount _crossCompany4LinkedInventoryCount;
        //private CrossCompanyLinkedInventoryCount _crossCompany5LinkedInventoryCount;
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
            //_crossCompany1LinkedInventoryCount = new CrossCompanyLinkedInventoryCount(Constants.Company1Code, this);
            //_crossCompany2LinkedInventoryCount = new CrossCompanyLinkedInventoryCount(Constants.Company2Code, this);
            //_crossCompany3LinkedInventoryCount = new CrossCompanyLinkedInventoryCount(Constants.Company3Code, this);
            //_crossCompany4LinkedInventoryCount = new CrossCompanyLinkedInventoryCount(Constants.Company4Code, this);
            //_crossCompany5LinkedInventoryCount = new CrossCompanyLinkedInventoryCount(Constants.Company5Code, this);
           
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
            public CrossCompanyEvents()
            {
                CrossCompanySharedInventoryUpdated?.Invoke(this, EventArgs.Empty);
            }
            public event EventHandler CrossCompanySharedInventoryUpdated;
            public void InvokeCrossCompanySharedInventoryUpdated()
            {
                CrossCompanySharedInventoryUpdated?.Invoke(this, EventArgs.Empty);
            }
        }






        //wraps all cross company shared class objects
        public class CrossCompanySharedWrapper
        {
            internal CrossCompanyLinkedInventoryCount _crossCompanyLinkedInventoryCount;
            private VM_Companies _vm_companies;
            internal OrderStatusReportBuilder _orderReportBuilder;

            //internal M_OrderStatusReport GetCrossCompanyDailyOrderReport()
            //{
            //    return _orderReportBuilder.WithTodaysOrderCount().Build();
            //}

            internal M_OrderStatusReport GetCrossCompanyTodaysOrderReport()
            {
                _orderReportBuilder = 
                    new OrderStatusReportBuilder(_vm_companies._companies[0]._product_Model, _vm_companies._companies[1]._product_Model);
                return _orderReportBuilder.WithTodaysOrderCount().Build();
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
            //private Func<string, int> _getAllInventoriesForAllCompanies; //points to a function in VM_Companies class, to get total inv
            //private string _companyCode { get; set; }
            private IList<LinkedProductInventory> linkedInv { get; set; }
            private VM_Companies _vm_companies;
            //public event EventHandler SharedInventoryUpdated;

            public CrossCompanyLinkedInventoryCount(VM_Companies _companies)
            {
                _vm_companies = _companies;
                //_companyCode = companyCode;
                linkedInv = new List<LinkedProductInventory>();
                //_getAllInventoriesForAllCompanies =  _vm_companies.getAllInventoriesForAllCompanies;
                //linkedInv = new Dictionary<string, LinkedInventoryList> { { companyCode, new LinkedInventoryList() } };
            }
            //<company code, linkedCompany>
            //internal Dictionary<string, LinkedInventoryList> linkedInv { get; set; }

            public int GetAllInventoriesFromAllCompanies(string inHouseCode)
            {
                return _vm_companies.GetTotalInventoryForAllCompanies(inHouseCode);
            }

            

            public int GetTotalInventoryCountForThisCompany(string inhouseCode)
            {
                int total = 0;
                var prod = linkedInv.FirstOrDefault( x=>x.LinkedInhouseCode == inhouseCode);
                if (prod != null)
                    total = total + prod.AmzCount + prod.SnpCount + prod.FkCount + prod.MesshoCount;
                return total;
            }

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
                //SharedInventoryUpdated?.Invoke(this,null);
                _vm_companies._crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdated();
            }


            public class LinkedProductInventory
            {
                internal string LinkedInhouseCode { get; set; }
                internal int AmzCount { get; set; }
                internal int FkCount { get; set; }
                internal int SnpCount { get; set; }
                internal int MesshoCount { get; set; }
            }

        }





    }
}
