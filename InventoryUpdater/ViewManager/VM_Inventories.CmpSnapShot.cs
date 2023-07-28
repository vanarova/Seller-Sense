using SellerSense.Model;
using SellerSense.Views.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SellerSense.ViewManager.VM_Inventories;

namespace SellerSense.ViewManager
{
    internal partial class VM_Inventories
    {

        private void LoadSnapshotAndUpdateBindingListWithComparisons()
        {
            _m_invSnapShotModel.DeSerializeLastInvSnapshot();
            ConfirmInventoryAction ca = new ConfirmInventoryAction();
            ca.ShowDialog();
            CompareAmazonInventoryListWithSnapshots(_inventoryViewList, _m_invSnapShotModel, ca);
            CompareFlipkartInventoryListWithSnapshots(_inventoryViewList, _m_invSnapShotModel, ca);
            CompareSnapdealInventoryListWithSnapshots(_inventoryViewList, _m_invSnapShotModel, ca);
            CompareMeeshoInventoryListWithSnapshots(_inventoryViewList, _m_invSnapShotModel, ca);

        }


        internal void CompareAmazonInventoryListWithSnapshots(List<InventoryView> _inventoryViewList,
            M_InvSnapshot _m_invSnapShotModel, ConfirmInventoryAction ca)
        {
            if (_m_invSnapShotModel._invLastSavedSnapshotEntries == null ||
                _m_invSnapShotModel._invLastSavedSnapshotEntries.Count == 0)
                return;
            foreach (var invItem in _inventoryViewList)
            {
                foreach (var snapItem in _m_invSnapShotModel._invLastSavedSnapshotEntries)
                {
                    //inv was updated by user & user uploaded file on Amazon
                    if (invItem.AmazonCode == snapItem.ACode && snapItem.AInv != snapItem.ASystemInv && ca.AmazonChecked)
                    {
                        if (int.TryParse(snapItem.AInv, out int ainv) &&
                        int.TryParse(invItem.AmazonSystemCount, out int amazonSystemCount))
                        {
                            int orders = ainv - amazonSystemCount;
                            orders = Math.Abs(orders);
                            invItem.AmazonSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.AInv + " | now:" + invItem.AmazonSystemCount;
                        }
                        
                    }

                    //not updated by user, just order came
                    if (invItem.AmazonCode == snapItem.ACode && snapItem.AInv == snapItem.ASystemInv &&
                        invItem.AmazonSystemCount != snapItem.ASystemInv)
                    {
                        if(int.TryParse(snapItem.ASystemInv, out int aSystemInv) &&
                        int.TryParse(invItem.AmazonSystemCount, out int amazonSystemCount))
                        {
                            int orders = aSystemInv - amazonSystemCount;
                            orders = Math.Abs(orders);
                            invItem.AmazonSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.AInv + " | now:" + invItem.AmazonSystemCount;
                        }
                    }

                }
            }
        }




        internal void CompareFlipkartInventoryListWithSnapshots(List<InventoryView> _inventoryViewList,
            M_InvSnapshot _m_invSnapShotModel, ConfirmInventoryAction ca)
        {
            if (_m_invSnapShotModel._invLastSavedSnapshotEntries == null ||
               _m_invSnapShotModel._invLastSavedSnapshotEntries.Count == 0)
                return;
            foreach (var invItem in _inventoryViewList)
            {
                foreach (var snapItem in _m_invSnapShotModel._invLastSavedSnapshotEntries)
                {
                    //inv was updated by user & user uploaded file on Amazon
                    if (invItem.FlipkartCode == snapItem.FCode && snapItem.FInv != snapItem.FSystemInv && ca.FlipkartChecked)
                    {
                        if (int.TryParse(snapItem.FInv, out int finv) &&
                        int.TryParse(invItem.FlipkartSystemCount, out int fSystemCount))
                        {
                            int orders = finv - fSystemCount;
                            orders = Math.Abs(orders);
                            invItem.FlipkartSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.FInv + " | now:" + invItem.FlipkartSystemCount;
                        }
                    }

                    //not updated by user, just order came
                    if (invItem.FlipkartCode == snapItem.FCode && snapItem.FInv == snapItem.FSystemInv &&
                        invItem.FlipkartSystemCount != snapItem.FSystemInv)
                    {
                        if (int.TryParse(snapItem.FSystemInv, out int fsysinv) &&
                       int.TryParse(invItem.FlipkartSystemCount, out int fSystemCount))
                        {
                            int orders = fsysinv - fSystemCount;
                            orders = Math.Abs(orders);
                            invItem.FlipkartSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.FInv + " | now:" + invItem.FlipkartSystemCount;
                        }
                    }

                }
            }
        }






