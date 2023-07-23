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

        internal void CompareAmazonInventoryListWithSnapshots(List<InventoryView> _inventoryViewList,
            M_InvSnapshot _m_invSnapShotModel, ConfirmInventoryAction ca)
        {

            foreach (var invItem in _inventoryViewList)
            {
                foreach (var snapItem in _m_invSnapShotModel._invLastSavedSnapshotEntries)
                {
                    //inv was updated by user & user uploaded file on Amazon
                    if (invItem.AmazonCode == snapItem.ACode && snapItem.AInv != snapItem.ASystemInv && ca.AmazonChecked)
                    {
                        int orders = Convert.ToInt16(snapItem.AInv) - Convert.ToInt16(invItem.AmazonSystemCount);
                        orders = Math.Abs(orders);
                        invItem.AmazonSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.AInv + " | now:" + invItem.AmazonSystemCount;
                    }

                    //not updated by user, just order came
                    if (invItem.AmazonCode == snapItem.ACode && snapItem.AInv == snapItem.ASystemInv &&
                        invItem.AmazonSystemCount != snapItem.ASystemInv)
                    {
                        int orders =  Convert.ToInt16(snapItem.ASystemInv) - Convert.ToInt16(invItem.AmazonSystemCount);
                        orders = Math.Abs(orders);
                        invItem.AmazonSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.AInv + " | now:" + invItem.AmazonSystemCount;
                    }

                }
            }
        }




        internal void CompareFlipkartInventoryListWithSnapshots(List<InventoryView> _inventoryViewList,
            M_InvSnapshot _m_invSnapShotModel, ConfirmInventoryAction ca)
        {

            foreach (var invItem in _inventoryViewList)
            {
                foreach (var snapItem in _m_invSnapShotModel._invLastSavedSnapshotEntries)
                {
                    //inv was updated by user & user uploaded file on Amazon
                    if (invItem.FlipkartCode == snapItem.FCode && snapItem.FInv != snapItem.FSystemInv && ca.FlipkartChecked)
                    {
                        int orders = Convert.ToInt16(snapItem.FInv) - Convert.ToInt16(invItem.FlipkartSystemCount);
                        orders = Math.Abs(orders);
                        invItem.FlipkartSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.FInv + " | now:" + invItem.FlipkartSystemCount;
                    }

                    //not updated by user, just order came
                    if (invItem.FlipkartCode == snapItem.FCode && snapItem.FInv == snapItem.FSystemInv &&
                        invItem.FlipkartSystemCount != snapItem.FSystemInv)
                    {
                        int orders = Convert.ToInt16(snapItem.FSystemInv) - Convert.ToInt16(invItem.FlipkartSystemCount);
                        orders = Math.Abs(orders);
                        invItem.FlipkartSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.FInv + " | now:" + invItem.FlipkartSystemCount;
                    }

                }
            }
        }






        internal void CompareSnapdealInventoryListWithSnapshots(List<InventoryView> _inventoryViewList,
            M_InvSnapshot _m_invSnapShotModel, ConfirmInventoryAction ca)
        {

            foreach (var invItem in _inventoryViewList)
            {
                foreach (var snapItem in _m_invSnapShotModel._invLastSavedSnapshotEntries)
                {
                    //inv was updated by user & user uploaded file on Amazon
                    if (invItem.SnapdealCode == snapItem.SCode && snapItem.SInv != snapItem.SSystemInv && ca.SnapdealChecked)
                    {
                        int orders = Convert.ToInt16(snapItem.SInv) - Convert.ToInt16(invItem.SnapdealSystemCount);
                        orders = Math.Abs(orders);
                        invItem.SnapdealSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.SInv + " | now:" + invItem.SnapdealSystemCount;
                    }

                    //not updated by user, just order came
                    if (invItem.SnapdealCode == snapItem.SCode && snapItem.SInv == snapItem.SSystemInv &&
                        invItem.SnapdealSystemCount != snapItem.SSystemInv)
                    {
                        int orders = Convert.ToInt16(snapItem.SSystemInv) - Convert.ToInt16(invItem.SnapdealSystemCount);
                        orders = Math.Abs(orders);
                        invItem.SnapdealSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.SInv + " | now:" + invItem.SnapdealSystemCount;
                    }

                }
            }
        }




        internal void CompareMeeshoInventoryListWithSnapshots(List<InventoryView> _inventoryViewList,
            M_InvSnapshot _m_invSnapShotModel, ConfirmInventoryAction ca)
        {

            foreach (var invItem in _inventoryViewList)
            {
                foreach (var snapItem in _m_invSnapShotModel._invLastSavedSnapshotEntries)
                {
                    //inv was updated by user & user uploaded file on Amazon
                    if (invItem.MeeshoCode == snapItem.MCode && snapItem.MInv != snapItem.MSystemInv && ca.MeeshoChecked)
                    {
                        int orders = Convert.ToInt16(snapItem.MInv) - Convert.ToInt16(invItem.MeeshoSystemCount);
                        orders = Math.Abs(orders);
                        invItem.MeeshoSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.MInv + " | now:" + invItem.MeeshoSystemCount;
                    }

                    //not updated by user, just order came
                    if (invItem.MeeshoCode == snapItem.MCode && snapItem.MInv == snapItem.MSystemInv &&
                        invItem.MeeshoSystemCount != snapItem.MSystemInv)
                    {
                        int orders = Convert.ToInt16(snapItem.MSystemInv) - Convert.ToInt16(invItem.MeeshoSystemCount);
                        orders = Math.Abs(orders);
                        invItem.MeeshoSystemCount = "orders:" + orders.ToString() + " | was:" + snapItem.MInv + " | now:" + invItem.MeeshoSystemCount;
                    }

                }
            }
        }







    }
}
