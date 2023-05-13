using InventoryUpdater.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Manager
{
    internal class Companies
    {
        public List<Company> _companies { get; set; }
        private string _lastSavedWorkspaceLocation;


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


        public Companies()
        {
            LoadLastSavedCompanies();
        }

        private void LoadLastSavedCompanies()
        {
            if (!ProjIO.DoesWorkspaceAndProjectsExists())
                return;
            _lastSavedWorkspaceLocation =  ProjIO.GetUserSetting(Constants.WorkspaceDir);
            _companies= new List<Company>();
            if (DoesCompanyExist(Constants.Company1Name, Constants.Company1Code))
                _companies.Add(new Company(ProjIO.GetUserSetting(Constants.Company1Name), ProjIO.GetUserSetting(Constants.Company1Code)));

            if (DoesCompanyExist(Constants.Company2Name, Constants.Company2Code))
                _companies.Add(new Company(ProjIO.GetUserSetting(Constants.Company2Name), ProjIO.GetUserSetting(Constants.Company2Code)));

            if (DoesCompanyExist(Constants.Company3Name, Constants.Company3Code))
                _companies.Add(new Company(ProjIO.GetUserSetting(Constants.Company3Name), ProjIO.GetUserSetting(Constants.Company3Code)));

            if (DoesCompanyExist(Constants.Company4Name, Constants.Company4Code))
                _companies.Add(new Company(ProjIO.GetUserSetting(Constants.Company4Name), ProjIO.GetUserSetting(Constants.Company4Code)));

            if (DoesCompanyExist(Constants.Company5Name, Constants.Company5Code))
                _companies.Add(new Company(ProjIO.GetUserSetting(Constants.Company5Name), ProjIO.GetUserSetting(Constants.Company5Code)));
        }


        private bool DoesCompanyExist(string name, string code)
        {
            if (!string.IsNullOrEmpty(ProjIO.GetUserSetting(name)) &&
                !string.IsNullOrEmpty(ProjIO.GetUserSetting(code)))
                return true;
            else
                return false;
        }

        internal bool DoesCompanyCodeExist(string code)
        {
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company1Code), code))
                return true;
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company2Code), code))
                return true;
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company3Code), code))
                return true;
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company4Code), code))
                return true;
            if (string.Equals(ProjIO.GetUserSetting(Constants.Company5Code), code))
                return true;

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
    }
}