        internal void CompareSnapdealInventoryListWithSnapshots(List<InventoryView> _inventoryViewList,
            M_InvSnapshot _m_invSnapShotModel, ConfirmInventoryAction ca)
        {
            if (_m_invSnapShotModel._invLastSavedSnapshotEntries == null ||
               _m_invSnapShotModel._invLastSavedSnapshotEntries.Count == 0)
                return;
            foreach (var invItem in _inventoryViewList)
            {
                foreach (var snapItem in _m_invSnapShotModel._invLastSavedSnapshotEntries)
                {
                    //inv was updated by user & user uploaded file on Amazon
                    if (invItem.SnapdealCode == snapItem.SCode && snapItem.SInv != snapItem.SSystemInv && ca.SnapdealChecked)
                    {
                        if (int.TryParse(snapItem.SInv, out int SInv) &&
                       int.TryParse(invItem.SnapdealSystemCount, out int SnapdealSystemCount))
                        {
                            int orders = SInv-SnapdealSystemCount;
                            orders = Math.Abs(orders);
                            invItem.SnapdealSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.SInv + " | now:" + invItem.SnapdealSystemCount;
                        }
                    }

                    //not updated by user, just order came
                    if (invItem.SnapdealCode == snapItem.SCode && snapItem.SInv == snapItem.SSystemInv &&
                        invItem.SnapdealSystemCount != snapItem.SSystemInv)
                    {
                        if (int.TryParse(snapItem.SSystemInv, out int SSystemInv) &&
                      int.TryParse(invItem.SnapdealSystemCount, out int SnapdealSystemCount))
                        {
                            int orders = SSystemInv-SnapdealSystemCount;
                            orders = Math.Abs(orders);
                            invItem.SnapdealSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.SInv + " | now:" + invItem.SnapdealSystemCount;
                        }
                    }

                }
            }
        }




        internal void CompareMeeshoInventoryListWithSnapshots(List<InventoryView> _inventoryViewList,
            M_InvSnapshot _m_invSnapShotModel, ConfirmInventoryAction ca)
        {
            if (_m_invSnapShotModel._invLastSavedSnapshotEntries == null ||
               _m_invSnapShotModel._invLastSavedSnapshotEntries.Count == 0)
                return;
            foreach (var invItem in _inventoryViewList)
            {
                foreach (var snapItem in _m_invSnapShotModel._invLastSavedSnapshotEntries)
                {
                    //inv was updated by user & user uploaded file on Amazon
                    if (invItem.MeeshoCode == snapItem.MCode && snapItem.MInv != snapItem.MSystemInv && ca.MeeshoChecked)
                    {
                        if (int.TryParse(snapItem.MInv, out int MInv) &&
                       int.TryParse(invItem.MeeshoSystemCount, out int MeeshoSystemCount))
                        {
                            int orders = MInv - MeeshoSystemCount;
                            orders = Math.Abs(orders);
                            invItem.MeeshoSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.MInv + " | now:" + invItem.MeeshoSystemCount;
                        }
                    }

                    //not updated by user, just order came
                    if (invItem.MeeshoCode == snapItem.MCode && snapItem.MInv == snapItem.MSystemInv &&
                        invItem.MeeshoSystemCount != snapItem.MSystemInv)
                    {
                        if (int.TryParse(snapItem.MSystemInv, out int MSystemInv) &&
                      int.TryParse(invItem.MeeshoSystemCount, out int MeeshoSystemCount))
                        {
                            int orders = MSystemInv - MeeshoSystemCount;
                            orders = Math.Abs(orders);
                            invItem.MeeshoSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.MInv + " | now:" + invItem.MeeshoSystemCount;
                        }
                    }

                }
            }
        }




        internal void LoadInvSnapshotDataFromLastSavedMap()
        {
            _m_productModel.LoadLastSavedMap();
            if (!string.IsNullOrWhiteSpace(_m_productModel._lastSavedMapFilePath))
                _m_invSnapShotModel = new M_InvSnapshot(_m_productModel);

        }


        private void TranslateInvModelToInvView()
        {
            _inventoryViewList = new List<InventoryView>();
            foreach (var item in _m_productModel._productEntries)
            {
                //binding list source for grid
                _inventoryViewList.Add(new InventoryView()
                {
                    InHouseCode = item.InHouseCode,
                    Title = item.Title,
                    Tag = item.Tag,
                    Image = null,
                    AmazonCode = item.AmazonCode,
                    FlipkartCode = item.FlipkartCode,
                    MeeshoCode = item.MeeshoCode,
                    SnapdealCode = item.SnapdealCode
                });

                //fill snapshot
                _m_invSnapShotModel._invSnapshotEntries.Add(new InvSnapshotEntry()
                {
                    ICode = item.InHouseCode,
                    ACode = item.AmazonCode,
                    FCode = item.FlipkartCode,
                    SCode = item.SnapdealCode,
                    MCode = item.MeeshoCode

                });
            }
        }


        internal void SaveInvSnapshot()
        {

            _m_invSnapShotModel.SaveInvSnapshot();
        }


    }
}
